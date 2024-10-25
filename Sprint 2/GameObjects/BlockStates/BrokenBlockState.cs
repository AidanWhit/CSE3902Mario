using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class BrokenBlockState : IBlockState
    {
        private IBlock block;
        private ISprite topLeftSprite;
        private ISprite topRightSprite;
        private ISprite bottomLeftSprite;
        private ISprite bottomRightSprite;

        private Vector2 topLeftVelocity = new Vector2(-50, -150);
        private Vector2 topRightVelocity = new Vector2(50, -150);
        private Vector2 bottomLeftVelocity = new Vector2(-50, -50);
        private Vector2 bottomRightVelocity = new Vector2(50, -50);

        private Vector2 topLeftPosition;
        private Vector2 topRightPosition;
        private Vector2 bottomLeftPosition;
        private Vector2 bottomRightPosition;

        public BrokenBlockState(IBlock block)
        {
            this.block = block;
            topLeftSprite = BlockFactory.Instance.GetBrokenPieceSprite();
            topRightSprite = BlockFactory.Instance.GetBrokenPieceSprite();
            bottomLeftSprite = BlockFactory.Instance.GetBrokenPieceSprite();
            bottomRightSprite = BlockFactory.Instance.GetBrokenPieceSprite();

            topLeftPosition = block.Position;
            bottomLeftPosition = block.Position;
            bottomRightPosition = block.Position;
            topRightPosition = block.Position;
        }

        public void Update(GameTime gameTime)
        {
            if (topLeftVelocity.Y < ItemPhysicsConstants.maxFallVelocity)
            {
                topLeftVelocity += ItemPhysicsConstants.fallVelocity;
                topRightVelocity += ItemPhysicsConstants.fallVelocity;
                bottomLeftVelocity += ItemPhysicsConstants.fallVelocity;
                bottomRightVelocity += ItemPhysicsConstants.fallVelocity;
            }

            float elpasedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            topLeftPosition += new Vector2(topLeftVelocity.X * elpasedTime, topLeftVelocity.Y * elpasedTime);
            topRightPosition += new Vector2(topRightVelocity.X * elpasedTime, topRightVelocity.Y * elpasedTime);
            bottomLeftPosition += new Vector2(bottomLeftVelocity.X * elpasedTime, bottomLeftVelocity.Y * elpasedTime);
            bottomRightPosition += new Vector2(bottomRightVelocity.X * elpasedTime, bottomRightVelocity.Y * elpasedTime);

            if (topLeftPosition.Y > 448)
            {
                GameObjectManager.Instance.Drawables.Remove(block);
                GameObjectManager.Instance.Updateables.Remove(block);
            }

            topLeftVelocity *= MarioPhysicsConstants.velocityDecay;
            topRightVelocity *= MarioPhysicsConstants.velocityDecay;
            bottomLeftVelocity *= MarioPhysicsConstants.velocityDecay;
            bottomRightVelocity *= MarioPhysicsConstants.velocityDecay;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            topLeftSprite.Draw(spriteBatch, topLeftPosition, color);
            topRightSprite.Draw(spriteBatch, topRightPosition, color);
            bottomLeftSprite.Draw(spriteBatch, bottomLeftPosition, color);
            bottomRightSprite.Draw(spriteBatch, bottomRightPosition, color);
        }

        public void BeHit(IPlayer player) { }
        public Rectangle GetHitBox(Vector2 position) { return Rectangle.Empty; }

    }
}
