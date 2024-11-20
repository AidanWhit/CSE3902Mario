using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class BowserFireball: Interfaces.IUpdateable, Interfaces.IDrawable, ICollideable
    {
        private ISprite sprite;
        private float XPos;
        private float YPos;
        private int targetYPos;

        private float speed;

        public BowserFireball(Vector2 spawnLocation, int targetYPos, bool goingLeft)
        {
            XPos = spawnLocation.X;
            YPos = spawnLocation.Y;
            
            if (goingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy("LeftBowserFireball");
                speed = -50f;
            }
            else
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy("RightBowserFireball");
                speed = 50f;
            }

            this.targetYPos = targetYPos - GetHitBox().Height;
        }

        public void Update(GameTime gameTime)
        {
            if (YPos < targetYPos)
            {
                YPos++;
            }
            else if (YPos > targetYPos)
            {
                YPos--;
            }
            XPos += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
            /* Temporary will be made better */
            if (Game1.Instance.camera.GetLeftScreenBound().X > XPos)
            {
                DeleteObject();
            }
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public string GetCollisionType()
        {
            return "EnemyProjectile";
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public int GetColumn()
        {
            return (int)XPos / CollisionConstants.blockWidth;
        }

        public void DeleteObject()
        {
            GameObjectManager.Instance.Movers.Remove(this);
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.ForeDrawables.Remove(this);
        }
    }
}
