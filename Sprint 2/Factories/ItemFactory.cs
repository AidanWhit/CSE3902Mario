using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System.Collections;
using SprintZero.LevelLoader;
using Sprint_2.GameObjects.ItemSprites;

namespace Sprint_2.Factories
{
    public class ItemFactory
    {
        private IItem currItem;
        private static ItemFactory instance = new ItemFactory();
        private Texture2D texture;
        private int width, height;
        private Rectangle[] source;

        private Vector2 size;

        /* Added for testing */
        private GameObjectManager gameObjectManager;

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
            size = new Vector2(width, height);
        }

        public ISprite CreateRedMushroom()
        {
            source = new Rectangle[] { new Rectangle(0, 0, width, height) };
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateGreenMushroom()
        {
            source = new Rectangle[] { new Rectangle(width, 0, width, height)};
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateFlower()
        {
            source = new Rectangle[] { new Rectangle(0, height, width, height), new Rectangle(width, height, width, height), 
                new Rectangle(width *2, height, width, height), new Rectangle(width *3, height, width, height) };
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateStar()
        {
            source = new Rectangle[] { new Rectangle(0, height * 2, width, height), new Rectangle(width, height * 2, width, height),
                new Rectangle(width *2, height *2, width, height), new Rectangle(width * 3, height * 2, width, height)};
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateCoin()
        {
            source = new Rectangle[] { new Rectangle(0, height * 3, width, height), new Rectangle(width, height * 3, width, height),
                new Rectangle(width * 2, height * 3, width, height),  new Rectangle(width * 3, height * 3, width, height)};
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        /* Methods below added for testing */
        public void SetGameObjectManager(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager  = gameObjectManager;
        }

        public void AddCoinToItemsList(Vector2 location)
        {
            gameObjectManager.AddItem(new Coin(location, gameObjectManager));
        }

        public void AddRedMushroomToItemsList(Vector2 location, IBlock block)
        {
            gameObjectManager.AddItem(new RedMushroom(location, block));
        }

        public void AddFireFlowerToItemsList(Vector2 location)
        {
            gameObjectManager.AddItem(new Flower(location));
        }
    }
}
