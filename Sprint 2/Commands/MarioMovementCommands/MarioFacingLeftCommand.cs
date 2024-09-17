using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Sprint_0.Sprites;
using Sprint_2.Sprites;

namespace Sprint_0.Commands.MarioMovementCommands
{
    public class MarioFacingLeftCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioFacingLeftCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            mario.State.MoveLeft();
        }
    }
}
