using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;


namespace Sprint_0.Sprites.ItemSprites
{
    public class Star : IItem
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private int currentFrame;
        private int totalFrames;
        private Rectangle source;


        public Star(Texture2D texture, Rectangle source, Vector2 initialPosition)
        {
            this.Texture = texture;
            this.Position = initialPosition;
            this.Velocity = new Vector2(-2, 0); // Moving left by default
            this.source = source;
            this.currentFrame = 0;
            this.totalFrames = 4;
        }

        public void Update()
        {
                Position += Velocity;

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                if (Position.X <= 0 || Position.X >= 800 - Texture.Width / 4)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle newSource = new Rectangle(source.Width * currentFrame, source.Y, source.Width, source.Height);
            spriteBatch.Draw(Texture, Position, newSource, Color.White);
        }

        public void DeleteItem() { }

    }
}
