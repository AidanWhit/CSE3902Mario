using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioMovementCommands
{
    public class MarioOnCrouchRelease : ICommands
    {
        private Player mario;

        public MarioOnCrouchRelease(Player mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.releaseCrouch();
            mario.Idle();
        }
    }
}
