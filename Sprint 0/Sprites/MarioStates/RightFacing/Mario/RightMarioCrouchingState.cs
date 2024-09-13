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
    public class RightMarioCrouchingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightMarioCrouchingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightMarioCrouchingSprite();
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
            mario.State = new RightMarioIdleState(mario);
        }
        public void Crouch()
        {

        }
        public void MoveLeft()
        {
            mario.State = new LeftMarioCrouchingState(mario);
        }
        public void MoveRight()
        {

        }
        public void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void PowerUp()
        {
            mario.State = new RightSuperMarioCrouchingState(mario);
        }
    }
}
