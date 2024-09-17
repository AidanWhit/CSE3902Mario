using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Sprites;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_0.Commands.MarioMovementCommands
{
    public class MarioFacingUpCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioFacingUpCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            //Testing Movement ~ Aidan Whitlatch
           //Debug.WriteLine("Entered Jump Command");
            //mario.PhysicsState = new Jumping(mario);
            mario.State.Jump();
        }
    }
}
