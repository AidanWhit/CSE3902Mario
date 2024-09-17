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
    public class RightFireMarioClimbingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightFireMarioClimbingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightFireMarioClimbingSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Fall() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        void Jump()
        {
            mario.State = new RightFireMarioJumpingState(mario);
        }
        void Crouch()
        {

        }
        void MoveLeft()
        {
            mario.State = new LeftFireMarioClimbingState(mario);
        }
        void MoveRight()
        {
            
        }
        void PowerUp()
        {

        }
        void Damage()
        {
            mario.State = new RightSuperMarioClimbingState(mario);
        }
    }
}
