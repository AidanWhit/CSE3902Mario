using Microsoft.Xna.Framework;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
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
                IItem mushroom = new RedMushroom(block.Position, block);
                GameObjectManager.Instance.Updateables.Add(mushroom);
                GameObjectManager.Instance.Drawables.Add(mushroom);
                GameObjectManager.Instance.Movers.Add(mushroom);
            }
            else
            {
                IItem flower = new Flower(block.Position, block);
                GameObjectManager.Instance.Updateables.Add(flower);
                GameObjectManager.Instance.Drawables.Add(flower);
                GameObjectManager.Instance.Static.Add(flower);
            }
            block.ChangeState(new UsedBlockState(block));

        }
    }
}
