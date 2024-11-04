using Microsoft.Xna.Framework;
using System;

namespace Sprint_2.Constants
{
    public static class MiscConstants
    {
        public static float cameraSmoothingFactor = 0.1f;

        public static Vector2 leftBorderSize = new Vector2(16, 240);
        public static Vector2 leftBorderPosition = new Vector2(0, 240);
        public static float cameraViewPortWidthScale = 8f;
        public static Matrix cameraScale = Matrix.CreateScale(2f, 2f, 1f);
    }
}
