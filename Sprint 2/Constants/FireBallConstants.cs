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
        
        public static Vector2 moveSpeed = new Vector2(0.1f,0); //Use this to scale the YPos 
        //Then have a separate speed to dictate how fast the fireball should move across the screen
        public static float animationDelay = 0.1f;
        public static int explosionRange = 300;

    }
}
