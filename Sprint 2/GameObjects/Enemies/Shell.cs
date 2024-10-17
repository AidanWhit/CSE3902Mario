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

        public Shell(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            sprite = EnemyFactory.Instance.CreateKoopaShell();
            Velocity = new Vector2(0, EnemyConstants.fallVelocity.Y);
        }


        public void Update(GameTime gameTime)
        {
            if (Flipped)
            {
                if (YPos > EnemyConstants.despawnHeight)
                {
                    GameObjectManager.Instance.Movers.Remove(this);
                    GameObjectManager.Instance.Updateables.Remove(this);
                    GameObjectManager.Instance.Drawables.Remove(this);
                }
            }
            else if (Velocity.X == 0)
            {
                timeUntilShellBecomesKoopa -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timeUntilShellBecomesKoopa < 0)
                {
                    Koopa koopa = new Koopa(new Vector2(XPos, YPos - GetHitBox().Height));
                    GameObjectManager.Instance.Movers.Add(koopa);
                    GameObjectManager.Instance.Updateables.Add(koopa);
                    GameObjectManager.Instance.Drawables.Add(koopa);

                    GameObjectManager.Instance.Movers.Remove(this);
                    GameObjectManager.Instance.Updateables.Remove(this);
                    GameObjectManager.Instance.Drawables.Remove(this);
                }

               
            }
            if (Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                Velocity += EnemyConstants.fallVelocity;
            }

            Velocity = new Vector2(Velocity.X, Velocity.Y * MarioPhysicsConstants.velocityDecay);

            XPos += (float)(Velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            
            if (YPos > EnemyConstants.despawnHeight)
            {
                GameObjectManager.Instance.Movers.Remove(this);
                GameObjectManager.Instance.Updateables.Remove(this);
                GameObjectManager.Instance.Drawables.Remove(this);
            }

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
            HitBoxRectangle.DrawRectangle(spriteBatch, GetHitBox(), color, 1);
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
            return typeof(Shell).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
