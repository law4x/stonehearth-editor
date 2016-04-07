using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace StonehearthEditor.Effects
{
   public sealed class ParameterProperty : Property
   {
      private readonly string name;

      public ParameterProperty(
         string name,
         Dimension dimension = Dimension.Scalar,
         bool optional = true,
         bool timeVarying = false)
      {
         this.name = name;
         this.Dimension = dimension;
         this.Optional = optional;
         this.TimeVarying = timeVarying;
      }

      public Dimension Dimension { get; private set; }
      public bool Optional { get; private set; }
      public bool TimeVarying { get; private set; }

      public override string Name
      {
         get
         {
            return this.name;
         }
      }

      public override PropertyValue FromJson(JToken json)
      {
         return new DummyParameterPropertyValue(json);
      }

      public override JToken ToJson(PropertyValue value)
      {
         return ((DummyParameterPropertyValue)value).Json;
      }
   }

   public sealed class DummyParameterPropertyValue : PropertyValue
   {
      public JToken Json { get; set; }

      public DummyParameterPropertyValue(JToken json)
      {
         this.Json = json;
      }

      public override bool IsValid()
      {
         return true;
      }

      public override bool IsMissing
      {
         get
         {
            return Json == null;
         }
      }
   }
}
