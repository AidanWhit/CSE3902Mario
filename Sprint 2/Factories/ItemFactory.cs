using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System.Collections;
using Sprint_2.LevelManager;
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
            texture = content.Load<Texture2D>("items");
        }

        public ISprite CreateRedMushroom()
        {
            source = new Rectangle[] { new Rectangle(184, 34, 16, 16) };
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateGreenMushroom()
        {
            source = new Rectangle[] { new Rectangle(214, 34, 16, 16)};
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateFlower()
        {
            source = new Rectangle[] { new Rectangle(4, 64, 16, 16), new Rectangle(34, 64, 16, 16), 
                new Rectangle(64, 64, 16, 16), new Rectangle(94, 64, 16, 16) };
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateStar()
        {
            source = new Rectangle[] { new Rectangle(5, 94, 14, 16), new Rectangle(35, 94, 14, 16),
                new Rectangle(65, 94, 14, 16), new Rectangle(95, 94, 14, 16)};
            return new FrameArrayFormattedSprite(texture, source, 1);
        }

        public ISprite CreateCoin()
        {
            source = new Rectangle[] { new Rectangle(128, 95, 8, 14), new Rectangle(160, 95, 4, 14),
                new Rectangle(191, 95, 1, 14),  new Rectangle(220, 95, 4, 14)};
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

        public void AddGreenMushroomToItemsList(Vector2 location, IBlock block)
        {
            gameObjectManager.AddItem(new GreenMushroom(location, block));
        }

        public void AddStarToItemsList(Vector2 location, IBlock block)
        {
            gameObjectManager.AddItem(new Star(location, block));
        }

        public void RemoveFromItemsList(IItem item)
        {
            gameObjectManager.RemoveItem(item);
        }

        public void AddFireFlowerToItemsList(Vector2 location, IBlock block)
        {
            gameObjectManager.AddItem(new Flower(location, block));
        }
    }
}
