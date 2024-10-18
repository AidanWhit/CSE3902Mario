using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint_2.Commands.MarioItemCommands;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Commands.MarioAttackCommands;
using Sprint_2.Commands.ProgramCommands;
using Sprint_2.Controls;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.ScreenCamera;
using Sprint_2.LevelManager;
using System.Diagnostics;
using System;


namespace Sprint_2
{

    public class Game1 : Game
    {
        private static Game1 instance = new Game1();

        public static Game1 Instance
        {
            get
            {
                return instance;
            }
        }
       
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //TODO: Make this singular IPlayer into a list and have level loader create the player
        public IPlayer mario { get; set; }
        private KeyboardControl keyControl;


        private GameObjectManager objectManager;

        private List<IBlock> blocks;

        private List<IBlock> collisionTest;


        private Camera camera;
        private Vector2 levelBounds;
        private LevelLoader levelLoader;

        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyControl = new KeyboardControl();
            
            // Set the level bounds (adjust these values to match your level size)
            levelBounds = new Vector2(3744, 240);
            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

           
            

            MarioSpriteFactory.Instance.LoadAllContent(Content);
            EnemyFactory.Instance.LoadAllContent(Content);
            ItemFactory.Instance.LoadItemContent(Content);
            BlockFactory.Instance.LoadAllContent(Content);
            BackgroundFactory.Instance.LoadAllContent(Content);

            mario = new Player(new Vector2(100, 400));

            camera = new Camera(GraphicsDevice.Viewport, levelBounds);

            objectManager = GameObjectManager.Instance;

            levelLoader = new LevelLoader(@"LevelManager\level-1_data_pretty.xml", objectManager);
            levelLoader.LoadCommandDictionary(@"LevelManager\XMLFiles\CollisionTable.xml");
            

            ItemFactory.Instance.SetGameObjectManager(objectManager);
            BlockFactory.Instance.SetGameObjectManager(objectManager);
            EnemyFactory.Instance.SetGameObjectManager(objectManager);
            BackgroundFactory.Instance.SetGameObjectManager(objectManager);

            Texture2D texture = Content.Load<Texture2D>("marioSpriteSheet");

            


            //Will eventually be moved somewhere else
            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingDownCommand(mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingRightCommand(mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingLeftCommand(mario));



            keyControl.RegisterOnPressCommand(Keys.Z, new MarioAttackNormalCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.D3, new MarioPowerUpCommand(mario, null, Rectangle.Empty));
            keyControl.RegisterOnPressCommand(Keys.E, new MarioHurtCommand(mario, null, Rectangle.Empty));
            keyControl.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyControl.RegisterCommand(Keys.R, new ResetCommand(this));

            keyControl.RegisterOnReleaseCommand(Keys.S, new MarioOnCrouchRelease(mario));
            keyControl.RegisterOnPressCommand(Keys.S, new MarioOnCrouchPress(mario));
            keyControl.RegisterOnReleaseCommand(Keys.W, new MarioJumpReleaseCommand(mario));


           
            levelLoader.LoadLevel();

        }
        protected override void UnloadContent()
        {
            Content.Unload();
            keyControl.ClearCommands();
        }

        protected override void Update(GameTime gameTime)
        {

            keyControl.Update();

            // Update camera based on Mario's position
            camera.Update(gameTime, new Vector2(mario.XPos, mario.YPos));

            objectManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Begin the sprite batch with the camera's transformation matrix
            spriteBatch.Begin(transformMatrix: camera.Transform);
            
            objectManager.Draw(spriteBatch, null, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reload()
        {
            this.UnloadContent();
            this.LoadContent();
            
        }
    }
}
