using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_2.Constants;
using System.Diagnostics;


namespace Sprint_0.Sprites
{
    public class Player : IPlayer, ISprite
    {

        public IMarioState State { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Vector2 PlayerVelocity { get; set; }

        private bool isCrouching = false;
        private bool isJumping = true;
        public Player(Vector2 StartingLocation) 
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;
            State = new RightFireMarioRunningState(this);
        }
        public void Update(GameTime gameTime)
        {
            XPos += (int)(PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            State.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, new Vector2(XPos, YPos));
        }

        public void MoveLeft()
        {
            if (!isCrouching)
            {
                XPos -= 3;
            }
        }
            
        public void MoveRight()
        {
            if (!isCrouching)
            {
                PlayerVelocity = new Vector2(PlayerVelocity.X + MarioPhysicsConstants.marioXVelocity, YPos);
                Debug.WriteLine("Mario X Velcoity: " +PlayerVelocity.X);
            }
        }
        public void Jump()
        {
            YPos--;
        }

        public void Crouch()
        {
            State.Crouch();
        }

        public void Damage()
        {
            State.Damage();
        }
        public void PowerUp()
        {
            State.PowerUp();
        }
    }
}
