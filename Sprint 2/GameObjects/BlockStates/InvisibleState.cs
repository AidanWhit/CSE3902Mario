using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class InvisibleState : BlockState
    {
        private IBlock block;
        public InvisibleState(IBlock block) : base(block) 
        {
            this.block = block;
            sprite = BlockFactory.Instance.GetBlock("Invisible");
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            block.ChangeState(new UsedBlockState(block));
            ItemFactory.Instance.AddGreenMushroomToItemsList(block.Position, block);
        }
    }
}
