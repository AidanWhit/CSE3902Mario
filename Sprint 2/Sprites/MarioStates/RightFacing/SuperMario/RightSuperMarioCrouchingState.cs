using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;

namespace Sprint_0.Sprites.MarioStates.RightFacing.SuperMario
{
    public class RightSuperMarioCrouchingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightSuperMarioCrouchingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightSuperMarioCrouchingSprite();
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
            mario.State = new RightSuperMarioIdleState(mario);
        }
        public void Crouch()
        {

        }
        public void Fall() { }
        public void MoveLeft()
        {
            mario.State = new LeftSuperMarioCrouchingState(mario);
        }
        public void MoveRight()
        {

        }
        public void Damage()
        {
        }
        public void PowerUp()
        {
            mario.State = new RightFireMarioCrouchingState(mario);
        }
    }
}
