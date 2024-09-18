using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioPhysicsStates
{
    public class Grounded : IMarioPhysicsStates
    {
        private IPlayer mario;
        public Grounded(IPlayer mario) 
        {
            this.mario = mario;
        }

        public void Update(GameTime gameTime)
        {
            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);

            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;
        }
    }
}
