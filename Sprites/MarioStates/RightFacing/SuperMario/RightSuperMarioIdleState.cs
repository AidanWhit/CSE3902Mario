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
    public class RightSuperMarioIdleState : IMarioState
    {
        private Player mario;
        private ISprite sprite;
        public RightSuperMarioIdleState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightSuperMarioIdleSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Crouch()
        {
            mario.State = new RightSuperMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new RightSuperMarioJumpingState(mario);
        }

        public void MoveLeft()
        {
            mario.State = new LeftSuperMarioIdleState(mario);
        }
        public void MoveRight()
        {
            mario.State = new RightSuperMarioRunningState(mario);
        }
        public void Damage()
        {
            mario.State = new RightMarioIdleState(mario);
        }
        public void PowerUp()
        {
            mario.State = new RightFireMarioIdleState(mario);
        }
    }
}
