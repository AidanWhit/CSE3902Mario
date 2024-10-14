using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects
{
    public class Pipe : IPipe
    {
        public float XPos { get; set; }
        public float YPos { get; set; }

        private ISprite sprite;


        public Pipe(Vector2 location, string pipeSize)
        {
            XPos = location.X;
            YPos = location.Y;
            sprite = BlockFactory.Instance.GetBlock(pipeSize);

            BlockFactory.Instance.AddPipeToPipesList(this);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }
    }
}
