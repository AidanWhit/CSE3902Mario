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
    public class MarioAttackNormalCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioAttackNormalCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            mario.ShootFireball();
        }
    }
}
