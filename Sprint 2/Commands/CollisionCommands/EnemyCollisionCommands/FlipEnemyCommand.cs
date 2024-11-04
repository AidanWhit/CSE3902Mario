using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class FlipEnemyCommand : ICommands
    {
        private IEnemy enemy;
        private ICollideable collider;
        private Rectangle collisionRect;

        public FlipEnemyCommand(IEnemy enemy, ICollideable collider, Rectangle collisionRect)
        {
            this.enemy = enemy;
            this.collider = collider;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            if (collider is StarMario || collider is Shell)
            {

            }
            else
            {
                HUD.Instance.AddScorePopUp(200, new Vector2(enemy.XPos, enemy.YPos));
            }
            enemy.TakeFireballDamage();
        }
    }
}
