using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;


namespace Sprint_0.Sprites.EnemySprites
{
    public class Koopa : IEnemy
    {
        private Texture2D walkingLeftTexture1;
        private Texture2D walkingLeftTexture2;
        private Texture2D walkingRightTexture1;
        private Texture2D walkingRightTexture2;
        private Texture2D shellTexture;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private int currentFrame;
        private int totalFrames;
        private bool isDead;
        private bool isFacingLeft;
        private bool isShell;

        public Koopa(Texture2D walkingLeft1, Texture2D walkingLeft2, Texture2D walkingRight1, Texture2D walkingRight2, Texture2D shell, Vector2 initialPosition)
        {
            this.walkingLeftTexture1 = walkingLeft1;
            this.walkingLeftTexture2 = walkingLeft2;
            this.walkingRightTexture1 = walkingRight1;
            this.walkingRightTexture2 = walkingRight2;
            this.shellTexture = shell;
            this.Position = initialPosition;
            this.Velocity = new Vector2(-2, 0); // Moving left by default
            this.currentFrame = 0;
            this.totalFrames = 2; // 2 walking frames per direction
            this.isFacingLeft = true; // Starts facing left
            this.isDead = false; // After it dies, it becomes a shell(shell is not an item)
            this.isShell = false; // Initially not a shell
        }

        public void Update(GameTime gameTime)
        {
            if (!isDead && !isShell)
            {
                Position += Velocity;

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                if (Position.X <= 0 || Position.X >= 800 - walkingLeftTexture1.Width)
                {
                    ReverseDirection();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Texture2D currentTexture = GetCurrentTexture();
            spriteBatch.Draw(currentTexture, Position, Color.White);
        }

        // Takes damage and turns into a shell
        public void TakeDamage()
        {
            //isDead = true;
            //isShell = true; // Koopa turns into a shell when it dies
            //velocity = Vector2.Zero; 
        }

        public void MoveLeft()
        {
            isFacingLeft = true;
            Velocity = new Vector2(-Velocity.X, Velocity.Y); // Move left
        }

        public void MoveRight()
        {
            isFacingLeft = false;
            Velocity = new Vector2(-Velocity.X, Velocity.Y); // Move right
        }

        // Reverse facing direction 
        private void ReverseDirection()
        {
            if (isFacingLeft)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }

        private Texture2D GetCurrentTexture()
        {
            if (isShell)
            {
                return shellTexture; // Return shell texture if Koopa is dead
            }

            if (isFacingLeft)
            {
                return (currentFrame == 0) ? walkingLeftTexture1 : walkingLeftTexture2;
            }
            else
            {
                return (currentFrame == 0) ? walkingRightTexture1 : walkingRightTexture2;
            }
        }
    }
}
