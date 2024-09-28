using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.BlockCommands
{
    public class CycleBlockLeftCommand : ICommands
    {
        private Game1 myGame;

        public CycleBlockLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.CycleBlockLeft();
        }
    }
}
