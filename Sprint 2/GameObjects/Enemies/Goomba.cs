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

namespace Sprint_2.Sprites.EnemySprites
{
    public class Goomba : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Velocity { get; set; }

        private GoombaStateMachine goombaState;

        private float stompTimer = 0.75f;
        private bool stomped = false;

        private bool startBehavior = false;

        public bool Flipped { get; set; } = false;
        public Goomba(Vector2 initialPosition)
        { 
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            goombaState = new GoombaStateMachine(this);
        }


        public void Update(GameTime gameTime)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                if (stomped)
                {
                    stompTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (stompTimer < 0)
                    {
                        //Remove Goomba from enemies list
                        EnemyFactory.Instance.RemoveEnemyFromObjectList(this);
                    }
                }
                else if (Flipped)
                {
                    if (YPos > 650)
                    {
                        EnemyFactory.Instance.RemoveEnemyFromObjectList(this);
                    }
                }
                goombaState.Update(gameTime);
            }
            
        }

        public bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - XPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts)
            {
                startBehavior = true;
            }
            return startBehavior;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            goombaState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        
        public void TakeFireballDamage()
        {
            goombaState.BeFlipped();
            Flipped = true;
            Velocity = EnemyConstants.flippedVelocity;
        }

        public void TakeStompDamage()
        {
            goombaState.BeStomped();
            stomped = true;
        }

        public void ChangeDirection()
        {
            goombaState.ChangeDirection();
        }

        public Rectangle GetHitBox()
        {
            return goombaState.GetHitBox(new Vector2(XPos, YPos));
        }
    }
}

