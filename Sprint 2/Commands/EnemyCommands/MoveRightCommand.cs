using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;

using Sprint_0.Sprites.EnemySprites;

using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_0.Commands.EnemyCommands
{
    public class MoveRightCommand : ICommands
    {
        private Koopa koopa;

        public MoveRightCommand(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void Execute()
        {
            koopa.MoveRight(); // Switches Koopa's direction to right
        }
    }
}

