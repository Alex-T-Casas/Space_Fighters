using MathNet.Spatial.Euclidean;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFighters
{
    public static class MathLib
    {
        public static float RotationFromVector(Vector2f vector)
        {
            Vector2D newVector = new Vector2D(vector.X, vector.Y);
            return (float)newVector.SignedAngleTo(new Vector2D(0, -1), true).Degrees;
        }
    }
}
