using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;

namespace Sprint_0.Sprites.MarioStates.RightFacing.FireMario
{
    public class RightFireMarioRunningState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightFireMarioRunningState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightFireMarioRunningSprite();
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Crouch()
        {
            mario.State = new RightFireMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new RightFireMarioJumpingState(mario);
        }
        public void MoveLeft()
        {
            mario.State = new RightFireMarioIdleState(mario);
        }
        public void MoveRight()
        {
            
        }

        public void Damage()
        {
            mario.State = new RightSuperMarioRunningState(mario);
        }

        public void PowerUp()
        {

        }
    }
}
