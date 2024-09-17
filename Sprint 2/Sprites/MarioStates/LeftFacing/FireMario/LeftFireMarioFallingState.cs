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
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_2.Sprites.MarioStates.LeftFacing.SuperMario;

namespace Sprint_2.Sprites.MarioStates.LeftFacing.FireMario
{
    public class LeftFireMarioFallingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftFireMarioFallingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftFireMarioJumpingSprite();
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
            mario.State = new LeftFireMarioIdleState(mario);
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
            mario.State = new LeftSuperMarioFallingState(mario);
        }

        public void PowerUp()
        {

        }
    }
}
