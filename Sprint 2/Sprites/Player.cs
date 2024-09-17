using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using System.Diagnostics;


namespace Sprint_0.Sprites
{
    public class Player : IPlayer, ISprite
    {

        public IMarioState State { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Vector2 PlayerVelocity { get; set; }

        public IMarioPhysicsStates PhysicsState { get; set; }

        private bool isCrouching = false;
        private bool isJumping = false;
        public Player(Vector2 StartingLocation) 
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;
            State = new RightMarioIdleState(this);
            PhysicsState = new Grounded(this);
        }
        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            PhysicsState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, new Vector2(XPos, YPos));
        }

        public void MoveLeft()
        {
            if (!isCrouching)
            {
                if (PlayerVelocity.X >  -MarioPhysicsConstants.maxXVelocity)
                {
                    PlayerVelocity -= MarioPhysicsConstants.marioXVelocity;
                }

            }
        }
            
        public void MoveRight()
        {
            if (!isCrouching)
            {
                if (PlayerVelocity.X < MarioPhysicsConstants.maxXVelocity)
                {
                    PlayerVelocity += MarioPhysicsConstants.marioXVelocity;
                }
            }
        }
        public void Jump()
        {
            if (!isJumping)
            {
                State.Jump();
            }
            if (PlayerVelocity.Y > MarioPhysicsConstants.maxJumpVelocity)
            {
                PlayerVelocity += MarioPhysicsConstants.marioJumpVelocity;
            }
        }
        public void Fall()
        {
            if (PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }
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
