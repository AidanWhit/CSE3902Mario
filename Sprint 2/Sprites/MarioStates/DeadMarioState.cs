using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites.MarioStates
{
    public class DeadMarioState : IMarioState
    {
        private Player mario;
        private ISprite sprite;

        public DeadMarioState(Player mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.DeadMarioSprite();
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

        }
        public void PowerUp()
        {

        }
    }
}
