using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;

namespace Sprint_0.Sprites.MarioStates.RightFacing.FireMario
{
    public class RightFireMarioIdleState : IMarioState
    {
        private Player mario;
        private ISprite sprite;
        public RightFireMarioIdleState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightFireMarioIdleSprite();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Fall() { }

        public void Crouch()
        {
            mario.State = new RightFireMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new RightFireMarioJumpingState(mario);
        }

        public void MoveLeft()
        {
            mario.State = new LeftFireMarioIdleState(mario);
        }
        public void MoveRight()
        {
            mario.State = new RightFireMarioRunningState(mario);
        }
        public void Damage()
        {
            mario.State = new RightSuperMarioIdleState(mario);
        }
        public void PowerUp()
        {

        }
    }
}
