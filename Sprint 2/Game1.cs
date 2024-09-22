using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint_0.Commands;
using Sprint_0.Commands.BlockCommands;
using Sprint_0.Commands.ItemCommands;
using Sprint_0.Commands.MarioItemCommands;
using Sprint_0.Commands.MarioMovementCommands;
using Sprint_0.Commands.MarioAttackCommands;
using Sprint_0.Commands.ProgramCommands;
using Sprint_0.Controls;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;
using Sprint_0.Commands.EnemyCommands;
using Sprint_2.Sprites;

namespace Sprint_0
{

    public class Game1 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ISprite currentSprite;

        private Player mario;
        private KeyboardControl keyControl;

        private IEnemy goomba;
        // Modified 9/19
        private IEnemy koopa;
        private IEnemy shell;
        // Modified 9/20
        private IEnemy bowser;
        private EnemyCycler enemyCycler;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private ItemCycler itemCycler;
        private IEnemy currentEnemy;
        private IItem currItem;

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

            // Modified on 9/16 by Jingyu Fu, added a factory for enemies
            EnemyFactory.Instance.LoadAllContent(Content);
            ItemFactory.Instance.LoadItemContent(Content);

            mario = new Player(new Vector2(400, 200));
            Texture2D texture = Content.Load<Texture2D>("marioSpriteSheet");

            // Modified on 9/16 by Jingyu Fu, create a Goomba 
            // Modified on 9/16 by Jingyu Fu, create a Koopa and shell 
            //goomba = EnemyFactory.Instance.CreateGoomba(new Vector2(100, 100));
            //koopa = EnemyFactory.Instance.CreateKoopa(new Vector2(100, 100));
            //shell = EnemyFactory.Instance.CreateKoopaShell(new Vector2(100, 100));
            // Modified on 9/20 by Jingyu Fu, create a bowser
            //bowser = EnemyFactory.Instance.CreateBowser(new Vector2(100, 100));
            enemies = new List<IEnemy>
            {
                EnemyFactory.Instance.CreateGoomba(new Vector2(100, 100)),
                EnemyFactory.Instance.CreateKoopa(new Vector2(100, 100)),
                EnemyFactory.Instance.CreateKoopaShell(new Vector2(100, 100)),
                EnemyFactory.Instance.CreateBowser(new Vector2(100, 100))
            };
            enemyCycler = new EnemyCycler(enemies);
            currentEnemy = enemies[0];

            items = new List<IItem>
            {
                ItemFactory.Instance.CreateRedMushroom(new Vector2(100, 100)),
                ItemFactory.Instance.CreateGreenMushroom(new Vector2(100, 100)),
                ItemFactory.Instance.CreateFlower(new Vector2(100, 100)),
                ItemFactory.Instance.CreateStar(new Vector2(100, 100)),
                ItemFactory.Instance.CreateCoin(new Vector2(100, 100))
            };
            itemCycler = new ItemCycler(items);
            currItem = items[0];


            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(this, mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingDownCommand(this, mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingRightCommand(this, mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingLeftCommand(this, mario));
            keyControl.RegisterCommand(Keys.Z, new MarioAttackNormalCommand(this, mario));
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
            keyControl.ClearCommands();
        }

        protected override void Update(GameTime gameTime)
        {

            keyControl.Update();
            mario.Update(gameTime);

            // Modified on 9/16 by Jingyu Fu, update enemies
            //goomba.Update(gameTime);
            //koopa.Update(gameTime);
            //shell.Update(gameTime);
            //bowser.Update(gameTime);
            currentEnemy.Update(gameTime);
            currItem.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mario.Draw(spriteBatch, new Vector2(mario.XPos, mario.YPos));

            // Modified on 9/16 by Jingyu Fu, draw goomba
            //goomba.Draw(spriteBatch, goomba.Position);
            //koopa.Draw(spriteBatch, koopa.Position);
            //shell.Draw(spriteBatch, shell.Position); 
            //bowser.Draw(spriteBatch, bowser.Position);
            currentEnemy.Draw(spriteBatch, currentEnemy.Position);
            currItem.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void reload ()
        {
            this.UnloadContent();
            this.LoadContent();
        }

        public void CycleEnemyLeft()
        {
            currentEnemy = enemyCycler.CycleEnemyLeft(); 
        }

        public void CycleEnemyRight()
        {
            currentEnemy = enemyCycler.CycleEnemyRight(); 
        }

        public void CycleItemLeft()
        {
            currItem = itemCycler.CycleItemLeft();
        }

        public void CycleItemRight()
        {
            currItem = itemCycler.CycleItemRight();
        }
    }
}
