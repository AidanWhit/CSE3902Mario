﻿using Microsoft.Xna.Framework;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Coin coin = new Coin(new Vector2(block.Position.X + block.GetHitBox().Width / 2.5f, block.Position.Y - block.GetHitBox().Height), true);
            GameObjectManager.Instance.Updateables.Add(coin);
            GameObjectManager.Instance.BackDrawables.Add(coin);

            SoundManager.Instance.PlaySoundEffect("coin");

            HUD.Instance.AddScoreFromCoin(200);

            block.ChangeState(new UsedBlockState(block));
        }
    }
}
