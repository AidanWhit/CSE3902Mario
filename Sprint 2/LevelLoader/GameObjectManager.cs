using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Factories;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

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
            Player = player;
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

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D allSpriteSheet, Color color)
        {
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
                HitBoxRectangle.DrawRectangle(spriteBatch, item.GetHitBox(), color, 1);
            }

            foreach (IBlock block in Blocks)
            {
                block.Draw(spriteBatch, color);
                HitBoxRectangle.DrawRectangle(spriteBatch, block.GetHitBox(), Color.Red, 1);
            }
        }
    }
}