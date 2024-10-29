using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class EnterPipeFromRight : ICommands
    {
        private IPlayer player;
        private ICollideable collideable;
        private Rectangle collisionRect;

        public EnterPipeFromRight(IPlayer player, ICollideable collideable, Rectangle collisionRect)
        {
            this.player = player;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            Debug.WriteLine("Entered Pipe!");
        }
    }
}
