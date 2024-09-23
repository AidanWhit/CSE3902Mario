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

namespace Sprint_0.Commands.MarioAttackCommands
{
    public class MarioHurtCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioHurtCommand(Game1 game, Player mario)
        {
            myGame = game;
            this.mario = mario;
        }

        public void Execute()
        {
            mario.Damage();
        }
    }
}
