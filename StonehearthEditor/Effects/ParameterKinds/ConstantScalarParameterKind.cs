using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonehearthEditor.Effects.ParameterKinds
{
   [ParameterKind("CONSTANT", Dimension.Scalar, false)]
   public sealed class ConstantScalarParameterKind : ParameterKind
   {
      public double? Value { get; set; }

      public static ConstantScalarParameterKind FromJson(JToken json)
      {
         return new ConstantScalarParameterKind((double)json);
      }

      public ConstantScalarParameterKind(double? value)
      {
         this.Value = value;
      }

      public override JToken ToJson()
      {
         return this.Value;
      }

      public override bool IsValid
      {
         get
         {
            return Value != null;
         }
      }
   }
}
