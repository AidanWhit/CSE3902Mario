using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Commands;
using Sprint_0.Commands.BlockCommands;
using Sprint_0.Commands.ItemCommands;
using Sprint_0.Commands.MarioItemCommands;
using Sprint_0.Commands.MarioMovementCommands;
using Sprint_0.Commands.MarioAttackCommands;
using Sprint_0.Commands.ProgramCommands;
using Sprint_0.Controls;
using Sprint_0.Factories;
using Sprint_0.Sprites;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using System.Collections;
using System.Diagnostics;
using Sprint_0.Commands.EnemyCommands;

namespace Sprint_0
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ISprite currentSprite;

        private Player mario;
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


            MarioSpriteFactory.Instance.LoadAllContent(Content);

            mario = new Player(new Vector2(400, 300));
            
            Texture2D texture = Content.Load<Texture2D>("marioSpriteSheet");

            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(this, mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingDownCommand(this, mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingRightCommand(this, mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingLeftCommand(this, mario));
            keyControl.RegisterCommand(Keys.Z, new MarioAttackNormalCommand(this, texture));
            keyControl.RegisterCommand(Keys.N, new MarioAttackSpecialCommand(this, texture));
            keyControl.RegisterCommand(Keys.D1, new MarioItem1Command(this, texture));
            keyControl.RegisterCommand(Keys.D2, new MarioItem2Command(this, texture));
            keyControl.RegisterCommand(Keys.D3, new MarioItem3Command(this, texture));
            keyControl.RegisterCommand(Keys.E, new MarioHurtCommand(this, texture));
            keyControl.RegisterCommand(Keys.T, new CycleBlockLeftCommand(this, texture));
            keyControl.RegisterCommand(Keys.Y, new CycleBlockRightCommand(this, texture));
            keyControl.RegisterCommand(Keys.U, new CycleItemLeftCommand(this, texture));
            keyControl.RegisterCommand(Keys.I, new CycleItemRightCommand(this, texture));
            keyControl.RegisterCommand(Keys.O, new CycleEnemyLeftCommand(this, texture));
            keyControl.RegisterCommand(Keys.P, new CycleEnemyRightCommand(this, texture));
            keyControl.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyControl.RegisterCommand(Keys.R, new ResetCommand(this));
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {

            keyControl.Update();
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
