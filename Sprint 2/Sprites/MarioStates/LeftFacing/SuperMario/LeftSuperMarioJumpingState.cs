using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_2.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_2.MarioPhysicsStates;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario
{
    public class LeftSuperMarioJumpingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftSuperMarioJumpingState(Player mario)
        {
            this.mario = mario;
            this.mario.PhysicsState = new Jumping(mario);
            sprite = MarioSpriteFactory.Instance.LeftSuperMarioJumpingSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            mario.Jump();
            sprite.Draw(spriteBatch, location);
        }

        public void Jump()
        {

        }
        public void Fall()
        {
            mario.State = new LeftSuperMarioFallingState(mario);
        }
        public void Crouch()
        {
            mario.State = new LeftSuperMarioIdleState(mario);
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
            mario.State = new LeftMarioJumpingState(mario);
        }
        public void PowerUp()
        {
            mario.State = new RightFireMarioJumpingState(mario);
        }
    }
}
