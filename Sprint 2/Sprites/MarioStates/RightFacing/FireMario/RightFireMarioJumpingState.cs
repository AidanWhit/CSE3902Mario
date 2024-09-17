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
using Sprint_2.Sprites.MarioStates.RightFacing.FireMario;

namespace Sprint_0.Sprites.MarioStates.RightFacing.FireMario
{
    public class RightFireMarioJumpingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightFireMarioJumpingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightFireMarioJumpingSprite();
        }

        public void Update(GameTime gameTime)
        {
            mario.Jump();
            sprite.Update(gameTime);
        }

        public void Fall()
        {
            mario.State = new RightFireMarioFallingState(mario);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Jump()
        {

        }
        public void Crouch()
        {
            mario.State = new RightFireMarioIdleState(mario);
        }
        public void MoveLeft()
        {
            mario.XPos--;
        }
        public void MoveRight()
        {
            mario.XPos++;
        }

        public void Damage()
        {
            mario.State = new RightSuperMarioJumpingState(mario);
        }
        public void PowerUp()
        {
        }
    }
}
