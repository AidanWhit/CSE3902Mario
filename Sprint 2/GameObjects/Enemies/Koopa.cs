using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.Interfaces;
using System.Linq.Expressions;


namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class Koopa : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; } = false;
        public Vector2 Velocity { get; set; }

        private KoopaStateMachine koopaState;
        

        public Koopa(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(-3, 0); // Moving left by default

            koopaState = new KoopaStateMachine(this);
        }

        public void Update(GameTime gameTime)
        {
            if (YPos > EnemyConstants.despawnHeight)
            {
                EnemyFactory.Instance.RemoveEnemyFromObjectList(this);
            }
            koopaState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            koopaState.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return koopaState.GetHitBox(new Vector2(XPos, YPos));
        }

        public void TakeFireballDamage()
        {
            Flipped = true;
            koopaState.BeFlipped();
        }

        public void TakeStompDamage()
        {
            koopaState.BeStomped();
        }
        public void ChangeDirection()
        {
            koopaState.ChangeDirection();
        }
    }
}
