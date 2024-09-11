using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites
{
    internal class Sprite4 : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int xPos = 0;

        public Sprite4() { }
        public Sprite4(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = 4;
        }


        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

            if (xPos > 800)
            {
                xPos = 0;
            }
            else
            {
                xPos += 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / 8;
            int height = Texture.Height;
            int row = currentFrame + 5;
            //xPos = (int)location.X;



            Rectangle sourceRectangle = new Rectangle(row * width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(xPos, (int)location.Y, width, height);
            Vector2 rec = new Vector2(xPos, location.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, rec, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
