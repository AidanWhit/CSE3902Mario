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
using Sprint_2.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using Sprint_2.Sprites.MarioStates.RightFacing.Mario;

namespace Sprint_2.Sprites.MarioStates.RightFacing.SuperMario
{
    public class RightSuperMarioFallingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightSuperMarioFallingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightSuperMarioJumpingSprite();
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
            mario.State = new RightSuperMarioIdleState(mario);
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
            mario.State = new RightMarioFallingState(mario);
        }

        public void PowerUp()
        {
            mario.State = new RightFireMarioFallingState(mario);
        }
    }
}
