using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Constants
{
    public class EnemyConstants
    {
        public static float moveSpeed = 1f;
        public static float maxFallVelocity = 300f;
        public static Vector2 fallVelocity = new Vector2(0, 9);
        public static Vector2 flippedVelocity = new Vector2(0, -150f);

        public static float despawnHeight = 650;

        public static float shellMoveSpeed = 200f;
    }
}
