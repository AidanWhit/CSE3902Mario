using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;

namespace Sprint_0.Sprites.MarioStates.RightFacing.FireMario
{
    public class RightFireMarioCrouchingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightFireMarioCrouchingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightFireMarioCrouchingSprite();
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
            mario.State = new RightFireMarioIdleState(mario);
        }
        public void Crouch()
        {

        }
        public void MoveLeft()
        {
            mario.State = new LeftFireMarioCrouchingState(mario);
        }
        public void MoveRight()
        {
            
        }
        public void Damage()
        {
            mario.State = new RightSuperMarioCrouchingState(mario);
        }
        public void PowerUp()
        {

        }
    }
}
