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
using Sprint_2.Sound;
using Sprint_2.ScreenCamera;
using Sprint_2.LevelManager;
using System.Diagnostics;
using System;
using Sprint_2.Collision;
using System.Linq;
using Sprint_2.GameStates;
using Sprint_2.Constants;


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


        private List<IBlock> blocks;

        private List<IBlock> collisionTest;


        public Camera camera { get; private set; }
        private Vector2 levelBounds;
        private LevelLoader levelLoader;
        private CollisionDetection collisionDetection;
        public IGameState gameState { get; set; }
        public CollisionDetection CollisionDetection { get; private set; }

        private SpriteFont hudFont;

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

            UniversalSpriteFactory.Instance.LoadAllContent(Content);

            SoundManager.Instance.Initialize(Content);

            SoundManager.Instance.PlayBGM("mainTheme");

            mario = new Player(Vector2.Zero, MarioPhysicsConstants.startingLives);
            CollisionDetection = new CollisionDetection();
            

            camera = new Camera(GraphicsDevice.Viewport, levelBounds);



            ItemFactory.Instance.SetGameObjectManager(GameObjectManager.Instance);
            EnemyFactory.Instance.SetGameObjectManager(GameObjectManager.Instance);

            levelLoader = new LevelLoader();
            levelLoader.LoadLevel(@"LevelManager\level-1_data_pretty.xml");

            gameState = new PlayableState(keyControl);
        }
        protected override void UnloadContent()
        {
            Content.Unload();
            keyControl.ClearCommands();
        }

        protected override void Update(GameTime gameTime)
        {
            gameState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // Begin the sprite batch with the camera's transformation matrix
            spriteBatch.Begin(transformMatrix: camera.Transform);

            gameState.Draw(spriteBatch, Color.White);

            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Reload()
        {
            GameObjectManager.Instance.Reset();
            mario = new Player(Vector2.Zero, mario.RemainingLives);
            InitControls.initializeControls(keyControl, mario);
            levelLoader.LoadLevel(@"LevelManager\level-1_data_pretty.xml");
            camera.Reset();
            SoundManager.Instance.Reset();
            HUD.Instance.ResetTime();
            //UnloadContent();
            //LoadContent();
        }

        public void TotalReset()
        {
            GameObjectManager.Instance.Reset();

            mario = new Player(Vector2.Zero, MarioPhysicsConstants.startingLives);

            InitControls.initializeControls(keyControl, mario);
            levelLoader.LoadLevel(@"LevelManager\level-1_data_pretty.xml");

            camera.Reset();
            SoundManager.Instance.Reset();
            HUD.Instance.CompleteReset();

            gameState = new PlayableState(keyControl);
            //UnloadContent();
            //LoadContent();
        }

        public Camera GetCamera()
        {
            return camera;
        }
        public KeyboardControl GetKeyboardControl()
        {
            return keyControl;
        }
    }
}
