using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public class MarioPhysicsConstants
    {
        public static Vector2 marioXVelocity = new Vector2(12f, 0);
        //Jump Velocity is negative because y=0 is at the top of the screen
        public static Vector2 marioJumpVelocity = new Vector2(0, -15f);
        public static Vector2 marioFallVelocity = new Vector2(0, 20f);

        public static float velocityDecay = 0.965f;

        public static float maxXVelocity = 450f;
        public static float maxJumpVelocity = -600f;
        public static float maxFallVelocity = 600f;

        public static int maxJumpHeight = 200;



    }
}
