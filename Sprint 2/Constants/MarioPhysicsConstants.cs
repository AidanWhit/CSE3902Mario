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
        public static Vector2 marioXVelocity = new Vector2(8f, 0);
        //Jump Velocity is negative because y=0 is at the top of the screen
        public static Vector2 marioJumpVelocity = new Vector2(0, -15f);
        public static Vector2 marioFallVelocity = new Vector2(0, 1f);

        public static float velocityDecay = 0.985f;
        public static float maxXVelocity = 450f;
        public static float maxJumpVelocity = -600f;
        public static float maxFallVelocity = 500f;

        public static int maxJumpHeight = 200;



    }
}
