using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Diagnostics;


namespace Sprint_2.GameObjects
{
    public class FireBall : IProjectile
    {
        private ISprite fireball;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Speed { get; set; }

        private int fireballSpawn;

        private float totalTime;
        private Player source;
        double distFromSource;

        private bool enteredExplosionState = false;
        public FireBall(Player source, Vector2 speed)
        {
            this.source = source;
            XPos = source.XPos;
            YPos = source.YPos;
            Speed = speed;
            fireball = MarioSpriteFactory.Instance.FireBall();

            fireballSpawn = source.YPos;
            
        }
        public void Update(GameTime gameTime) 
        {
            //Calculate Position for bouncing fireball if it has not exploded
            if (!enteredExplosionState)
            {
                XPos += (float)(Speed.X * gameTime.ElapsedGameTime.TotalMilliseconds);
                YPos = CalculateYPosition(gameTime);

                //Caclulates distance from the fireball and the Player
                distFromSource = Math.Sqrt(Math.Pow(XPos - source.XPos, 2) + Math.Pow(YPos - source.YPos, 2));
            }
            
            //If the fireBall is too far away from the player that threw it, the fireball will explode
            if (distFromSource > FireBallConstants.explosionRange && !enteredExplosionState)
            {
                fireball = MarioSpriteFactory.Instance.FireballExplosion();
                enteredExplosionState = true;
            }
            
            fireball.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
                fireball.Draw(spriteBatch, new Vector2(XPos, YPos));   
        }

        public float CalculateYPosition(GameTime gameTime)
        {
            //Calculates how much time has passed since last Update Call
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Random numbers that can be tweaked to make the bouncing of the fireball better
            float YPos = -(float)Math.Abs(Math.Cos(totalTime)) * 64;
            YPos += fireballSpawn + 64;
            return YPos;
        }

        public bool isExploded()
        {
            return enteredExplosionState;
        }
    }
}
