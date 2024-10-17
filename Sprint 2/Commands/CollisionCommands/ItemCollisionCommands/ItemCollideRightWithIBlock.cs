using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class ItemCollideRightWithIBlock : ICommands
    {
        private IBlock block;
        private IItem item;
        private Rectangle collisionIntersection;

        public ItemCollideRightWithIBlock(IItem item, IBlock block,  Rectangle collisionIntersection)
        {
            this.block = block;
            this.item = item;
            this.collisionIntersection = collisionIntersection;
        }

        public void Execute()
        {
            item.XPos += collisionIntersection.Width;
            item.ChangeDirection();
        }
    }
}
