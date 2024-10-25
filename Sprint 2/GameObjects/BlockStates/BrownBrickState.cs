using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using System.Diagnostics;


namespace Sprint_2.GameObjects.BlockStates
{
    public class BrownBrickState : BlockState
    {
        private IBlock block;
        private bool bumped = false;
        private bool destroyed = false;
        private float originalBlockY;

        public BrownBrickState(IBlock block) : base(block)
        {
            this.block = block;
            sprite = BlockFactory.Instance.GetBlock("BrownBrick");

            originalBlockY = block.Position.Y;
        }

        public override void BeHit(IPlayer player)
        {
            
            /* Little mario hit the block */
            if (player.GetHealth().Equals("Mario"))
            {
                /* Make the block move up and then down */
                Hit = true;
                originalBlockY = (int)block.Position.Y;
                SoundManager.Instance.PlaySoundEffect("bump");
            }
            /* SuperMario/Fire Mario hit the block*/
            else
            {
                int column = (int)block.Position.X / 16;

                /* Call remove object on gameobject manager to remove the block from being able to be drawn/updated */
                GameObjectManager.Instance.Blocks[column].Remove(block);
                GameObjectManager.Instance.Drawables.Remove(block);
                GameObjectManager.Instance.Updateables.Remove(block);
                SoundManager.Instance.PlaySoundEffect("breakBlock");


            }
        }

    }
}
