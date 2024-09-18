using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_0.Commands.MarioMovementCommands
{
    public class MarioFacingDownCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioFacingDownCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            mario.Crouch();
        }
    }
}
