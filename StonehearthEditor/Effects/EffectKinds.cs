﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonehearthEditor.Effects
{
   public static class EffectKinds
   {
      public static readonly Property CubeEmitter = new ComplexProperty(null, false,
         new StringProperty("name"),
         new IntProperty("duration"),
         new ComplexProperty("particle", false,
            new ComplexProperty("lifetime", true,
               new ParameterProperty("start", Dimension.Scalar)
            ),
            new ComplexProperty("speed", true,
               new ParameterProperty("start", Dimension.Scalar),
               new ParameterProperty("over_lifetime", Dimension.Scalar, timeVarying: true)
            ),
            new ComplexProperty("acceleration", true,
               new ParameterProperty("over_lifetime_x", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_y", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_z", Dimension.Scalar, timeVarying: true)
            ),
            new ComplexProperty("color", true,
               new ParameterProperty("start", Dimension.Rgba),
               new ParameterProperty("over_lifetime_a", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_r", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_g", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_b", Dimension.Scalar, timeVarying: true)
            ),
            new ComplexProperty("scale", true,
               new ParameterProperty("start", Dimension.Scalar),
               new ParameterProperty("over_lifetime", Dimension.Scalar, timeVarying: true)
            ),
            new ComplexProperty("rotation", true,
               new ParameterProperty("over_lifetime_x", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_y", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_z", Dimension.Scalar, timeVarying: true)
            ),
            new ComplexProperty("velocity", true,
               new ParameterProperty("over_lifetime_x", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_y", Dimension.Scalar, timeVarying: true),
               new ParameterProperty("over_lifetime_z", Dimension.Scalar, timeVarying: true)
            )
         ),
         new ComplexProperty("emission", false,
               new ParameterProperty("rate", Dimension.Scalar, optional: false),
               new ParameterProperty("angle", Dimension.Scalar, optional: false),
               new OriginProperty("origin")
         )
       );
   }
}
