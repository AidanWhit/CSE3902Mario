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
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.FireMario
{
    public class LeftFireMarioCrouchingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftFireMarioCrouchingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftFireMarioCrouchingSprite();
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
            mario.State = new LeftFireMarioIdleState(mario);
        }
        public void Crouch()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {
            mario.State = new RightFireMarioCrouchingState(mario);
        }
        public void Damage()
        {
            mario.State = new LeftSuperMarioCrouchingState(mario);
        }
        public void PowerUp()
        {

        }
    }
}

