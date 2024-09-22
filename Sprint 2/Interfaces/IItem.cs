using Sprint_0.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sprint_0.Sprites.EnemySprites;

namespace Sprint_0.Interfaces
{
    public interface IItem
    {
        Vector2 Position { get; set; }
        Texture2D Texture { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void DeleteItem();
    }

}
