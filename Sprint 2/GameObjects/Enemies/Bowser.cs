using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;

namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class Bowser : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; }
        private Texture2D[] bowserLeftSprites;
        private Texture2D[] bowserRightSprites;
        private Texture2D[] fireballLeftSprites;
        private Texture2D[] fireballRightSprites;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        private int currentFrame;
        private int totalFrames;
        private bool isFacingLeft;
        private float fireballTimer;
        private float fireballCooldown = 2.5f; // Time between each fireball shot (in seconds)
        private List<IProjectile> fireballs = new List<IProjectile>();

        private float animationDelay = 0.2f;

        public Bowser(Texture2D[] leftSprites, Texture2D[] rightSprites, Texture2D[] fireLeftSprites, Texture2D[] fireRightSprites, Vector2 initialPosition)
        {
            bowserLeftSprites = leftSprites;
            bowserRightSprites = rightSprites;
            fireballLeftSprites = fireLeftSprites;
            fireballRightSprites = fireRightSprites;

            Position = initialPosition;
            Velocity = new Vector2(-1, 0);
            isFacingLeft = true; // 

            currentFrame = 0;
            totalFrames = 4; // 4 frames for walking in each direction

            fireballTimer = 0;
        }

        public void Update(GameTime gameTime)
        {

            Position += Velocity;

            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationDelay -= timer;
            if (animationDelay < 0)
            {
                animationDelay = 0.2f;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }



            if (Position.X <= 0 || Position.X >= 800 - bowserLeftSprites[0].Width)
            {
                ReverseDirection();
            }

            // Update fireball timer and shoot fireballs
            fireballTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (fireballTimer >= fireballCooldown)
            {
                ShootFireball();
                fireballTimer = 0;
            }


            for (int i = 0; i < fireballs.Count; i++)
            {
                fireballs[i].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {

            Texture2D currentTexture = isFacingLeft ? bowserLeftSprites[currentFrame] : bowserRightSprites[currentFrame];
            spriteBatch.Draw(currentTexture, Position, color);

            // Draw fireballs
            foreach (var fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
        }

        private void ReverseDirection()
        {
            isFacingLeft = !isFacingLeft;
            Velocity = new Vector2(-Velocity.X, Velocity.Y);

        }

        private void ShootFireball()
        {
            // Create a new fireball in the direction Bowser is facing
            Vector2 fireballPosition = new Vector2(Position.X, Position.Y + 20);
            Vector2 fireballVelocity = isFacingLeft ? new Vector2(-2, 0) : new Vector2(2, 0);

            BowserFireball fireball = new BowserFireball(
                isFacingLeft ? fireballLeftSprites : fireballRightSprites,
                fireballPosition,
                fireballVelocity
            );
            fireballs.Add(fireball);
        }

        public void TakeFireballDamage()
        {
            
        }

        public void TakeStompDamage()
        {
            
        }

        public void ChangeDirection()
        {
            
        }
        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
