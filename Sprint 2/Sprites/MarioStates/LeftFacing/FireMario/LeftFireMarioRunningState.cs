using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.FireMario
{
    public class LeftFireMarioRunningState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftFireMarioRunningState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftFireMarioRunningSprite();
        }
        public void Update(GameTime gameTime)
        {
            mario.MoveLeft();
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Crouch()
        {
            mario.State = new LeftFireMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftFireMarioJumpingState(mario);
        }
        public void MoveLeft()
        {

        }
        public void Fall() { }
        public void MoveRight()
        {
            mario.State = new LeftFireMarioIdleState(mario);
        }

        public void Damage()
        {
            mario.State = new LeftSuperMarioRunningState(mario);
        }

        public void PowerUp()
        {
            
        }
    }
}
