using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using StonehearthEditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace StonehearthEditor
{
   public interface IGraphOwner
   {
      void SetGraph(Microsoft.Msagl.Drawing.Graph graph);
   }

   public partial class MainForm : Form
   {
      public static string kModsDirectoryPath;

      private NetWorthVisualizer mNetWorthVisualizer;

      private HashSet<TabPage> loadedTabs = new HashSet<TabPage>();

      public MainForm(string path)
      {
         path = path.Trim();
         kModsDirectoryPath = JsonHelper.NormalizeSystemPath(path);
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         if (string.IsNullOrWhiteSpace(kModsDirectoryPath))
         {
            chooseModDirectory();
         }
         int initialTab = (int)Properties.Settings.Default["InitialTab"];
         tabControl.SelectedIndex = initialTab;
         EnsureTabLoaded(tabControl.SelectedTab);

         if (Properties.Settings.Default.MainFormSize != null)
         {
            this.Size = Properties.Settings.Default.MainFormSize;
         }
      }

      private void EnsureTabLoaded(TabPage tab)
      {
         if (loadedTabs.Contains(tab))
         {
            return;
         }

         loadedTabs.Add(tab);

         if (tab == manifestTab)
         {
            manifestView.Initialize();
         }
         else if (tab == encounterTab)
         {
            encounterDesignerView.Initialize();
         }
         else if (tab == entityBrowserTab)
         {
            entityBrowserView.Initialize();
         }
         else if (tab == effectsEditorTab)
         {
            effectsEditorView.Initialize();
         }
      }

      private void tabControl_Selected(object sender, TabControlEventArgs e)
      {
         Properties.Settings.Default["InitialTab"] = e.TabPageIndex;
         Properties.Settings.Default.Save();

         EnsureTabLoaded(e.TabPage);
      }

      private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //TODO yshan: revisit this
         GameMasterDataManager.GetInstance().SaveModifiedFiles();
      }

      private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Reload();
      }

      public void Reload()
      {
         manifestView.Reload();
         entityBrowserView.Reload();
         effectsEditorView.Reload();
         encounterDesignerView.Reload();
         if (mNetWorthVisualizer != null && !mNetWorthVisualizer.IsDisposed)
         {
            mNetWorthVisualizer.UpdateNetWorthData();
         }
      }

      private void MainForm_Resize(object sender, EventArgs e)
      {
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         // Copy window size to app settings
         if (this.WindowState == FormWindowState.Normal)
         {
            Settings.Default.MainFormSize = this.Size;
         }
         else
         {
            Settings.Default.MainFormSize = this.RestoreBounds.Size;
         }
         Properties.Settings.Default.Save();
      }

      private void netWorthVisualizerToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (mNetWorthVisualizer != null && !mNetWorthVisualizer.IsDisposed)
         {
            mNetWorthVisualizer.UpdateNetWorthData();
            return;
         }
         mNetWorthVisualizer = new NetWorthVisualizer();
         mNetWorthVisualizer.SetManifestView(manifestView);
         //mNetWorthVisualizer.UpdateNetWorthData();
         mNetWorthVisualizer.Show(this);
      }

      private void chooseModDirectory()
      {
         DialogResult result = modsFolderBrowserDialog.ShowDialog();

         if (result == DialogResult.OK)
         {
            string newPath = modsFolderBrowserDialog.SelectedPath;
            if (!string.IsNullOrWhiteSpace(newPath))
            {
               kModsDirectoryPath = modsFolderBrowserDialog.SelectedPath;
               Properties.Settings.Default["ModsDirectory"] = kModsDirectoryPath;
               Properties.Settings.Default.Save();
            }
            else
            {
               MessageBox.Show("invalid mods directory");
               return;
            }
         }
         else
         {
            MessageBox.Show("invalid mods directory");
            return;
         }
      }

      private void changeModDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
      {
         chooseModDirectory();
      }
   }
}
