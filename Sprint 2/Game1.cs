using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint_2.Commands.BlockCommands;
using Sprint_2.Commands.ItemCommands;
using Sprint_2.Commands.MarioItemCommands;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Commands.MarioAttackCommands;
using Sprint_2.Commands.ProgramCommands;
using Sprint_2.Controls;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Commands.EnemyCommands;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Sprites.EnemySprites;

namespace Sprint_2
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

        private List<IBlock> blocks;

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
                new Goomba(new Vector2(100, 100)),
                EnemyFactory.Instance.CreateKoopa(new Vector2(100, 100)),
                EnemyFactory.Instance.CreateKoopaShell(new Vector2(100, 100)),
                EnemyFactory.Instance.CreateBowser(new Vector2(100, 100))
            };
            enemyCycler = new EnemyCycler(enemies);
            currentEnemy = enemies[0];

            items = new List<IItem>
            {
                new RedMushroom(new Vector2(100, 300)),
                new GreenMushroom(new Vector2(100, 300)),
                new Flower(new Vector2(100, 300)),
                new Coin(new Vector2(100, 300)),
                new Star(new Vector2(100, 300))

            };
            itemCycler = new ItemCycler(items);
            currItem = items[0];


            // TODO: make this into a list
            BlockFactory.Instance.LoadAllContent(Content);
            blocks = new List<IBlock> {
                BlockFactory.Instance.createQuestionBlock(new Vector2(600, 300)),
                BlockFactory.Instance.createBrickBlock(new Vector2(600, 316)),
                BlockFactory.Instance.createHitBlock(new Vector2(600, 332)),
                BlockFactory.Instance.createGroundBlock(new Vector2(600, 348))
            };
            

            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(this, mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingDownCommand(this, mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingRightCommand(this, mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingLeftCommand(this, mario));
            keyControl.RegisterOnPressCommand(Keys.Z, new MarioAttackNormalCommand(this, mario));
            keyControl.RegisterCommand(Keys.N, new MarioAttackSpecialCommand(this, texture));
            keyControl.RegisterCommand(Keys.D1, new MarioItem1Command(this, texture));
            keyControl.RegisterCommand(Keys.D2, new MarioItem2Command(this, texture));
            keyControl.RegisterOnPressCommand(Keys.D3, new MarioItem3Command(this, mario));
            keyControl.RegisterOnPressCommand(Keys.E, new MarioHurtCommand(this, mario));
            keyControl.RegisterOnPressCommand(Keys.T, new CycleBlockLeftCommand(this, texture));
            keyControl.RegisterOnPressCommand(Keys.Y, new CycleBlockRightCommand(this, texture));
            keyControl.RegisterOnPressCommand(Keys.U, new CycleItemLeftCommand(this, texture));
            keyControl.RegisterOnPressCommand(Keys.I, new CycleItemRightCommand(this, texture));
            keyControl.RegisterOnPressCommand(Keys.O, new CycleEnemyLeftCommand(this, texture));
            keyControl.RegisterOnPressCommand(Keys.P, new CycleEnemyRightCommand(this, texture));
            keyControl.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyControl.RegisterCommand(Keys.R, new ResetCommand(this));

            keyControl.RegisterOnReleaseCommand(Keys.S, new MarioOnCrouchRelease(mario));
            keyControl.RegisterOnPressCommand(Keys.S, new MarioOnCrouchPress(mario));
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
            currItem.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mario.Draw(spriteBatch);

            // Modified on 9/16 by Jingyu Fu, draw goomba
            //goomba.Draw(spriteBatch, goomba.Position);
            //koopa.Draw(spriteBatch, koopa.Position);
            //shell.Draw(spriteBatch, shell.Position); 
            //bowser.Draw(spriteBatch, bowser.Position);
            currentEnemy.Draw(spriteBatch, currentEnemy.Position, Color.White);
            currItem.Draw(spriteBatch);

            blocks[0].Draw(spriteBatch, blocks[0].position, Color.White);
            blocks[1].Draw(spriteBatch, blocks[1].position, Color.White);
            blocks[2].Draw(spriteBatch, blocks[2].position, Color.White);
            blocks[3].Draw(spriteBatch, blocks[3].position, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reload()
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
