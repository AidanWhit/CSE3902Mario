using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    public class UsedBlockState : BlockState
    {
        private IBlock block;
        public UsedBlockState(IBlock block) : base(block)
        {
           
            this.block = block;
            base.sprite = BlockFactory.Instance.GetBlock("Hit");

            Hit = true;
        }

        public override void BeHit(IPlayer player)
        {
            
        }

    }
}
