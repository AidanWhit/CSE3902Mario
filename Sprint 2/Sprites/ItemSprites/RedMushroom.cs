using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites; 

namespace Sprint_2.Sprites.ItemSprites
{
    public class RedMushroom : IItem
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Rectangle source;

        public RedMushroom(Texture2D texture, Rectangle source, Vector2 initialPosition)
        {
            this.Texture = texture;
            this.Position = initialPosition;
            this.source = source;
            this.Velocity = new Vector2(-1, 0); // Starts moving left
            this.currentFrame = 0;
            this.totalFrames = 1;
        }


        public void Update(GameTime g)
        {
                Position += Velocity;

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                if (Position.X <= 0 || Position.X >= 800)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse direction
                }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, source, Color.White);
        }

        public void DeleteItem() { }

    }
}

