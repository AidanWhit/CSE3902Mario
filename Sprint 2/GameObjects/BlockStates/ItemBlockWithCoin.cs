using Microsoft.Xna.Framework;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class ItemBlockWithCoin : BlockState
    {
        private IBlock block;
        public ItemBlockWithCoin(IBlock block) : base(block) 
        {
            this.block = block;
            sprite = BlockFactory.Instance.GetBlock("Question");
        }

        public override void BeHit(IPlayer player)
        {
            Hit = true;

            ItemFactory.Instance.AddCoinToItemsList(new Vector2(block.Position.X - 5, block.Position.Y - block.GetHitBox().Height));
            block.ChangeState(new UsedBlockState(block));
        }
    }
}
