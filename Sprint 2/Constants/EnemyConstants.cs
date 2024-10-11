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
        public static float moveSpeed = 2f;
        public static float maxFallVelocity = 300f;
        public static Vector2 fallVelocity = new Vector2(0, 20);
        public static Vector2 flippedVelocity = new Vector2(0, -350f);

        public static float despawnHeight = 650;

        public static float shellMoveSpeed = 300f;
    }
}
