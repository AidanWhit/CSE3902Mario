using Microsoft.VisualBasic;
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
        private static GameObjectManager instance = new GameObjectManager();
        public static GameObjectManager Instance { get { return instance; } }

        public List<ICollideable>[] Blocks = new List<ICollideable>[210];
        public List<Interfaces.IUpdateable> Updateables { get; set; } = new List<Interfaces.IUpdateable>();
        public List<Interfaces.IDrawable> Drawables { get; set; } = new List<Interfaces.IDrawable>();
        public List<ICollideable> Movers { get; set; } = new List<ICollideable>();
        public List<ICollideable> Static { get; set; } = new List<ICollideable>();

        private Dictionary<string, (Type, Type)> collisionCommandMap = new Dictionary<string, (Type, Type)>();

        private CollisionDetection collisionDetection;


        public IPlayer Player { get; set; }

        private GameObjectManager()
        {
            Player = Game1.Instance.mario;
            collisionDetection = new CollisionDetection(this);
            
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i] = new List<ICollideable>();
            }

            
            IEnemy testGoomba2 = new Koopa(new Vector2(175, 200));
            Block testBlock1 = new Block("Chiseled", new Vector2(16 * 4, 432));

            Block testBlock2 = new Block("Chiseled", new Vector2(16 * 14, 432));
            Updateables.Add(testBlock2);
            Static.Add(testBlock2);
            Drawables.Add(testBlock2);

            Block testBlock3 = new Block("BrownBrickWithStar", new Vector2(16 *2, 432 - 16*4));

            Updateables.Add(testBlock1);
            Static.Add(testBlock1);
            Drawables.Add(testBlock1);
            
            Updateables.Add(testBlock3);
            Static.Add(testBlock3);
            Drawables.Add(testBlock3);

            //IEnemy testGoomba = new Goomba(new Vector2(200, 200));
            //Movers.Add(testGoomba);
            //Updateables.Add(testGoomba);
            //Drawables.Add(testGoomba);

            Movers.Add(testGoomba2);
            Updateables.Add(testGoomba2);
            Drawables.Add(testGoomba2);


        }
        /* Next two methods added for testing */

        public void AddCommandMapping(string entry, Type sourceCommand, Type receiverCommand)
        {
            collisionCommandMap.Add(entry, (sourceCommand, receiverCommand));
        }
        public Dictionary<string, (Type, Type)> GetCollisionDictionary()
        {
            return collisionCommandMap;
        }
        
        private void UnloadObjects()
        {

        }
        
        public List<ICollideable> GetNearbyBlocks2(int column)
        {
            List<ICollideable> nearbyBlocks;
            if (column < 0 || column >= Blocks.Length)
            {
                nearbyBlocks = new List<ICollideable>();
            }
            else if (column != 0 && column < Blocks.Length - 1)
            {
                nearbyBlocks = Blocks[column].Concat(Blocks[column - 1].Concat(Blocks[column + 1])).ToList();
            }
            else if (column == Blocks.Length - 1)
            {
                nearbyBlocks = Blocks[column].Concat(Blocks[column - 1]).ToList();
            }
            else
            {
                nearbyBlocks = Blocks[column].Concat(Blocks[column + 1]).ToList();
            }
            foreach(ICollideable block in nearbyBlocks)
            {
                Static.Add(block);
            }
            return nearbyBlocks;
        }

        public void RemoveBlocksFromStatic(List<ICollideable> list)
        {
            foreach(ICollideable block in list)
            {
                Static.Remove(block);
            }
        }
        public void Update(GameTime gameTime)
        {
            /* TODO: Find a better way to update the player if it picks up a star */
            Player = Game1.Instance.mario;
            Player.Update(gameTime);
            
            foreach (Interfaces.IUpdateable update in Updateables.ToList())
            {
                update.Update(gameTime);
            }

            collisionDetection.DetectCollision();
            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D allSpriteSheet, Color color)
        {
            foreach(Interfaces.IDrawable draw in Drawables.ToList())
            {
                draw.Draw(spriteBatch, color);
            }

            Player.Draw(spriteBatch, color);
        }
    }
}