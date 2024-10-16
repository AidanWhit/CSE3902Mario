using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BlueBrickState : BlockState
    {
        private IBlock block;
        private int originalBlockY;
        public BlueBrickState(IBlock block) : base(block) 
        {
            this.block = block;
            sprite = BlockFactory.Instance.GetBlock("BlueBrick");

            originalBlockY = (int)block.Position.Y;
        }

        public override void BeHit(IPlayer player)
        {
            /* Little mario hit the block */
            if (player.GetHealth().Equals("Mario"))
            {
                /* Make the block move up and then down */
                Hit = true;
                originalBlockY = (int)block.Position.Y;
            }
            /* SuperMario/Fire Mario hit the block*/
            else
            {
                int column = (int)block.Position.X / 16;
                /* Call remove object on gameobject manager to remove the block from being able to be drawn/updated */
                BlockFactory.Instance.RemoveBlockFromList(block, column);

            }
        }
    }
}
