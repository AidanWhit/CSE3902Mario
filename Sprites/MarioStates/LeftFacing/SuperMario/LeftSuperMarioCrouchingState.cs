using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario
{
    public class LeftSuperMarioCrouchingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftSuperMarioCrouchingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftSuperMarioCrouchingSprite();
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Jump()
        {
            mario.State = new LeftSuperMarioIdleState(mario);
        }
        public void Crouch()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {
            mario.State = new RightSuperMarioCrouchingState(mario);
        }
        public void Damage()
        {
            mario.State = new LeftMarioCrouchingState(mario);
        }
        public void PowerUp()
        {
            mario.State = new LeftFireMarioCrouchingState(mario);
        }
    }
}
