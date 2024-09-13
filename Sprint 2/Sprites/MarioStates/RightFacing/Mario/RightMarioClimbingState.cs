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
    public class RightMarioClimbingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightMarioClimbingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightMarioClimbingSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        void Jump()
        {
            mario.State = new RightMarioJumpingState(mario);
        }
        void Crouch()
        {

        }
        void MoveLeft()
        {
            mario.State = new LeftMarioClimbingState(mario);
        }
        void MoveRight()
        {

        }
        void PowerUp()
        {
            mario.State = new RightSuperMarioClimbingState(mario);
        }
        void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
    }
}
