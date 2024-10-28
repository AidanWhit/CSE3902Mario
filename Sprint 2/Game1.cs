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
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.GameObjects.Misc;


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


        private Camera camera;
        private Vector2 levelBounds;
        private LevelLoader levelLoader;
        private CollisionDetection collisionDetection;

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

            SoundManager.Instance.LoadAllBGM(Content);
            SoundManager.Instance.LoadAllSFX(Content);

            mario = new Player(new Vector2(100, 400));
            collisionDetection = new CollisionDetection();
            

            camera = new Camera(GraphicsDevice.Viewport, levelBounds);

            SoundManager.Instance.PlayBGM("mainTheme");

            ItemFactory.Instance.SetGameObjectManager(GameObjectManager.Instance);
            EnemyFactory.Instance.SetGameObjectManager(GameObjectManager.Instance);

            Texture2D texture = Content.Load<Texture2D>("marioSpriteSheet");


            InitControls.initializeControls(keyControl, mario, this);

            levelLoader = new LevelLoader();
            levelLoader.LoadLevel(@"LevelManager\level-1_data_pretty.xml");
            //levelLoader.LoadLevel(@"LevelManager\testing-level.xml");

            GameObjectManager.Instance.BackDrawables.Add(mario);
            GameObjectManager.Instance.Updateables.Add(mario);
            GameObjectManager.Instance.Movers.Add(mario);
        }
        protected override void UnloadContent()
        {
            Content.Unload();
            keyControl.ClearCommands();
        }

        protected override void Update(GameTime gameTime)
        {

            keyControl.Update();
            // If the game is paused, everything except keycontrol are no longer updating
            if (GameStateManager.Instance.CurrentState == GameState.Paused)
            {
                return;
            }
            // Update camera based on Mario's position
            camera.Update(gameTime, new Vector2(mario.XPos, mario.YPos));

            //mario.Update(gameTime);
            foreach (Interfaces.IUpdateable obj in GameObjectManager.Instance.Updateables.ToList())
            {
                if (obj.GetType() == typeof(Flag))
                {
                    Debug.WriteLine("Obj causing error: " + obj.GetType());
                }
                
                obj.Update(gameTime);
            }
            collisionDetection.DetectCollision();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Begin the sprite batch with the camera's transformation matrix
            spriteBatch.Begin(transformMatrix: camera.Transform);

            foreach (Interfaces.IDrawable obj in GameObjectManager.Instance.BackDrawables.ToList())
            {
                obj.Draw(spriteBatch, Color.White);
            }
            foreach (Interfaces.IDrawable obj in GameObjectManager.Instance.ForeDrawables.ToList())
            {
                obj.Draw(spriteBatch, Color.White);
            }
            //mario.Draw(spriteBatch, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reload()
        {
            GameObjectManager.Instance.Reset();
            SoundManager.Instance.Reset();
            this.UnloadContent();
            this.LoadContent();
            
            
        }
    }
}
