using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites;
using System.Diagnostics;

namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class Shell : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; }
        public bool Kicked { get; set; }
        public Vector2 Velocity { get; set; }
        private ISprite sprite;

        private float timeUntilShellBecomesKoopa = 5f;
        public IShellState ShellState { get; set; }

        private int[] score = new int[] { 500, 800, 1000, 2000, 4000, 5000, 8000 };
        private int index = 0;
        public Shell(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            sprite = EnemyFactory.Instance.CreateKoopaShell();
            ShellState = new ShellStateIdle(this);
            Velocity = new Vector2(0, EnemyConstants.fallVelocity.Y);
        }


        public void Update(GameTime gameTime)
        {
            ShellState.Update(gameTime);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void TakeFireballDamage()
        {
            sprite = EnemyFactory.Instance.CreateFlippedKoopaShell();
            Flipped = true;
            Velocity = EnemyConstants.flippedVelocity;
            ShellState = new ShellFlippedState(this);
            GameObjectManager.Instance.Movers.Remove(this);
        }

        public void TakeStompDamage()
        {

        }

        public void ChangeDirection()
        {
            Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
        }

        public string GetCollisionType()
        {
            if (Velocity.X != 0)
            {
                return "MovingShell";
            }
            if (Flipped)
            {
                return "flip";
            }
            return typeof(Shell).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }

        public int GetScore()
        {
            return score[index++];
        }

        public void ResetIndex()
        {
            index = 0;
        }
    }
}
