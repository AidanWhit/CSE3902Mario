using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Misc
{
    public class Flag : Interfaces.IDrawable
    {
        private ISprite flagSprite;
        private float XPos;
        private float YPos;

        public Flag(Vector2 location)
        {
            XPos = location.X;
            YPos = location.Y;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            flagSprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public void SetXPos(float newXPos)
        {
            XPos = newXPos;
        }

        public void SetYPos(float newYPos)
        {
            YPos = newYPos;
        }
    }
}
