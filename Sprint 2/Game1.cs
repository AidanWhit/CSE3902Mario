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
using Sprint_2.GameObjects;
using System.Diagnostics;

namespace Sprint_2
{

    public class Game1 : Game
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player mario;
        private KeyboardControl keyControl;

        private EnemyCycler enemyCycler;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private ItemCycler itemCycler;
        private IEnemy currentEnemy;
        private IItem currItem;

        private BlockCycler blockCycler;
        private IBlock currentBlock;


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

            EnemyFactory.Instance.LoadAllContent(Content);
            ItemFactory.Instance.LoadItemContent(Content);

            mario = new Player(new Vector2(400, 400));
            Texture2D texture = Content.Load<Texture2D>("marioSpriteSheet");

            //TODO: Remove all cyclers after sprint 2
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


            BlockFactory.Instance.LoadAllContent(Content);
            blocks = new List<IBlock> {
                
                new Block(BlockFactory.Instance.GetBlock("Chiseled")),
                new Block(BlockFactory.Instance.GetBlock("BrownBrick")),
                new Block(BlockFactory.Instance.GetBlock("BlueBrick")),
                new Block(BlockFactory.Instance.GetBlock("Hit")),
                new Block(BlockFactory.Instance.GetBlock("BrownGround")),
                new Block(BlockFactory.Instance.GetBlock("BlueGround")),
                new Block(BlockFactory.Instance.GetBlock("Question")),
                new Block(BlockFactory.Instance.GetBlock("SmallPipe")),
                new Block(BlockFactory.Instance.GetBlock("MediumPipe")),
                new Block(BlockFactory.Instance.GetBlock("LargePipe"))
            };


            blockCycler = new BlockCycler(blocks);
            currentBlock = blocks[0];
            
            //Will eventually be moved somewhere else
            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingDownCommand(mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingRightCommand(mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingLeftCommand(mario));



            keyControl.RegisterOnPressCommand(Keys.Z, new MarioAttackNormalCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.D3, new MarioPowerUpCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.E, new MarioHurtCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.T, new CycleBlockLeftCommand(this));
            keyControl.RegisterOnPressCommand(Keys.Y, new CycleBlockRightCommand(this));
            keyControl.RegisterOnPressCommand(Keys.U, new CycleItemLeftCommand(this));
            keyControl.RegisterOnPressCommand(Keys.I, new CycleItemRightCommand(this));
            keyControl.RegisterOnPressCommand(Keys.O, new CycleEnemyLeftCommand(this));
            keyControl.RegisterOnPressCommand(Keys.P, new CycleEnemyRightCommand(this));
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

            currentEnemy.Update(gameTime);
            currItem.Update(gameTime);
            currentBlock.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            mario.Draw(spriteBatch);
            HitBoxRectangle.DrawRectangle(spriteBatch, mario.GetHitBox(), Color.Black, 1);
            currentEnemy.Draw(spriteBatch, currentEnemy.Position, Color.White);
            currItem.Draw(spriteBatch);

            currentBlock.Draw(spriteBatch, new Vector2(600, 300), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Reload()
        {
            this.UnloadContent();
            this.LoadContent();
        }

        /* TODO: Below functions to be removed after sprint 2*/
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

        public void CycleBlockLeft()
        {
            currentBlock = blockCycler.CycleBlockLeft();
        }

        public void CycleBlockRight()
        {
            currentBlock = blockCycler.CycleBlockRight();
        }
    }
}
