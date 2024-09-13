using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Commands;
using Sprint_0.Commands.BlockCommands;
using Sprint_0.Commands.LinkMovementCommands;
using Sprint_0.Commands.ProgramCommands;
using Sprint_0.Controls;
using Sprint_0.Sprites;
using System.Collections;

namespace Sprint_0
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ISprite currentSprite;
        private ISprite fontSprite;
        private KeyboardControl keyControl;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyControl = new KeyboardControl();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("kirby 2");
            fontSprite = new TextSprite(Content.Load<SpriteFont>("Credit"));
            currentSprite = new Sprite1(texture, 1, 2);

            keyControl.RegisterCommand(Keys.D0, new QuitCommand(this));
            keyControl.RegisterCommand(Keys.D1, new LinkFacingUpCommand(this, texture));
            keyControl.RegisterCommand(Keys.D2, new LinkFacingDownCommand(this, texture));
            keyControl.RegisterCommand(Keys.D3, new LinkFacingRightCommand(this, texture));
            keyControl.RegisterCommand(Keys.D4, new LinkFacingLeftCommand(this, texture));
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            keyControl.Update();
            currentSprite.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            fontSprite.Draw(spriteBatch, new Vector2(100, 400));
            currentSprite.Draw(spriteBatch, new Vector2(375, 200));
            base.Draw(gameTime);
        }

        public void SetSprite (ISprite sprite)
        {
            currentSprite = sprite;
        }
    }
}
