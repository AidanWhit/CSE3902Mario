using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Sprites.MarioStates.RightFacing.Mario;
using Sprint_2.MarioPhysicsStates;

namespace Sprint_0.Sprites.MarioStates.RightFacing.Mario
{
    public class RightMarioJumpingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightMarioJumpingState(Player mario)
        {
            this.mario = mario;
            this.mario.PhysicsState = new Jumping(mario);
            sprite = MarioSpriteFactory.Instance.RightMarioJumpingSprite();
        }

        public void Update(GameTime gameTime)
        {
            mario.Jump();
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Jump()
        {

        }

        public void Fall()
        {
            mario.State = new RightMarioFallingState(mario);
        }
        public void Crouch()
        {
            mario.State = new RightMarioIdleState(mario);
        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {
        }

        public void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void PowerUp()
        {
            mario.State = new RightSuperMarioJumpingState(mario);
        }
    }
}
