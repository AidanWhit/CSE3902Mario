using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static float shellMoveSpeed = 150f;

        public static float distUntilBehaviorStarts = 300;

        public static float timeUntilShellBecomesKoopa = 5f;

        public static float stompTimer = 0.75f;

        public static int pointsFromFireball = 200;
        public static int pointsFromStarMario = 100;
        public static int kickShellPoints = 400;

        public static readonly int[] shellScoreValues = new int[] { 500, 800, 1000, 2000, 4000, 5000, 8000 };
    }
}
