using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.Mario
{
    public class LeftMarioIdleState : IMarioState
    {
        private Player mario;
        private ISprite sprite;
        public LeftMarioIdleState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftMarioIdleSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Vector2 marioLocation = new Vector2(mario.XPos, mario.YPos);
            sprite.Draw(spriteBatch, marioLocation);
        }
        public void Fall() { }
        public void Crouch()
        {
            mario.State = new LeftMarioCrouchingState(mario);
        }
        
        public void Jump()
        {
            mario.State = new LeftMarioJumpingState(mario);
        }

        public void MoveLeft()
        {
            mario.State = new LeftMarioRunningState(mario);
        }
        public void MoveRight() 
        {
            mario.State = new RightMarioIdleState(mario);
        }
        public void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
        public void PowerUp()
        {
            mario.State = new LeftSuperMarioIdleState(mario);
        }
    }
}
