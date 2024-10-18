using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Sprint_2.Commands.MarioItemCommands
{
    public class MarioPowerUpCommand : ICommands
    {
        private IPlayer mario;

        public MarioPowerUpCommand(IPlayer mario, IItem item, Rectangle collisionRect)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.PowerUp();
        }
    }
}
