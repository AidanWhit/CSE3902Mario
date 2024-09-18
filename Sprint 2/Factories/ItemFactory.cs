using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_0.Sprites;
using Sprint_0.Sprites.EnemySprites;
using Sprint_0.Interfaces;

namespace Sprint_0.Factories
{
    public class ItemFactory
    {
        private static ItemFactory instance = new ItemFactory();

        private Texture2D goombaWalking1;
        private Texture2D goombaWalking2;
        private Texture2D goombaDying;

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

        public void LoadAllContent(ContentManager content)
        {
            goombaWalking1 = content.Load<Texture2D>("MarioItems");
        }

        //public IItem CreateItem(Vector2 position)
        //{
        //}
    }
}
