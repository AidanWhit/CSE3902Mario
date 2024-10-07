using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BrownBrickWithCoins : BlockState
    {
        private IBlock block;
        private int coins;

        public BrownBrickWithCoins(IBlock block, int coins) : base(block)
        {
            this.block = block;
            this.coins = coins;

            base.sprite = BlockFactory.Instance.GetBlock("BrownBrick");
        }


        public override void BeHit(IPlayer player)
        {
            Hit = true;
            /* Game Object manager add coin */
            ItemFactory.Instance.AddCoinToItemsList(new Vector2(block.Position.X - 5, block.Position.Y - block.GetHitBox().Height));
            if (--coins == 0)
            {
                block.ChangeState(new UsedBlockState(block));
            }
        }

    }
}
