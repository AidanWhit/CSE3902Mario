using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BlueGroundState : BlockState
    {
        public BlueGroundState (IBlock block) : base(block)
        {
            sprite = BlockFactory.Instance.GetBlock("BlueGround");
        }

        public override void BeHit(IPlayer player)
        {
            //Do nothing
        }
    }
}
