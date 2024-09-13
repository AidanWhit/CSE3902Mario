using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario
{
    public class LeftSuperMarioClimbingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftSuperMarioClimbingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftSuperMarioClimbingSprite();
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
            mario.State = new LeftSuperMarioJumpingState(mario);
        }
        void Crouch()
        {

        }
        void MoveLeft()
        {

        }
        void MoveRight()
        {
            mario.State = new RightSuperMarioClimbingState(mario);
        }
        void PowerUp()
        {
            mario.State = new LeftFireMarioClimbingState(mario);
        }
        void Damage()
        {
            mario.State = new LeftMarioClimbingState(mario);
        }
    }
}
