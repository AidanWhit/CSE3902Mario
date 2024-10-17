﻿using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.EnemyCollisionCommands
{
    public class EnemyCollideRightWithIBlock : ICommands
    {
        private IEnemy enemy;
        private IBlock block;
        private Rectangle collisionRect;

        public EnemyCollideRightWithIBlock(IEnemy enemy, IBlock block, Rectangle collisionRect)
        {
            this.enemy = enemy;
            this.block = block;
            this.collisionRect = collisionRect;
        }

        public void Execute() 
        {
            enemy.XPos -= collisionRect.Width;
            enemy.ChangeDirection();
        }
    }
}
