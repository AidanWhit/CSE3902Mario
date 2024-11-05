using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sprint_2.Sound;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;

namespace Sprint_2.GameObjects.BlockStates
{
    public class UsedBlockState : BlockState
    {
        private IBlock block;
        public UsedBlockState(IBlock block) : base(block)
        {
           
            this.block = block;
            sprite = UniversalSpriteFactory.Instance.GetBlock(NamesOfSprites.SpriteNames.Hit.ToString());

            Hit = true;
        }

        public override void BeHit(IPlayer player)
        {
            
        }

    }
}
