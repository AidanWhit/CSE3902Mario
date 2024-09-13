using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sprint_0.Interfaces
{
    public interface IMarioState
    {
        void Jump()
        {
            
        }
        void Crouch()
        {

        }
        void MoveLeft()
        {

        }
        void MoveRight()
        {

        }
        void Damage()
        {

        }
        void PowerUp()
        {

        }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
