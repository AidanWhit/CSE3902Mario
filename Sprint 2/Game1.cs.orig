using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Commands;
using Sprint_0.Commands.BlockCommands;
using Sprint_0.Commands.LinkMovementCommands;
using Sprint_0.Commands.ProgramCommands;
using Sprint_0.Controls;
using Sprint_0.Factories;
using Sprint_0.Sprites;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using System.Collections;
using System.Diagnostics;

namespace Sprint_0
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ISprite currentSprite;
        private ISprite fontSprite;
<<<<<<< HEAD:Sprint 0/Game1.cs


        private Player mario;
=======
        private KeyboardControl keyControl;
>>>>>>> 5860c042f2704c061f5b03a2c2ec607d85a04c8a:Sprint 2/Game1.cs

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
<<<<<<< HEAD:Sprint 0/Game1.cs
=======
            keyControl = new KeyboardControl();
>>>>>>> 5860c042f2704c061f5b03a2c2ec607d85a04c8a:Sprint 2/Game1.cs
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
<<<<<<< HEAD:Sprint 0/Game1.cs

            MarioSpriteFactory.Instance.LoadAllContent(Content);

            mario = new Player(new Vector2(400, 200));
=======
            Texture2D texture = Content.Load<Texture2D>("kirby 2");
            fontSprite = new TextSprite(Content.Load<SpriteFont>("Credit"));
            currentSprite = new Sprite1(texture, 1, 2);

            keyControl.RegisterCommand(Keys.D0, new QuitCommand(this));
            keyControl.RegisterCommand(Keys.D1, new LinkFacingUpCommand(this, texture));
            keyControl.RegisterCommand(Keys.D2, new LinkFacingDownCommand(this, texture));
            keyControl.RegisterCommand(Keys.D3, new LinkFacingRightCommand(this, texture));
            keyControl.RegisterCommand(Keys.D4, new LinkFacingLeftCommand(this, texture));
>>>>>>> 5860c042f2704c061f5b03a2c2ec607d85a04c8a:Sprint 2/Game1.cs
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
<<<<<<< HEAD:Sprint 0/Game1.cs
            mario.Update(gameTime);
=======
            keyControl.Update();
            currentSprite.Update();

>>>>>>> 5860c042f2704c061f5b03a2c2ec607d85a04c8a:Sprint 2/Game1.cs
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mario.Draw(spriteBatch, new Vector2(mario.XPos, mario.YPos));
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void SetSprite (ISprite sprite)
        {
            currentSprite = sprite;
        }
    }
}
