using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_2.Sprites.MarioStates.RightFacing.SuperMario;
using System.ComponentModel.DataAnnotations;


namespace Sprint_2.Sprites.MarioStates.RightFacing.FireMario
{
    public class RightFireMarioFallingState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public RightFireMarioFallingState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.RightFireMarioJumpingSprite();
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
            mario.State = new RightFireMarioIdleState(mario);
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
            mario.State = new RightSuperMarioFallingState(mario);
        }

        public void PowerUp()
        {

        }
    }
}
