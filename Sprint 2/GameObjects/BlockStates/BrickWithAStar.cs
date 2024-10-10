using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BrickWithAStar : BlockState
    {
        private IBlock block;
        public BrickWithAStar(IBlock block) : base(block)
        {
            this.block = block;
            sprite = BlockFactory.Instance.GetBlock("BrownBrick");
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            ItemFactory.Instance.AddStarToItemsList(block.Position, block);
            block.ChangeState(new UsedBlockState(block));

        }
    }
}
