using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
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
        private IPlayer player;
        private Rectangle collisionRect;

        public FlipEnemyCommand(IEnemy enemy, IPlayer player, Rectangle collisionRect)
        {
            this.enemy = enemy;
            this.player = player;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            enemy.TakeFireballDamage();
        }
    }
}
