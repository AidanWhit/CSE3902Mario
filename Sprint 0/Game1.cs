using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Commands;
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


        private Player mario;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MarioSpriteFactory.Instance.LoadAllContent(Content);

            mario = new Player(new Vector2(400, 200));
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mario.Update(gameTime);
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
