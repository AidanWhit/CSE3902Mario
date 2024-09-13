using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.Mario
{
    public class LeftMarioRunningState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftMarioRunningState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftMarioRunningSprite();
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
            mario.State = new LeftMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftMarioJumpingState(mario);
        }
        public void MoveLeft()
        {
            
        }
        public void MoveRight()
        {
            mario.State = new LeftMarioIdleState(mario);
        }

        public void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }

        public void PowerUp()
        {
            mario.State = new LeftSuperMarioRunningState(mario);
        }
    }
}
