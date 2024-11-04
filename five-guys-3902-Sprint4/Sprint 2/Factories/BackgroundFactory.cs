using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.GameObjects;
using System.ComponentModel.DataAnnotations;
using Sprint_2.LevelManager;

namespace Sprint_2.Factories
{
    public class BackgroundFactory
    {
        // Background sprites and level image
        private Texture2D levelImageTexture;  // The whole level image (blocks and background only)
        private Texture2D backgroundSprites;
        private Texture2D flagSprite;


        private static BackgroundFactory instance = new BackgroundFactory();
        private GameObjectManager objectManager;
        public static BackgroundFactory Instance => instance;

        // Load all the background textures 
        public void LoadAllContent(ContentManager content)
        {
            levelImageTexture = content.Load<Texture2D>("levelimage"); //sprite for the whole level image  
            backgroundSprites = content.Load<Texture2D>("backgroundSprites");
            flagSprite = content.Load<Texture2D>("flag");
        }

        public ISprite CreateUndergroundPipe()
        {
            return new FrameArrayFormattedSprite(backgroundSprites, new Rectangle[] { new Rectangle(84, 321, 62, 128) }, 1);
        }
        public ISprite CreateFlag()
        {
            return new FrameArrayFormattedSprite(flagSprite, new Rectangle[] { new Rectangle(0, 0, flagSprite.Width, flagSprite.Height) }, 1);
        }
        public IStaticSprite CreateBush1(Vector2 location)
        {
            return new StaticSprite(backgroundSprites, new Rectangle[] { new Rectangle(288, 24, 32, 16) }, location);
        }

        public IStaticSprite CreateBush2(Vector2 location)
        {
            return new StaticSprite(backgroundSprites, new Rectangle[] { new Rectangle(220, 24, 64, 16) }, location);
        }

        public IStaticSprite CreateHill1(Vector2 location)
        {
            return new StaticSprite(backgroundSprites, new Rectangle[] { new Rectangle(169, 21, 48, 19) }, location);
        }

        public IStaticSprite CreateHill2(Vector2 location)
        {
            return new StaticSprite(backgroundSprites, new Rectangle[] { new Rectangle(86, 5, 80, 35) }, location);
        }

        public IStaticSprite CreateCloud1(Vector2 location)
        {
            return new StaticSprite(backgroundSprites, new Rectangle[] { new Rectangle(211, 69, 32, 24) }, location);
        }

        public IStaticSprite CreateCloud2(Vector2 location)
        {
            return new StaticSprite(backgroundSprites, new Rectangle[] { new Rectangle(144, 69, 64, 24) }, location);
        }

        public IStaticSprite CreateLevelImage(Vector2 location)
        {
            return new StaticSprite(levelImageTexture, new Rectangle[] { new Rectangle(0, 0, levelImageTexture.Width, levelImageTexture.Height) }, location);
        }

    }
    
}

