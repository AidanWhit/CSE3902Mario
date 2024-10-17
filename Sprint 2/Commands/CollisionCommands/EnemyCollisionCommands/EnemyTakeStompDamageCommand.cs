using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class EnemyTakeStompDamageCommand : ICommands
    {
        private IEnemy enemy;
        private IPlayer player;
        private Rectangle collisionRectangle;
        
        public EnemyTakeStompDamageCommand(IEnemy enemy,  IPlayer player, Rectangle collisionRectangle)
        {
            this.enemy = enemy;
            this.player = player;
            this.collisionRectangle = collisionRectangle;
        }

        public void Execute()
        {
            enemy.TakeStompDamage();
        }
       
    }
}
