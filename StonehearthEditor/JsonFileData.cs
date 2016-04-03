﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StonehearthEditor
{
   public enum JSONTYPE
   {
      ERROR = 0,
      NONE = 1,
      ENTITY = 2,
      BUFF = 3,
      AI_PACK = 4,
      EFFECT = 5,
      RECIPE = 6,
      COMMAND = 7,
      ANIMATION = 8,
      ENCOUNTER = 9,
      JOB = 10,
   };

   public class JsonFileData : FileData, IModuleFileData
   {
      private ModuleFile mOwner;
      private JSONTYPE mJsonType = JSONTYPE.NONE;
      private JObject mJson;
      private string mDirectory;
      private bool mSaveJsonAfterParse = false;
      private int mNetWorth = -1;
      public int RecommendedMaxNetWorth = -1;
      public int RecommendedMinNetWorth = -1;

      public JsonFileData(string path)
      {
         mPath = path;
         mDirectory = JsonHelper.NormalizeSystemPath(System.IO.Path.GetDirectoryName(Path));
      }

      protected override void LoadInternal()
      {
         try {
            mOpenedFiles.Add(this);
            string jsonString = FlatFileData;
            mJson = JObject.Parse(jsonString);
            JToken typeObject = mJson["type"];
            if (typeObject != null)
            {
               string typeString = typeObject.ToString().Trim().ToUpper();
               foreach (JSONTYPE jsonType in Enum.GetValues(typeof(JSONTYPE)))
               {
                  if (typeString.Equals(jsonType.ToString()))
                  {
                     mJsonType = jsonType;
                  }
               }
            }
            ParseLinkedAliases(jsonString);
            ParseLinkedFiles(jsonString);
            ParseJsonSpecificData();
         } catch(Exception e)
         {
            AddError("Failed to load json file " + mPath + ". Error: " + e.Message);
         }
      }

      protected override void PostLoad()
      {
         if (mSaveJsonAfterParse)
         {
            TrySetFlatFileData(GetJsonFileString());
            //TrySaveFile();
            mSaveJsonAfterParse = false;
         }
      }

      public void AddMixin(string mixin)
      {
         JToken mixins = mJson.SelectToken("mixins");
         if (mixins == null)
         {
            mJson.AddFirst(new JProperty("mixins", mixin));
            mSaveJsonAfterParse = true;
            AddError("mixin added");
         } else
         {
            JArray mixinsArray = (mixins as JArray);
            if (mixinsArray == null)
            {
               string existingMixin = mixins.ToString();
               if (existingMixin != mixin)
               {
                  mixinsArray = new JArray();
                  mJson["mixins"] = mixinsArray;
                  mixinsArray.Add(mixins.ToString());
                  mSaveJsonAfterParse = true;
                  AddError("mixin added");
               }
            }
            if (mixinsArray != null) {
               HashSet<string> allMixins = new HashSet<string>();
               foreach(JToken property in mixinsArray.Children())
               {
                  allMixins.Add(property.ToString());
               }
               if (!allMixins.Contains(mixin))
               {
                  mSaveJsonAfterParse = true;
                  AddError("mixin added");
               }
               allMixins.Add(mixin);
               mixinsArray.Clear();
               foreach(string hashsetMixin in allMixins)
               {
                  mixinsArray.Add(hashsetMixin);
               }
            }
         }
      }

      private void CheckForNoNetWorth()
      {
         // check for errors
         JToken netWorthData = mJson.SelectToken("entity_data.stonehearth:net_worth");
         if (netWorthData == null)
         {
            if (!Directory.Contains("mixins"))
            {
               AddError("No net worth even though object is an item! Add an entity_data.stonehearth:net_worth!");
               JObject netWorth = JObject.Parse(StonehearthEditor.Properties.Resources.defaultNetWorth);
               JObject entityData = mJson["entity_data"] as JObject;
               if (entityData == null)
               {
                  entityData = new JObject();
                  mJson["entity_data"] = entityData;
               }
               entityData.Add("stonehearth:net_worth", netWorth);
               mSaveJsonAfterParse = true;
            }
         }
         else
         {
            //mNetWorth
            string netWorthString = netWorthData["value_in_gold"].ToString();
            if (!string.IsNullOrEmpty(netWorthString))
            {
               mNetWorth = int.Parse(netWorthString);
            }
         }
      }

      private void ParseJsonSpecificData()
      {
         string directory = Directory;
         switch (mJsonType)
         {
            case JSONTYPE.ENTITY:
               JToken entityFormsComponent = mJson.SelectToken("components.stonehearth:entity_forms");
               if (entityFormsComponent != null)
               {
                  // Look for stonehearth:entity_forms
                  JToken ghostForm = entityFormsComponent["ghost_form"];
                  if (ghostForm != null)
                  {
                     string ghostFilePath = JsonHelper.GetFileFromFileJson(ghostForm.ToString(), directory);
                     ghostFilePath = JsonHelper.NormalizeSystemPath(ghostFilePath);
                     JsonFileData ghost = new JsonFileData(ghostFilePath);
                     ghost.Load();
                     ghost.AddMixin("stonehearth:mixins:placed_object");
                     mOpenedFiles.Add(ghost);
                     ghost.PostLoad();
                  }
                  JToken iconicForm = entityFormsComponent["iconic_form"];
                  if (iconicForm != null)
                  {
                     string iconicFilePath = JsonHelper.GetFileFromFileJson(iconicForm.ToString(), directory);
                     iconicFilePath = JsonHelper.NormalizeSystemPath(iconicFilePath);
                     JsonFileData iconic = new JsonFileData(iconicFilePath);
                     iconic.Load();
                     mOpenedFiles.Add(iconic);
                  }
                  CheckForNoNetWorth();
               } else
               {
                  if (GetModuleFile() != null && mJson.SelectToken("components.item") != null)
                  {
                     CheckForNoNetWorth();
                  }
               }
               break;
            case JSONTYPE.JOB:
               // Parse crafter stuff
               JToken crafter = mJson["crafter"];
               if (crafter != null)
               {
                  // This is a crafter, load its recipes
                  string recipeListLocation = crafter["recipe_list"].ToString();
                  recipeListLocation = JsonHelper.GetFileFromFileJson(recipeListLocation, directory);
                  JsonFileData recipes = new JsonFileData(recipeListLocation);
                  recipes.Load();
                  foreach (FileData recipe in recipes.LinkedFileData.Values)
                  {
                     recipes.mRelatedFiles.Add(recipe);
                  }
                  mOpenedFiles.Add(recipes);
                  recipes.ReferencedByFileData[GetAliasOrFlatName()] = this;
               }
               break;
            case JSONTYPE.RECIPE:
               JToken portrait = mJson["portrait"];
               if (portrait != null)
               {
                  string portraitImageLocation = portrait.ToString();
                  portraitImageLocation = JsonHelper.GetFileFromFileJson(portraitImageLocation, directory);
                  ImageFileData image = new ImageFileData(portraitImageLocation);
                  mLinkedFileData.Add(portraitImageLocation, image);
               }

               break;
            case JSONTYPE.AI_PACK:
               JArray actions = mJson["actions"] as JArray;
               if (actions != null)
               {
                  foreach (JToken action in actions)
                  {
                     string fullAlias = action.ToString();
                     ModuleFile linkedAlias = ModuleDataManager.GetInstance().GetModuleFile(fullAlias);
                     if (linkedAlias == null)
                     {
                        AddError("links to alias " + fullAlias + " which does not exist!");
                     }
                  }
               }
               break;
         }
         CheckDisplayName();
         if (Json != null && Json.SelectToken("components.effect_list.effects") != null)
         {
            AddError("effect_list component is using 'effects' to specify a list of effects. This is bad because these effects will not restart after save load. You should put all the effects into a single file and reference that file as 'default'");
         }
      }

      private void CheckDisplayName()
      {
         // make sure display name appears before the description field
         JObject unitInfo = mJson.SelectToken("components.unit_info") as JObject;
         if (unitInfo != null && unitInfo["description"] != null && unitInfo["display_name"] != null)
         {
            List<JProperty> properties = new List<JProperty>(unitInfo.Properties());
            bool seenDisplayName = false;
            bool needsSort = true;
            int index = 0;

            foreach (JProperty prop in properties)
            {
               if (prop.Name == "description" && !seenDisplayName)
               {
                  AddError("display_name after description");
                  needsSort = true;
                  break;
               }
               if (prop.Name == "display_name")
               {
                  seenDisplayName = true;
               }
               index++;
            }
            JToken description = unitInfo["description"];
            JToken icon = unitInfo["icon"];
            JToken displayName = unitInfo["display_name"];
            if (needsSort)
            {
               unitInfo.Remove("description");
               unitInfo.Remove("icon");
               unitInfo.Add("description", description);
               if (icon != null)
               {
                  unitInfo.Add("icon", icon);
               }
               mSaveJsonAfterParse = true;
            }

            CheckStringKeyExists(description, "components.unit_info.description");
            CheckStringKeyExists(displayName, "components.unit_info.display_name");
         }

         // Check for display name and description in recipes
         switch(mJsonType)
         {
            case JSONTYPE.RECIPE:
               CheckStringKeyExists(mJson.SelectToken("recipe_name"), "recipe_name");
               CheckStringKeyExists(mJson.SelectToken("description"), "description");
               break;
            case JSONTYPE.BUFF:
               JToken invisibleToPlayer = mJson.SelectToken("invisible_to_player");
               bool isInvisible = invisibleToPlayer != null ? invisibleToPlayer.Value<Boolean>() : false;
               if (!isInvisible)
               {
                  CheckStringKeyExists(mJson.SelectToken("display_name"), "display_name");
                  CheckStringKeyExists(mJson.SelectToken("description"), "description");
               }
               break;
            case JSONTYPE.COMMAND:
               CheckStringKeyExists(mJson.SelectToken("display_name"), "display_name");
               CheckStringKeyExists(mJson.SelectToken("description"), "description");
               break;
         }
      }
      private void CheckStringKeyExists(JToken token, string tokenName)
      {
         if (token == null)
         {
            //AddError("The string for " + tokenName + " does not exist! Please add localization support");
            return;
         }
         string key = token.ToString();
         Regex matcher = new Regex(@"i18n\(([^)]+)\)");
         Match locMatch = matcher.Match(key);
         if (locMatch.Success)
         {
            key = locMatch.Groups[1].Value;
            if (!ModuleDataManager.GetInstance().HasLocalizationKey(key))
            {
               AddError("Localization Key Not Found! " + key + " is not in en.json");
            }
         } else
         {
            if (key.Length > 0)
            {
               AddError("The string for " + tokenName + " is '" + key + "', which is not a valid localization key. Please add localization support");
            }
         }
      }
      public string GetJsonFileString()
      {
         string jsonString = JsonHelper.GetFormattedJsonString(mJson);
         if (jsonString == null) {
            Console.WriteLine("Could not convert " + mPath + " to json string");
         }
         return jsonString != null ? jsonString : "INVALID JSON";
      }

      private void ParseLinkedFiles(string jsonString)
      {
         string directory = Directory;
         Regex matcher = new Regex("file\\([\\S]+\\)");
         foreach (Match match in matcher.Matches(jsonString))
         {
            string matchValue = match.Value;
            if (matchValue != "file(animations)" && matchValue != "file(effects)") // Sigh, special case these because they're more like folders instead of files
            {
               string linkedFile = JsonHelper.GetFileFromFileJson(match.Value, directory);
               linkedFile = JsonHelper.NormalizeSystemPath(linkedFile);

               if (!System.IO.File.Exists(linkedFile) && !System.IO.Directory.Exists(linkedFile))
               {
                  AddError("Links to non-existent file " + linkedFile);
                  continue;
               }
               if (mLinkedFileData.ContainsKey(linkedFile))
               {
                  continue;
               }
               FileData linkedFileData = GetFileDataFactory(linkedFile);
               if (linkedFileData != null)
               {
                  mLinkedFileData.Add(linkedFile, linkedFileData);
                  linkedFileData.ReferencedByFileData[GetAliasOrFlatName()] = this;
               }
            }
         }
      }
      public override void AddError(string error)
      {
         base.AddError(error);
         switch(mJsonType)
         {
            case JSONTYPE.ENCOUNTER:
               return;
         }
         Console.WriteLine(error);
         ModuleDataManager.GetInstance().AddErrorFile(this);
      }

      private FileData GetFileDataFactory(string path)
      {
         string extension = System.IO.Path.GetExtension(path);
         switch(extension)
         {
            case ".qb":
               QubicleFileData qubicleFile = new QubicleFileData(path);
               qubicleFile.AddLinkingJsonFile(this);
               qubicleFile.RelatedFiles.Add(this);
               qubicleFile.Load();
               return qubicleFile;
            case ".png":
               ImageFileData imageFile = new ImageFileData(path);
               imageFile.AddLinkingJsonFile(this);
               imageFile.RelatedFiles.Add(this);
               return imageFile;
            case ".json":
               JsonFileData jsonFileData = new JsonFileData(path);
               jsonFileData.Load();
               jsonFileData.RelatedFiles.Add(this);
               return jsonFileData;
         }
         return null;
      }

      private string GetAliasOrFlatName()
      {
         ModuleFile moduleFile = GetModuleFile();
         string flatPath = mPath.Replace(ModuleDataManager.GetInstance().ModsDirectoryPath, "");
         return (moduleFile != null) ? moduleFile.FullAlias : flatPath;
      }

      private void ParseLinkedAliases(string jsonString)
      {
         Regex matcher = new Regex("\"([A-z|_|-]+\\:[\\S]*)\"");
         foreach (Match match in matcher.Matches(jsonString))
         {
            string fullAlias = match.Groups[1].Value;
            ModuleFile linkedAlias = ModuleDataManager.GetInstance().GetModuleFile(fullAlias);
            if (linkedAlias == null)
            {
               continue;
            }
            mLinkedAliases.Add(linkedAlias);
            linkedAlias.AddReference(GetAliasOrFlatName(), this);
         }
      }
      protected override bool TryChangeFlatFileData(string newData, out string newFlatFileData)
      {
         try
         {
            JObject json = JObject.Parse(newData);
            newFlatFileData = JsonHelper.GetFormattedJsonString(json);
         }
         catch(Exception e)
         {
            MessageBox.Show("Unable to change flat file data. Invalid Json: " + e.Message);
            newFlatFileData = null;
            return false;
         }
         return true;
      }

      public override bool HasErrors
      {
         get
         {
            if (base.HasErrors)
            {
               return true;
            }

            foreach(FileData file in mOpenedFiles)
            {
               if (file.Errors != null)
               {
                  return true;
               }
            }

            return false;
         }
      }

      // Returns true if should show parent node
      public override bool UpdateTreeNode(TreeNode node, string filter)
      {
         base.UpdateTreeNode(node, filter);
         mTreeNode = node;
         node.Tag = this;

         if (!HasErrors)
         {
            node.SelectedImageIndex = (int)JsonType;
            node.ImageIndex = (int)JsonType;
         }

         bool filterMatchesSelf = true;
         ModuleFile owner = GetModuleFile();
         if (!string.IsNullOrEmpty(filter) && owner != null && !owner.Name.Contains(filter))
         {
            filterMatchesSelf = false;
         }

         bool hasChildMatchingFilter = false;
         if (JsonType == JSONTYPE.JOB)
         {
            if (mOpenedFiles.Count > 1)
            {
               FileData recipeJsonData = mOpenedFiles[1];
               TreeNode recipes = new TreeNode(recipeJsonData.FileName);
               recipeJsonData.UpdateTreeNode(recipes, filter);

               foreach (KeyValuePair<string, FileData> recipe in recipeJsonData.LinkedFileData)
               {
                  string recipePath = recipe.Key;
                  string recipeName = System.IO.Path.GetFileNameWithoutExtension(recipePath);
                  if (string.IsNullOrEmpty(filter) || recipeName.Contains(filter) || filterMatchesSelf)
                  {
                     TreeNode recipeNode = new TreeNode(recipeName);
                     recipe.Value.UpdateTreeNode(recipeNode, filter);
                     recipes.Nodes.Add(recipeNode);
                     hasChildMatchingFilter = true;
                  }
               }
               node.Nodes.Add(recipes);
            }
         }

         if (!hasChildMatchingFilter && !filterMatchesSelf)
         {
            if (!filter.Contains("error") || !HasErrors)
            {
               return false;
            }
         }
         
         return true;
      }

      public override bool Clone(string newPath, CloneObjectParameters parameters, HashSet<string> alreadyCloned, bool execute)
      {
         if (JsonType == JSONTYPE.RECIPE)
         {
            string newNameToUse = parameters.TransformParameter(GetNameForCloning()).Replace("_recipe", "");
            if (execute)
            {
               JsonFileData recipesList = mRelatedFiles[mRelatedFiles.Count - 1] as JsonFileData;
               JObject json = recipesList.mJson;
               JToken foundParent = null;
               foreach (JToken token in json["craftable_recipes"].Children())
               {
                  if (foundParent != null)
                  {
                     break;
                  }
                  foreach (JToken recipe in token.First["recipes"].Children())
                  {
                     if (recipe.Last.ToString().Contains(FileName))
                     {
                        foundParent = token.First["recipes"];
                        break;
                     }
                  }
               }
               if (foundParent != null)
               {
                  string recipeFileName = System.IO.Path.GetFileName(newPath);
                  (foundParent as JObject).Add(newNameToUse, JObject.Parse("{\"recipe\": \"file(" + recipeFileName + ")\"}"));
                  recipesList.TrySetFlatFileData(recipesList.GetJsonFileString());
                  recipesList.TrySaveFile();
               }
            }
         }
         return base.Clone(newPath, parameters, alreadyCloned, execute);
      }

      public override bool ShouldCloneDependency(string dependencyName, CloneObjectParameters parameters)
      {
         if (JsonType == JSONTYPE.RECIPE)
         {
            JToken produces = mJson["produces"];
            if (produces != null)
            {
               foreach (JToken child in produces.Children())
               {
                  if (child["item"] != null && child["item"].ToString().Equals(dependencyName))
                  {
                     return true;
                  }
               }
            }
         }
         return base.ShouldCloneDependency(dependencyName, parameters);
      }

      public override string GetNameForCloning()
      {
         string fileName = FileName;
         switch(JsonType)
         {
            case JSONTYPE.RECIPE:
               fileName = fileName.Replace("_recipe", "");
               break;
            case JSONTYPE.JOB:
               fileName = fileName.Replace("_description", "");
               break;
         }
         return fileName;
      }

      public void SetModuleFile(ModuleFile moduleFile)
      {
         mOwner = moduleFile;
      }

      public ModuleFile GetModuleFile()
      {
         return mOwner;
      }

      public JSONTYPE JsonType
      {
         get { return mJsonType; }
      }
      public string Directory
      {
         get { return mDirectory; }
      }
      public JObject Json
      {
         get { return mJson; }
      }

      public int NetWorth
      {
         get { return mNetWorth; }
      }
   }
}
