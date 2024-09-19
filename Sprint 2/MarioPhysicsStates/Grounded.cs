using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;

namespace Sprint_2.MarioPhysicsStates
{
    public class Grounded : IMarioPhysicsStates
    {
        private Player mario;
        public Grounded(Player mario)
        {
            this.mario = mario;
        }

        public void Update(GameTime gameTime)
        {
            if (mario.PlayerVelocity.X > -50f && mario.PlayerVelocity.X < 50f)
            {
                mario.Idle();
            }
            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);

            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;
        }
    }
}
