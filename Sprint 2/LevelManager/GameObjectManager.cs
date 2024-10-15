using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2;
using Sprint_2.Collision;
using Sprint_2.Factories;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Sprint_2.LevelManager
{
    public class GameObjectManager
    {
        // Add or remove collections of objects as needed
        private Collection<IEnemy> Enemies = new Collection<IEnemy>();
        private Collection<IItem> Items = new Collection<IItem>();
        private Collection<IBlock> Blocks = new Collection<IBlock>();
        //private Collection<IBlock> GroundBlocks = new Collection<IBlock>();
        private Collection<IStaticSprite> Background = new Collection<IStaticSprite>();
        private Collection<IGameObject> GameObjects = new Collection<IGameObject>();
        private Collection<IPipe> Pipes = new Collection<IPipe>();

        public List<IBlock>[] blocks = new List<IBlock>[210];

        private int iteration = 0;
        private int marioColumn;


        public IPlayer Player { get; set; }

        public GameObjectManager(IPlayer player)
        {
            Player = Game1.Instance.mario;
            
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new List<IBlock>();
            }

        }

        public Collection<IGameObject> GetObjects()
        {
            return GameObjects;
        }

        /* Next two methods added for testing */
        public void AddItem(IItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            Items.Remove(item);
        }

        public void AddBlock(IBlock block)
        {
            Blocks.Add(block);
        }

        public void RemoveBlock(IBlock block)
        {
            Blocks.Remove(block);
        }

        public void AddEnemy(IEnemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            Enemies.Remove(enemy);
        }

        public void AddBackground(IStaticSprite background)
        {
            Background.Add(background);
        }

        public void RemoveBackground(IStaticSprite background)
        {
            Background.Remove(background);
        }

        public void AddObject(IGameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void RemoveObject(IGameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public void AddPipe(IPipe pipe)
        {
            Pipes.Add(pipe);
        }
        public void RemovePipe(IPipe pipe)
        {
            Pipes.Remove(pipe);
        }
        private void UnloadObjects()
        {

        }

        public void Update(GameTime gameTime)
        {
            /* TODO: Find a better way to update the player if it picks up a star */
            Player = Game1.Instance.mario;
            marioColumn = Player.XPos / 16;
            List<IBlock> collideableBlocks = new List<IBlock>();
            if (marioColumn != 0)
            {
                foreach (IBlock block in blocks[marioColumn - 1])
                {
                    if (Player.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockReponseForPlayer(Player, block);
                    }
                }
            }
            
            foreach (IBlock block in blocks[marioColumn])
            {
                if (Player.GetHitBox().Intersects(block.GetHitBox()))
                {
                    BlockCollisionResponse.BlockReponseForPlayer(Player, block);
                }
            }

            foreach (IBlock block in blocks[marioColumn + 1])
            {
                if (Player.GetHitBox().Intersects(block.GetHitBox()))
                {
                    BlockCollisionResponse.BlockReponseForPlayer(Player, block);
                }
            }

            foreach (IProjectile fireball in Player.fireballs)
            {
                foreach(IBlock block in Blocks)
                {
                    if (fireball.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockResponseForFireball(fireball, block);
                    }
                }
                foreach (IPipe pipe in Pipes)
                {
                    if (fireball.GetHitBox().Intersects(pipe.GetHitBox()))
                    {
                        PipeCollisionResponse.PipeResponseForFireBall(pipe, fireball);
                    }
                }
                foreach (IEnemy enemy in Enemies)
                {
                    if (fireball.GetHitBox().Intersects(enemy.GetHitBox()))
                    {
                        FireballCollisionResponder.FireballResponderForEnemies(fireball, enemy);
                    }
                }
            }

            Player.Update(gameTime);

            foreach (IPipe pipe in Pipes)
            {
                if (Player.GetHitBox().Intersects(pipe.GetHitBox()))
                {
                    PipeCollisionResponse.PipeResponseForPlayer(Player, pipe);
                }
                pipe.Update(gameTime);
            }
            

            foreach (IItem item in Items.ToList())
            {
                foreach (IBlock block in Blocks)
                {
                    if (item.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockCollisionResponseForItem(item, block);
                    }
                }
                foreach (IPipe pipe in Pipes)
                {
                    if (item.GetHitBox().Intersects(pipe.GetHitBox()))
                    {
                        PipeCollisionResponse.PipeResponseForItem(item, pipe);
                    }
                }
                if (item.GetHitBox().Intersects(Player.GetHitBox()))
                {
                    ItemCollisionResponse.ItemResponseForPlayer(item, Player);
                }
                item.Update(gameTime);

            }


            foreach (IBlock block in Blocks)
            {
                block.Update(gameTime);
            }

            foreach (ISprite background in Background)
            {
                background.Update(gameTime);
            }

            foreach (IEnemy enemy in Enemies.ToList())
            {
                foreach (IBlock block in Blocks)
                {
                    if (enemy.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockResponseForEnemy(enemy, block);
                    }
                }
                foreach (IPipe pipe in Pipes)
                {
                    if (enemy.GetHitBox().Intersects(pipe.GetHitBox()))
                    {
                        PipeCollisionResponse.PipeResponseForEnemy(enemy, pipe);
                    }
                    
                }
                foreach(IEnemy enemy2 in Enemies.ToList())
                {
                    if (!enemy.Equals(enemy2) && enemy.GetHitBox().Intersects(enemy2.GetHitBox()))
                    {
                        EnemyCollisionResponder.EnemyResponseForEnemy(enemy, enemy2);
                    }
                }
                if (enemy.GetHitBox().Intersects(Player.GetHitBox()))
                {
                    if(enemy is Shell)
                    {
                        EnemyCollisionResponder.ShellResponseForPlayer(enemy, Player);
                    }
                    else
                    {
                        EnemyCollisionResponder.EnemyResponseForPlayer(enemy, Player);
                    }
                }
                enemy.Update(gameTime);
            }

            

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D allSpriteSheet, Color color)
        {
            foreach (IStaticSprite background in Background)
            {
                background.Draw(spriteBatch, Vector2.Zero, color);
                //background.Draw(spriteBatch, color);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }

            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch, color);
            }

            

            

            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch, color);
            }


            foreach(IPipe pipe in Pipes)
            {
                pipe.Draw(spriteBatch, color);
            }

            Player.Draw(spriteBatch, color);
        }
    }
}