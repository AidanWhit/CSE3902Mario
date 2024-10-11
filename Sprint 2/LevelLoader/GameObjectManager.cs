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

namespace SprintZero.LevelLoader
{
    public class GameObjectManager
    {
        // Add or remove collections of objects as needed
        private Collection<IEnemy> Enemies = new Collection<IEnemy>();
        private Collection<IItem> Items = new Collection<IItem>();
        private Collection<IBlock> Blocks = new Collection<IBlock>();
        //private Collection<IBlock> GroundBlocks = new Collection<IBlock>();
        private Collection<ISprite> Background = new Collection<ISprite>();
        private Collection<IGameObject> GameObjects = new Collection<IGameObject>();



        public IPlayer Player { get; set; }

        public GameObjectManager(IPlayer player)
        {
            Enemies.Add(new Shell(new Vector2(300, 350)));
            Player = Game1.Instance.mario;
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

        public void AddObject(IGameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void RemoveObject(IGameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }


        private void UnloadObjects()
        {

        }

        public void Update(GameTime gameTime)
        {
            /* TODO: Find a better way to update the player if it picks up a star */
            Player = Game1.Instance.mario;
            Player.Update(gameTime);
            foreach (IItem item in Items.ToList())
            {
                foreach (IBlock block in Blocks)
                {
                    if (item.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockCollisionResponseForItem(item, block);
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

            foreach (IEnemy enemy in Enemies.ToList())
            {
                foreach (IBlock block in Blocks)
                {
                    if (enemy.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockResponseForEnemy(enemy, block);
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
            Player.Draw(spriteBatch, color);
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
        }
    }
}