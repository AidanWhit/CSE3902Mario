using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;

namespace Sprint_2.MarioPhysicsStates
{
    public class Falling : IMarioPhysicsStates
    {
        private IPlayer mario;
        private int originalPlayerHeight;
        public Falling(IPlayer mario, int origialPlayerHeight)
        {
            this.mario = mario;
            this.originalPlayerHeight = origialPlayerHeight;
        }

        public void Update(GameTime gameTime)
        {
            if (mario.PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                mario.PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }

            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            if (mario.YPos > originalPlayerHeight)
            {
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, 0);
                mario.YPos = originalPlayerHeight;
                mario.PhysicsState = new Grounded(mario);
                mario.isJumping = false;
                mario.Idle();
            }


        }
    }
}
