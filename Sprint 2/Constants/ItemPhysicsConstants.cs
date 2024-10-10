using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public static class ItemPhysicsConstants
    {
        public static float maxFallVelocity = 300f;
        public static Vector2 fallVelocity = new Vector2(0, 20);
        public static float bounceVelocity = -500f;
    }
}
