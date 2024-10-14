using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.LevelLoader;
using System.ComponentModel.DataAnnotations;

namespace Sprint_2.Factories
{
    public class BackgroundFactory
    {
        // Background sprites and level image
        private Texture2D bush1Texture;
        private Texture2D bush2Texture;
        private Texture2D hill1Texture;
        private Texture2D hill2Texture;
        private Texture2D cloud1Texture;
        private Texture2D cloud2Texture;
        private Texture2D levelImageTexture;  // The whole level image (blocks and background only)


        private static BackgroundFactory instance = new BackgroundFactory();
        private GameObjectManager objectManager;
        public static BackgroundFactory Instance => instance;

        // Load all the background textures 
        public void LoadAllContent(ContentManager content)
        {
            bush1Texture = content.Load<Texture2D>("bush1"); //sprite for 1 bush
            bush2Texture = content.Load<Texture2D>("bush2"); //sprite for 2 bushes
            hill1Texture = content.Load<Texture2D>("hill1"); //sprite for small hill
            hill2Texture = content.Load<Texture2D>("hill2"); //sprite for big hill
            cloud1Texture = content.Load<Texture2D>("cloud1"); //sprite for 1 cloud
            cloud2Texture = content.Load<Texture2D>("cloud2"); //sprite for 2 clouds
            levelImageTexture = content.Load<Texture2D>("levelimage"); //sprite for the whole level image  
        }

        public void SetGameObjectManager(GameObjectManager gameObjectManager)
        {
            objectManager = gameObjectManager;
        }

        // Add methods for background objects
        public void AddBush1(Vector2 location)
        {
            IStaticSprite bush1 = CreateBush1(location);
            objectManager.AddBackground(bush1);  // Pass location to the object manager
        }

        public void AddBush2(Vector2 location)
        {
            IStaticSprite bush2 = CreateBush2(location);
            objectManager.AddBackground(bush2);  // Pass location to the object manager
        }

        public void AddHill1(Vector2 location)
        {
            IStaticSprite hill1 = CreateHill1(location);
            objectManager.AddBackground(hill1);  // Pass location to the object manager
        }

        public void AddHill2(Vector2 location)
        {
            IStaticSprite hill2 = CreateHill2(location);
            objectManager.AddBackground(hill2 );  // Pass location to the object manager
        }

        public void AddCloud1(Vector2 location)
        {
            IStaticSprite cloud1 = CreateCloud1(location);
            objectManager.AddBackground(cloud1);  // Pass location to the object manager
        }

        public void AddCloud2(Vector2 location)
        {
            IStaticSprite cloud2 = CreateCloud2(location);
            objectManager.AddBackground(cloud2 );  // Pass location to the object manager
        }

        public void AddLevelImage(Vector2 location)
        {
            IStaticSprite levelImage = CreateLevelImage(location);
            objectManager.AddBackground(levelImage );  // Pass location to the object manager
        }


        public IStaticSprite CreateBush1(Vector2 location)
        {
            return new StaticSprite(bush1Texture, new Rectangle[] { new Rectangle(0, 0, bush1Texture.Width, bush1Texture.Height) }, location);
        }

        public IStaticSprite CreateBush2(Vector2 location)
        {
            return new StaticSprite(bush2Texture, new Rectangle[] { new Rectangle(0, 0, bush2Texture.Width, bush2Texture.Height) }, location);
        }

        public IStaticSprite CreateHill1(Vector2 location)
        {
            return new StaticSprite(hill1Texture, new Rectangle[] { new Rectangle(0, 0, hill1Texture.Width, hill1Texture.Height) }, location);
        }

        public IStaticSprite CreateHill2(Vector2 location)
        {
            return new StaticSprite(hill2Texture, new Rectangle[] { new Rectangle(0, 0, hill2Texture.Width, hill2Texture.Height) }, location);
        }

        public IStaticSprite CreateCloud1(Vector2 location)
        {
            return new StaticSprite(cloud1Texture, new Rectangle[] { new Rectangle(0, 0, cloud1Texture.Width, cloud1Texture.Height) }, location);
        }

        public IStaticSprite CreateCloud2(Vector2 location)
        {
            return new StaticSprite(cloud2Texture, new Rectangle[] { new Rectangle(0, 0, cloud2Texture.Width, cloud2Texture.Height) }, location);
        }

        public IStaticSprite CreateLevelImage(Vector2 location)
        {
            return new StaticSprite(levelImageTexture, new Rectangle[] { new Rectangle(0, 0, levelImageTexture.Width, levelImageTexture.Height) }, location);
        }

    }
    
}

