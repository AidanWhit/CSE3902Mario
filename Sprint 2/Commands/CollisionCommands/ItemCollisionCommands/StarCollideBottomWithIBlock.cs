using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class StarCollideBottomWithIBlock : ICommands
    {
        private Star star;
        private IBlock block;
        private Rectangle collisionRect;

        public StarCollideBottomWithIBlock(Star star, IBlock block, Rectangle collisionRect)
        {
            this.star = star;
            this.block = block;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            star.YPos += collisionRect.Height;
            star.Velocity = new Vector2(star.Velocity.X, 0);
        }


    }
}
