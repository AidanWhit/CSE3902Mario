using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_0.Sprites.MarioStates;
using Sprint_2.Sprites.MarioStates.RightFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_2.Sprites.MarioStates.LeftFacing.SuperMario;

namespace Sprint_2.Sprites.MarioStates.LeftFacing.Mario
{
    public class LeftMarioFallingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftMarioFallingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftMarioJumpingSprite();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gameTime)
        {
            mario.Fall();
            sprite.Update(gameTime);
        }

        public void Crouch()
        {
            mario.State = new LeftMarioIdleState(mario);
        }

        public void Jump()
        {

        }
        public void MoveLeft()
        {

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
            mario.State = new LeftSuperMarioFallingState(mario);
        }
    }
}
