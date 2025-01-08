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
    public interface IEnemy
    {
        // Use Isprite first, implement other features later


        //void Update(GameTime gameTime);
        //void Draw(SpriteBatch spriteBatch);

        //TO DO:
        public float XPos { get; set; }
        public float YPos { get; set; }
        Vector2 Velocity { get; set; }
        //void Move();
        public void TakeFireballDamage();
        public void TakeStompDamage();

        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Color color);

        public Rectangle GetHitBox();

        public void ChangeDirection();

        public bool Flipped { get; set; }
    }

}
