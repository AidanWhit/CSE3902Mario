using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces; 
using Sprint_2.Sprites; 

namespace Sprint_2.Sprites.ItemSprites
{
    public class Flower : IItem
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Rectangle source;

        public Flower(Texture2D texture, Rectangle source, Vector2 initialPosition)
        {
            this.Texture = texture;
            this.Position = initialPosition;
            this.source = source;
            this.currentFrame = 0;
            this.totalFrames = 4;
        }

        public void Update(GameTime gameTime)
        {

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle newSource = new Rectangle(source.Width * currentFrame, source.Y, source.Width, source.Height);
            spriteBatch.Draw(Texture, Position, newSource, Color.White);
        }

        public void DeleteItem() { }
    }
}
