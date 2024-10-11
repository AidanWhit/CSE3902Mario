using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public class FireBallConstants
    {
        public static int scale = 3;
        
        public static Vector2 moveSpeed = new Vector2(0.1f,0); 

        public static float XSpeed = 200f;
        public static float maxFallSpeed = 600f;
        public static Vector2 fallSpeed = new Vector2(0, 20);

        public static float bounceSpeed = -400f;

        public static float animationDelay = 0.1f;
        public static int explosionRange = 700;

    }
}
