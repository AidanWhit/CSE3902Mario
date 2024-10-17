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
            IItem mushroom = new GreenMushroom(block.Position, block);
            GameObjectManager.Instance.Updateables.Add(mushroom);
            GameObjectManager.Instance.Drawables.Add(mushroom);
            GameObjectManager.Instance.Movers.Add(mushroom);
        }
    }
}
