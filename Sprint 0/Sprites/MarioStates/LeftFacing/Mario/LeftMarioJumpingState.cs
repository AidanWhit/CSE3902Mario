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
    public class LeftMarioJumpingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftMarioJumpingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftMarioJumpingSprite();
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

        }
        public void Crouch()
        {
            mario.State = new LeftMarioIdleState(mario);
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
            mario.State = new DeadMarioState(mario);
        }
        public void PowerUp()
        {
            mario.State = new LeftSuperMarioJumpingState(mario);
        }
    }
}
