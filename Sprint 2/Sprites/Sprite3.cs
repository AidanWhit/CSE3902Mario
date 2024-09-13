using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites
{
    internal class Sprite3 : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int yPos = 200;
        private bool movingUp = false;
        public Sprite3() { }
        public Sprite3(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = 1;
        }


        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

            if (movingUp)
            {
                yPos -= 1;
                if (yPos == 190)
                    movingUp = false;
            }
            else
            {
                yPos += 1;
                if (yPos == 210)
                    movingUp = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / 8;
            int height = Texture.Height;


            Rectangle sourceRectangle = new Rectangle(3 * width, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, yPos, width, height);
            Vector2 rec = new Vector2(location.X, yPos);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, rec, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}