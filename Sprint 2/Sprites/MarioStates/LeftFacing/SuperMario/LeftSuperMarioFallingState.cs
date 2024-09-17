using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites;
using Sprint_2.Sprites.MarioStates.RightFacing.SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_2.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;

namespace Sprint_2.Sprites.MarioStates.LeftFacing.SuperMario
{
    public class LeftSuperMarioFallingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftSuperMarioFallingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftSuperMarioJumpingSprite();
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
            mario.State = new LeftSuperMarioIdleState(mario);
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
            mario.State = new LeftMarioFallingState(mario);
        }

        public void PowerUp()
        {
            mario.State = new LeftFireMarioFallingState(mario);
        }
    }
}
