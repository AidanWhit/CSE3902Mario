using Sprint_2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sprint_2.Sprites.EnemySprites;

namespace Sprint_2.Interfaces
{
    public interface IItem
    {
        Vector2 Position { get; set; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void DeleteItem();
    }

}
