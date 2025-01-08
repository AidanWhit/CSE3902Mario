using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
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
            IItem Star = new Star(block.Position, block.GetHitBox().Top);
            
            GameObjectManager.Instance.Updateables.Add(Star);
            GameObjectManager.Instance.Drawables.Add(Star);
            block.ChangeState(new UsedBlockState(block));

        }
    }
}
