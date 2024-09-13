using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;


namespace Sprint_0.Sprites.MarioStates.LeftFacing.FireMario
{
    public class LeftFireMarioIdleState : IMarioState
    {
        private Player mario;
        private ISprite sprite;
        public LeftFireMarioIdleState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftFireMarioIdleSprite();
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
            mario.State = new LeftFireMarioCrouchingState(mario);
        }

        public void Jump()
        {
            mario.State = new LeftFireMarioJumpingState(mario);
        }

        public void MoveLeft()
        {
            mario.State = new LeftFireMarioRunningState(mario);
        }
        public void MoveRight()
        {
            mario.State = new RightFireMarioIdleState(mario);
        }
        public void Damage()
        {
            mario.State = new LeftSuperMarioIdleState(mario);
        }
        public void PowerUp()
        {
            
        }
    }
}
