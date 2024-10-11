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
using Sprint_2.GameObjects;
using Sprint_2.Collision;
using SprintZero.LevelLoader;
using Sprint_2.ScreenCamera;


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

        public IPlayer mario { get; set; }
        private KeyboardControl keyControl;


        private GameObjectManager objectManager;

        private List<IBlock> blocks;

        private List<IBlock> collisionTest;
        
        private Camera camera;
        private Vector2 levelBounds;

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
            levelBounds = new Vector2(5000, 1080); 

            // Initialize the camera with the current viewport and level bounds
            camera = new Camera(GraphicsDevice.Viewport, levelBounds);

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);


            MarioSpriteFactory.Instance.LoadAllContent(Content);

            EnemyFactory.Instance.LoadAllContent(Content);
            ItemFactory.Instance.LoadItemContent(Content);

            mario = new Player(new Vector2(400, 100));

            objectManager = new GameObjectManager(mario);
            ItemFactory.Instance.SetGameObjectManager(objectManager);
            BlockFactory.Instance.SetGameObjectManager(objectManager);
            EnemyFactory.Instance.SetGameObjectManager(objectManager);
            Texture2D texture = Content.Load<Texture2D>("marioSpriteSheet");

            BlockFactory.Instance.LoadAllContent(Content);
            collisionTest = new List<IBlock> {

                new Block("BrownGround", new Vector2(600, 400)),
                new Block("BrownGround", new Vector2(600, 352)),
                new Block("BrownGround", new Vector2(552, 400)),
                new Block("BrownGround", new Vector2(504, 400)),
                new Block("BrownGround", new Vector2(456, 400)),
                new Block("BrownGround", new Vector2(408, 400)),
                new Block("BrownGround", new Vector2(360, 400)),
                new Block("BrownGround", new Vector2(312, 400)),
                new Block("BrownGround", new Vector2(264, 400)),
                new Block("BrownGround", new Vector2(216, 400)),
                new Block("BrownGround", new Vector2(168, 400)),
                new Block("BrownGround", new Vector2(120, 400)),
                new Block("BrownGround", new Vector2(72, 400)),
                new Block("BrownGround", new Vector2(72, 352)),
                new Block("BrownBrickWithStar", new Vector2(408, 200)),
                //new Block("BrownBrickWithStar", new Vector2(408, 200)),
                //new Block("BrownBrickWithCoins", new Vector2(360, 200)),
                //new Block("Chiseled", new Vector2(0,0))
            };



            
            //Will eventually be moved somewhere else
            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingDownCommand(mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingRightCommand(mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingLeftCommand(mario));



            keyControl.RegisterOnPressCommand(Keys.Z, new MarioAttackNormalCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.D3, new MarioPowerUpCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.E, new MarioHurtCommand(mario));
            keyControl.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyControl.RegisterCommand(Keys.R, new ResetCommand(this));

            keyControl.RegisterOnReleaseCommand(Keys.S, new MarioOnCrouchRelease(mario));
            keyControl.RegisterOnPressCommand(Keys.S, new MarioOnCrouchPress(mario));

            //EnemyFactory.Instance.AddKoopa(new Vector2(360, 250));
            EnemyFactory.Instance.AddGoomba(new Vector2(550, 20));
            
        }
        protected override void UnloadContent()
        {
            Content.Unload();
            keyControl.ClearCommands();
        }

        protected override void Update(GameTime gameTime)
        {

            keyControl.Update();
           // mario.Update(gameTime);

            // Update camera based on Mario's position
            camera.Update(gameTime, new Vector2(mario.XPos, mario.YPos));

            objectManager.Update(gameTime);

            // Collision detection
            foreach (IBlock block in collisionTest){
                //block.Update(gameTime);
                if (mario.GetHitBox().Intersects(block.GetHitBox()))
                {
                    BlockCollisionResponse.BlockReponseForPlayer(mario, block);
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Begin the sprite batch with the camera's transformation matrix
            spriteBatch.Begin(transformMatrix: camera.Transform);

          //  mario.Draw(spriteBatch, Color.White);
            HitBoxRectangle.DrawRectangle(spriteBatch, mario.GetHitBox(), Color.Black, 1);
            
            /* Added for testing */
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
