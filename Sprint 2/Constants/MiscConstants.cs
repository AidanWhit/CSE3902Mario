using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Sprint_2.Constants
{
    public static class MiscConstants
    {
        public static float cameraSmoothingFactor = 0.1f;

        public static Vector2 leftBorderSize = new Vector2(16, 240);
        public static Vector2 leftBorderPosition = new Vector2(0, 240);
        public static float cameraViewPortWidthScale = 8f;
        public static Matrix cameraScale = Matrix.CreateScale(2f, 2f, 1f);

        public static Dictionary<(int, int), int> flagPoints = new Dictionary<(int, int), int>() 
        {
            {(1, 26), 4000 },
            {(26, 71), 2000 },
            {(71, 94), 800 },
            {(94, 133), 400 },
            {(134, 150), 100 }
        };
        public static int maxFlagScore = 5000;
        public static Vector2 levelBounds = new Vector2(3744, 240);

        public static int powerUpPoints = 1000;
        public static int coinPoints = 200;

        public const int blockHeightChange = -2;
        public const int blockTotalHeightChange = 6;



    }
}
