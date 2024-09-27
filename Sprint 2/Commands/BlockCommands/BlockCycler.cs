using Sprint_2.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_2.Commands.EnemyCommands
{
    public class BlockCycler
    {
        private List<IBlock> blocks;
        private int currIndex;

        public BlockCycler(List<IBlock> blocks)
        {
            this.blocks = blocks;
            currIndex = 0;
        }

        // Methods to cycle enemies
        public IBlock CycleBlockLeft()
        {
            currIndex = (currIndex - 1 + blocks.Count) % blocks.Count;
            return blocks[currIndex];
        }

        public IBlock CycleBlockRight()
        {
            currIndex = (currIndex + 1) % blocks.Count;
            return blocks[currIndex];
        }
    }
}
