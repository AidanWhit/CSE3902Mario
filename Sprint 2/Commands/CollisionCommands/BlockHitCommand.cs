using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands
{
    public class BlockHitCommand : ICommands
    {
        private IBlock block;
        private IPlayer player;

        public BlockHitCommand(IBlock block, IPlayer player, Rectangle rect)
        {
            this.block = block;
            this.player = player;
        }

        public void Execute() 
        {
            
            block.BeHit(player);
        }
    }
}
