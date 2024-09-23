using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.MarioItemCommands
{
    public class MarioItem3Command : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioItem3Command(Game1 game, Player mario)
        {
            myGame = game;
            this.mario = mario;
        }

        public void Execute()
        {
            mario.PowerUp();
        }
    }
}
