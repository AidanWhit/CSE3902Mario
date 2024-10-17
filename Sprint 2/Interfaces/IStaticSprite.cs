using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sprint_2.Interfaces
{
    public interface IStaticSprite  : IDrawable
    {
        Vector2 Position { get; set; }
        //public void Update(GameTime gameTime);
        //public void Draw(SpriteBatch spriteBatch, Vector2 vector2, Color color);
        //public void Draw(SpriteBatch spriteBatch, Color color);
    }

}
