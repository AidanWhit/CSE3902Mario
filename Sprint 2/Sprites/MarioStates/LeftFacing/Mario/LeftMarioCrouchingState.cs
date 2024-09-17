using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.Mario
{
    public class LeftMarioCrouchingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftMarioCrouchingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftMarioCrouchingSprite();
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Jump()
        {
            mario.State = new LeftMarioIdleState(mario);
        }
        public void Fall() { }
        public void Crouch()
        {

        }
        public void MoveLeft()
        {
          
        }
        public void MoveRight()
        {
            mario.State = new RightMarioCrouchingState(mario);
        }
        public void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void PowerUp()
        {
            mario.State = new LeftSuperMarioCrouchingState(mario);
        }
    }
}
