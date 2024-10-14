using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_2.Sprites;
using Sprint_2.Sprites.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.LevelLoader;
using System.ComponentModel.DataAnnotations;

namespace Sprint_2.Factories
{
    public class EnemyFactory
    {
        private static EnemyFactory instance = new EnemyFactory();

        private Texture2D goombaWalking;
        private Texture2D goombaDying;

        // Modified 9/19 added koopa's sprites
        private Texture2D koopaWalkingLeft1;
        private Texture2D koopaWalkingLeft2;
        private Texture2D koopaWalkingRight1;
        private Texture2D koopaWalkingRight2;
        private Texture2D koopaShell;

        // Modified 9/20 added bowser
        private Texture2D[] bowserLeftSprites;
        private Texture2D[] bowserRightSprites;
        private Texture2D[] fireballLeftSprites;
        private Texture2D[] fireballRightSprites;

        private Texture2D enemies;
        private GameObjectManager objectManager;

        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyFactory()
        {
        }

        public void LoadAllContent(ContentManager content)
        {
            goombaWalking = content.Load<Texture2D>("goombaWalkingSpriteSheet");
           
            goombaDying = content.Load<Texture2D>("goomba_dying1");

            // Modified 9/19 added koopa's sprites
            koopaWalkingLeft1 = content.Load<Texture2D>("koopa_walkingleft1");
            koopaWalkingLeft2 = content.Load<Texture2D>("koopa_walkingleft2");
            koopaWalkingRight1 = content.Load<Texture2D>("koopa_walkingright1");
            koopaWalkingRight2 = content.Load<Texture2D>("koopa_walkingright2");
            koopaShell = content.Load<Texture2D>("koopa_shell");

            //Modified 9/20 added bowser
            bowserLeftSprites = new Texture2D[]
            {
                content.Load<Texture2D>("bowser_left1"),
                content.Load<Texture2D>("bowser_left2"),
                content.Load<Texture2D>("bowser_left3"),
                content.Load<Texture2D>("bowser_left4")
            };

            bowserRightSprites = new Texture2D[]
            {
                content.Load<Texture2D>("bowser_right1"),
                content.Load<Texture2D>("bowser_right2"),
                content.Load<Texture2D>("bowser_right3"),
                content.Load<Texture2D>("bowser_right4")
            };

            fireballLeftSprites = new Texture2D[]
            {
                content.Load<Texture2D>("bowser_fireballleft1"),
                content.Load<Texture2D>("bowser_fireballleft2")
            };

            fireballRightSprites = new Texture2D[]
            {
                content.Load<Texture2D>("bowser_fireballright1"),
                content.Load<Texture2D>("bowser_fireballright2")
            };

            enemies = content.Load<Texture2D>("enemies");

        }

        public void SetGameObjectManager(GameObjectManager gameObjectManager)
        {
            objectManager = gameObjectManager;
        }

        public void AddGoomba(Vector2 location)
        {
            objectManager.AddEnemy(new Goomba(location));
        }

        public void AddKoopa(Vector2 location)
        {
            objectManager.AddEnemy(new Koopa(location));
        }

        public void AddEnemy(IEnemy enemy)
        {
            objectManager.AddEnemy(enemy);
        }

        public void RemoveEnemyFromObjectList(IEnemy enemy) 
        {
            objectManager.RemoveEnemy(enemy);
        }
        public ISprite CreateGoomba()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(1, 5, 16, 16), new Rectangle(31, 5, 16, 16) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public ISprite CreateStompedGoomba()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(61, 9, 16, 8) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public ISprite CreateFlippedGoomba()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(1, 264, 16, 16), new Rectangle(19, 264, 16, 16) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public ISprite CreateLeftFacingKoopa()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(181, 1, 16, 23), new Rectangle(151, 1, 16, 24) };
            return new FrameArrayFormattedSprite (enemies, source, 3);
        }

        public ISprite CreateRightFacingKoopa()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(211, 1, 16, 23), new Rectangle(241, 1, 16, 24) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public ISprite CreateKoopaShell()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(361, 6, 16, 14) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public ISprite CreateFlippedKoopaShell()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(37, 264, 16, 13) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public ISprite CreateKoopaShellWithFeet()
        {
            Rectangle[] source = new Rectangle[] { new Rectangle(331, 5, 16, 15) };
            return new FrameArrayFormattedSprite(enemies, source, 3);
        }

        public IEnemy CreateKoopa(Vector2 position)
            {
            // Create a koopa(instance) 
            return new Koopa(position);
        }

        public IEnemy CreateKoopaShell(Vector2 position)
        {
            // Create a shell
            return new Shell(position);
        }

        public IEnemy CreateBowser(Vector2 position)
        {
            // Create a bowser
            return new Bowser(bowserLeftSprites, bowserRightSprites, fireballLeftSprites, fireballRightSprites, position);
        }
    }
}
