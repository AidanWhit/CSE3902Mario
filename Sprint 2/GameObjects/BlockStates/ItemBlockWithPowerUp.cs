using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class ItemBlockWithPowerUp : BlockState
    {
        private IBlock block;

        public ItemBlockWithPowerUp(IBlock block) : base(block)
        {
            this.block = block;

            sprite = BlockFactory.Instance.GetBlock("Question");
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;
            string health = player.GetHealth();
            if (health.Equals("Mario"))
            {
                ItemFactory.Instance.AddRedMushroomToItemsList(block.Position, block);
            }
            else
            {
                ItemFactory.Instance.AddFireFlowerToItemsList(block.Position);
            }
            block.ChangeState(new UsedBlockState(block));

        }
    }
}
