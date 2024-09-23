using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_2.Sprites;
using Sprint_2.Sprites.ItemSprites;
using Sprint_2.Interfaces;
using System.Collections;

namespace Sprint_2.Factories
{
    public class ItemFactory
    {
        private IItem currItem;
        private static ItemFactory instance = new ItemFactory();
        private Texture2D texture;
        private int width, height;
        private Rectangle source;

        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemFactory()
        {
        }

        public void LoadItemContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("MarioItems");
            width = texture.Width / 4; 
            height = texture.Height / 4;
        }

        public IItem CreateRedMushroom(Vector2 position)
        {
            source = new Rectangle(0, 0, width, height);
            return new RedMushroom(texture, source, position);
        }

        public IItem CreateGreenMushroom(Vector2 position)
        {
            source = new Rectangle(width, 0, width, height);
            return new GreenMushroom(texture, source, position);
        }

        public IItem CreateFlower(Vector2 position)
        {
            source = new Rectangle(0, height, width, height);
            return new Flower(texture, source, position);
        }

        public IItem CreateStar(Vector2 position)
        {
            source = new Rectangle(0, height * 2, width, height);
            return new Star(texture, source, position);
        }

        public IItem CreateCoin(Vector2 position)
        {
            source = new Rectangle(0, height * 3, width, height);
            return new Coin(texture, source, position);
        }
    }
}
