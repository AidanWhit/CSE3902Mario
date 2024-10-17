using Sprint_2.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollideRightCommand : ICommands
    {
        private IPlayer mario;
        private int width;
        public MarioCollideRightCommand(IPlayer player, ICollideable block, Rectangle collisionIntersection)
        {
            mario = player;
            width = collisionIntersection.Width;
        }

        public void Execute()
        {
            mario.XPos -= width;
        }
    }
}
