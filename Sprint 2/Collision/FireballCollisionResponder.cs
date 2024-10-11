using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Collision
{
    public class FireballCollisionResponder
    {
        public static void FireballResponderForEnemies(IProjectile fireball, IEnemy enemy)
        {
            enemy.TakeFireballDamage();
            fireball.ChangeSprite(MarioSpriteFactory.Instance.FireballExplosion());
            fireball.EnteredExplosionState = true;
        }
    }
}
