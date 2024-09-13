using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.FireMario
{
    public class LeftFireMarioJumpingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftFireMarioJumpingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftFireMarioJumpingSprite();
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
            mario.State = new LeftFireMarioIdleState(mario);
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
            mario.State = new LeftSuperMarioJumpingState(mario);
        }
        public void PowerUp()
        {
        }
    }
}
