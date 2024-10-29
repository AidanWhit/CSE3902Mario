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
    /* TODO: Will need to change gameObject Manager to only store the lists and not do all of the abing/updating/collision checking
     * Also need to find a way to draw the items behind the blocks the spawn the items*/
    public class GameObjectManager
    {
        private static GameObjectManager instance = null;
        public static GameObjectManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObjectManager();
                }
                return instance;
            }
        }
                

        public List<ICollideable>[] Blocks = new List<ICollideable>[225];
        public List<Interfaces.IUpdateable> Updateables { get; set; } = new List<Interfaces.IUpdateable>();
        public List<Interfaces.IDrawable> ForeDrawables { get; set; } = new List<Interfaces.IDrawable>();
        public List<Interfaces.IDrawable> BackDrawables { get; set; } = new List<Interfaces.IDrawable>();

        public List<ICollideable> Movers { get; set; } = new List<ICollideable>();
        public List<ICollideable> Static { get; set; } = new List<ICollideable>();

        private Dictionary<string, (Type, Type)> collisionCommandMap = new Dictionary<string, (Type, Type)>();

        private GameObjectManager()
        {   
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i] = new List<ICollideable>();
            }
        }

        public void AddCommandMapping(string entry, Type sourceCommand, Type receiverCommand)
        {
            collisionCommandMap.Add(entry, (sourceCommand, receiverCommand));
        }
        public Dictionary<string, (Type, Type)> GetCollisionDictionary()
        {
            return collisionCommandMap;
        }
        
        public List<ICollideable> GetNearbyBlocks(int column)
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
        public void Reset()
        {
            collisionCommandMap.Clear();
            Static.Clear();
            Movers.Clear();
            Updateables.Clear();
            ForeDrawables.Clear();
            BackDrawables.Clear();
            foreach (List<ICollideable> list in Blocks)
            {
                list.Clear();
            }
        }

    }
}