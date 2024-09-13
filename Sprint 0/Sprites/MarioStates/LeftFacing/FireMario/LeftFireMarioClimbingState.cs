using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_0.Interfaces;
using Sprint_0.Factories;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.LeftFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.SuperMario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;

namespace Sprint_0.Sprites.MarioStates.LeftFacing.FireMario
{
    public class LeftFireMarioClimbingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public LeftFireMarioClimbingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.LeftFireMarioClimbingSprite();
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
            mario.State = new RightFireMarioJumpingState(mario);
        }
        void Crouch()
        {

        }
        void MoveLeft()
        {

        }
        void MoveRight()
        {
            mario.State = new RightFireMarioClimbingState(mario);
        }
        void PowerUp()
        {
            
        }
        void Damage()
        {
            mario.State = new LeftSuperMarioClimbingState(mario);
        }
    }
}
