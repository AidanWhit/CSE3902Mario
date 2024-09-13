using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Sprites
{
    internal class TextSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private SpriteFont font;

        public TextSprite(SpriteFont font) {
            this.font = font;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Credits \n Program made by Hahn Suh Choi \n Sprites from https://www.spriters-resource.com/snes/kirbysuperstarkirbysfunpak/sheet/52859/", location, Color.Black);
            spriteBatch.End();
        }
    }
}
