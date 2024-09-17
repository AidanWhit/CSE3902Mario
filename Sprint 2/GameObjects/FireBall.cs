using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        private double x = 0f;
        public FireBall(Player source, Vector2 speed, ISprite fireball)
        {
            this.source = source;
            XPos = source.XPos;
            YPos = source.YPos;
            Speed = speed;
            this.fireball = fireball;

            fireballSpawn = source.XPos;
        }
        public void Update(GameTime gameTime) 
        {
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            XPos += (float)(Speed.X * gameTime.ElapsedGameTime.TotalMilliseconds);
            YPos = fireballSpawn * (float)Math.Abs((Math.Cos(totalTime)));


            fireball.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            fireball.Draw(spriteBatch, new Vector2(XPos, YPos));
        }
    }
}
