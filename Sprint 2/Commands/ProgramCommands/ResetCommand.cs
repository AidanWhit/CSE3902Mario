using Sprint_0.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Commands.ProgramCommands
{
    public class ResetCommand : ICommands
    {
        private Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Reload();
        }
    }
}
