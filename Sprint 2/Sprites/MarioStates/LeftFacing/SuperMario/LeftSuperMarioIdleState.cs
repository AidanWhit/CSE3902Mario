using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario
{
    internal class LeftSuperMarioIdleState : IMarioState
    {
        private Player mario;
        private ISprite sprite;
        public LeftSuperMarioIdleState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftSuperMarioIdleSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Fall() { }

        public void Crouch()
        {
            mario.State = new LeftSuperMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftSuperMarioJumpingState(mario);
        }

        public void MoveLeft()
        {
            mario.State = new LeftSuperMarioRunningState(mario);
        }
        public void MoveRight()
        {
            mario.State = new RightSuperMarioIdleState(mario);
        }
        public void Damage()
        {
            mario.State = new LeftMarioIdleState(mario);
        }
        public void PowerUp()
        {
            mario.State = new LeftFireMarioIdleState(mario);
        }
    }
}
