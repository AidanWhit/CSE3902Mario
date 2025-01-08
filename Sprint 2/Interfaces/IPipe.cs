using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Interfaces
{
    public interface IPipe
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Color color);
        public Rectangle GetHitBox();
    }
}
