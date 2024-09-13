using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;

namespace Sprint_0.Sprites.MarioStates.RightFacing.Mario
{
    public class RightMarioIdleState : IMarioState
    {
        private Player mario;
        private ISprite sprite;
        public RightMarioIdleState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightMarioIdleSprite();
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
            mario.State = new RightMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new RightMarioJumpingState(mario);
        }

        public void MoveLeft()
        {
            mario.State = new LeftMarioIdleState(mario);
        }
        public void MoveRight()
        {
            mario.State = new RightMarioRunningState(mario);
        }
        public void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void PowerUp()
        {
            mario.State = new RightSuperMarioIdleState(mario);
        }
    }
}
