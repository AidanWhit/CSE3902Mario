using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sprint_0.Sprites;
using Sprint_2.Sprites;


namespace Sprint_0.Interfaces
{
    public interface IEnemy : ISprite
    {
        // Use Isprite first, implement other features later


        //void Update(GameTime gameTime);
        //void Draw(SpriteBatch spriteBatch);

        //TO DO:
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        //void Move();
        void TakeDamage();
    }

}
