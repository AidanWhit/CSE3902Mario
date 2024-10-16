using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2;
using Sprint_2.Collision;
using Sprint_2.Factories;
using Sprint_2.GameObjects;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Sprites.EnemySprites;
using System;
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
        public Collection<IEnemy> Enemies { get; set; } = new Collection<IEnemy>();
        public Collection<IItem> Items { get; set; } = new Collection<IItem>();
        public Collection<IBlock> Blocks { get; set; } = new Collection<IBlock>();
        public Collection<IStaticSprite> Background { get; set; } = new Collection<IStaticSprite>();
        public Collection<IPipe> Pipes { get; set; } = new Collection<IPipe>();

        public List<IBlock>[] blocks = new List<IBlock>[210];

        private Dictionary<Tuple<Type, Type, CollisionSideDetector.side>, (Type, Type)> collisionCommandMap = new Dictionary<Tuple<Type, Type, CollisionSideDetector.side>, (Type, Type)>();

        private CollisionDetection collisionDetection;
        private int marioColumn;


        public IPlayer Player { get; set; }

        public GameObjectManager(IPlayer player)
        {
            Player = Game1.Instance.mario;
            collisionDetection = new CollisionDetection(this);
            
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new List<IBlock>();
            }

        }
        /* Next two methods added for testing */

        public void AddCommandMapping(Tuple<Type, Type, CollisionSideDetector.side> entry, Type sourceCommand, Type receiverCommand)
        {
            collisionCommandMap.Add(entry, (sourceCommand, receiverCommand));
        }
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

        public void RemoveBlock(IBlock block, int column)
        {
            blocks[column].Remove(block);
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
        public List<IBlock> GetNearbyBlocks(int column)
        {
            List<IBlock> nearbyBlocks;
            if (column < 0 || column >= blocks.Length)
            {
                nearbyBlocks = new List<IBlock>();
            }
            else if (column != 0 && column < blocks.Length - 1)
            {
                nearbyBlocks = blocks[column].Concat(blocks[column - 1].Concat(blocks[column + 1])).ToList();
            }
            else if (column == blocks.Length - 1)
            {
                nearbyBlocks = blocks[column].Concat(blocks[column - 1]).ToList();
            }
            else
            {
                nearbyBlocks = blocks[column].Concat(blocks[column + 1]).ToList();
            }
            return nearbyBlocks;
        }
        public void Update(GameTime gameTime)
        {
            /* TODO: Find a better way to update the player if it picks up a star */
            Player = Game1.Instance.mario;
            Player.Update(gameTime);

            foreach (List<IBlock> list in blocks)
            {
                foreach (IBlock block in list)
                {
                    block.Update(gameTime);
                }
            }
            foreach (IItem item in Items.ToList())
            {
                item.Update(gameTime);
            }
            foreach (IPipe pipe in Pipes)
            {
                pipe.Update(gameTime);
            }
            foreach (ISprite background in Background)
            {
                background.Update(gameTime);
            }
            foreach (IEnemy enemy in Enemies.ToList())
            {
                enemy.Update(gameTime);
            }

            collisionDetection.DetectCollisions();
            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D allSpriteSheet, Color color)
        {
            foreach (IStaticSprite background in Background)
            {
                background.Draw(spriteBatch, Vector2.Zero, color);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }

            foreach (List<IBlock> list in blocks)
            {
                foreach (IBlock block in list)
                {
                    block.Draw(spriteBatch, color);
                }
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