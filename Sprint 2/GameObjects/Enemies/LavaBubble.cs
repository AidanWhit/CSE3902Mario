using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using System.Threading;
using System.Linq.Expressions;
using Sprint_2.Constants;
using System.Diagnostics;
using System;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.LevelManager;

namespace Sprint_2.Sprites.EnemySprites
{
    public class LavaBubble : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; }
        public Vector2 Velocity { get; set; }
        private ISprite sprite;
        public LavabubbleStateMachine LavaState { get; set; }

        private int index = 0;
        public LavaBubble(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            LavaState = new LavabubbleStateMachine(this);
            Velocity = new Vector2(0, EnemyConstants.fallVelocity.Y);
        }


        public void Update(GameTime gameTime)
        {
            LavaState.Update(gameTime);
            //LavaState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            LavaState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return LavaState.GetHitBox(new Vector2(XPos, YPos));
        }


        public void TakeFireballDamage()
        {
        }

        public void TakeStompDamage()
        {
        }

        public void ChangeDirection()
        {
            //Velocity = new Vector2(Velocity.X, Velocity.Y * -1);
        }

        public string GetCollisionType()
        {
            //TODO: Look into
            return null;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }

        public void ResetIndex()
        {
            index = 0;
        }
    }
}

