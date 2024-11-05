using Microsoft.Xna.Framework;
using Sprint_2.GameObjects;
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
            if (collider is StarMario)
            {
                HUD.Instance.AddScorePopUp(100, new Vector2(enemy.XPos, enemy.YPos));
            }
            else if (collider is FireBall)
            {
                HUD.Instance.AddScorePopUp(200, new Vector2(enemy.XPos, enemy.YPos));
            }
            else
            {
                // Collider is a moving shell
                Shell shell = (Shell) collider;
                HUD.Instance.AddScorePopUp(shell.GetScore(), new Vector2(enemy.XPos, enemy.YPos));
                
            }
            enemy.TakeFireballDamage();
        }
    }
}
