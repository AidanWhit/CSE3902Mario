using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.Mario
{
    public class LeftMarioClimbingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftMarioClimbingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftMarioClimbingSprite();
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
            mario.State = new LeftMarioJumpingState(mario);
        }
        public void Fall() { }
        void Crouch()
        {

        }
        void MoveLeft()
        {

        }
        void MoveRight()
        {
            mario.State = new RightMarioClimbingState(mario);
        }
        void PowerUp()
        {
            mario.State = new LeftSuperMarioClimbingState(mario);
        }
        void Damage()
        {
            mario.State = new DeadMarioState(mario);
        }
    }
}
