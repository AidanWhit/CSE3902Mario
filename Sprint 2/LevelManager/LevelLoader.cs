﻿using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Xml;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Sprites.EnemySprites;
using Sprint_2.Factories;
using System.Diagnostics;
using System.Reflection.Emit;
using Sprint_2.Collision;
using Sprint_2.Constants;
using System.Reflection;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Sprint_2.GameObjects.Misc;

namespace Sprint_2.LevelManager
{
    public class LevelLoader
    {
        private XmlReader LevelReader;
        private BackgroundFactory backgroundFactory;

        public LevelLoader()
        {
            

            
        }
        public void LoadLevel(string level)
        {
            //TODO: Find a way to avoid having to do this
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            directory = directory + level;

            LevelReader = XmlReader.Create(directory);
            
            LevelReader.MoveToContent();
            while (LevelReader.Read())
            {
                string type;
                string name;
                string location;
                string sizeX = "";  string sizeY = "";
                if ((LevelReader.NodeType == XmlNodeType.Element) && (LevelReader.Name == "Item"))
                {
                    LevelReader.ReadToDescendant("ObjectType");
                    type = LevelReader.ReadElementContentAsString();
                    LevelReader.ReadToNextSibling("ObjectName");
                    name = LevelReader.ReadElementContentAsString();
                    LevelReader.ReadToNextSibling("Location");
                    location = LevelReader.ReadElementContentAsString();
                    if (type.Equals("Collider"))
                    {
                        LevelReader.ReadToNextSibling("SizeX");
                        sizeX = LevelReader.ReadElementContentAsString();
                        LevelReader.Read();
                        sizeY = LevelReader.ReadElementContentAsString();
                    }
                    LoadObject(name, type, location, sizeX, sizeY);
                }
            }
        }
        private void LoadObject(string name, string type, string location, string sizeX, string sizeY)
        {
            location.Trim();
            string[] tokens = location.Split(new char[] { ' ' });
            int locationX = Convert.ToInt32(tokens[0]);
            int locationY = Convert.ToInt32(tokens[1]);

            switch (type)
            {
                case "Player":
                    MakePlayer(name, locationX, locationY);
                    break;
                case "Enemy":
                    MakeEnemy(name, locationX, locationY);
                    break;
                case "Background":
                    MakeBackground(name, locationX, locationY);
                    break;
                case "Block":
                    MakeBlocks(name, locationX, locationY);
                    break;
                case "Item":
                    //TODO: Fix
                    MakeItem(name, locationX, locationY);
                    break;
                case "Pipe":
                    MakePipe(name, locationX, locationY);
                    break;
                case "Collider":
                    
                    Vector2 size = new Vector2(Convert.ToInt32(sizeX), Convert.ToInt32(sizeY));
                    MakeCollider(name, locationX, locationY, size);
                    break;
                default:
                    throw new InvalidOperationException("Game Object type: \"" + type + "\" doesn't exist.");

            }
        }
        private void MakeCollider(string name, int locationX, int locationY, Vector2 size)
        {
            GameObjectManager.Instance.Static.Add(new Collider(new Vector2(locationX, locationY), size, name));
            GameObjectManager.Instance.Drawables.Add(new Collider(new Vector2(locationX, locationY), size, name));
        }
        private void MakePipe(string name, int locationX, int locationY)
        {
            Pipe pipe = new Pipe(new Vector2(locationX, locationY), name);
            GameObjectManager.Instance.Static.Add(pipe);
            GameObjectManager.Instance.Drawables.Add(pipe);
            GameObjectManager.Instance.Updateables.Add(pipe);

        }
        private void MakePlayer(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Mario":
                    //gameObjectManager.Player = new Player(new Vector2(locationX, locationY));
                    Game1.Instance.mario.XPos = locationX;
                    Game1.Instance.mario.YPos = locationY;
                    break;
                default:
                    throw new InvalidOperationException("Player type: \"" + name + "\" doesn't exist");
            }

        }

        private void MakeBackground(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Bush1":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateBush1(new Vector2(locationX, locationY)));
                    break;
                case "Bush2":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateBush2(new Vector2(locationX, locationY)));
                    break;
                case "Hill1":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateHill1(new Vector2(locationX, locationY)));
                    break;
                case "Hill2":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateHill2(new Vector2(locationX, locationY)));
                    break;
                case "Cloud1":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateCloud1(new Vector2(locationX, locationY)));
                    break;
                case "Cloud2":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateCloud2(new Vector2(locationX, locationY)));
                    break;
                case "LevelImage":
                    GameObjectManager.Instance.Drawables.Add(BackgroundFactory.Instance.CreateLevelImage(new Vector2(locationX, locationY)));
                    break;
                case "Flag":
                    GameObjectManager.Instance.Drawables.Add(new Flag(new Vector2(locationX, locationY)));
                    break;
                default:
                    throw new InvalidOperationException("Scenery type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeBlocks(string name, int locationX, int locationY)
        {
            int column = locationX / 16;
            IBlock block;
            switch (name) 
            {
                
                case "BrownGround":
                    block = new Block("BrownGround", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "BrownBrick":
                    block = new Block("BrownBrick", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "BlueBrick":
                    block = new Block("BlueBrick", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "BlueGround":
                    block = new Block("BlueGround", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "ItemWithCoin":
                    block = new Block("ItemWithCoin", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "ItemWithPowerUp":
                    block = new Block("ItemWithPowerUp", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "Chiseled":
                    block = new Block("Chiseled", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "BrownBrickWithStar":
                    block = new Block("BrownBrickWithStar", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "BrownBrickWithCoins":
                    block = new Block("BrownBrickWithCoins", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                case "Invisible":
                    block = new Block("Invisible", new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Updateables.Add(block);
                    GameObjectManager.Instance.Blocks[column].Add(block);
                    GameObjectManager.Instance.Drawables.Add(block);
                    break;
                default:
                    throw new InvalidOperationException("Block type: \"" + name + "\" doesn't exist");
            }
            
        }

        private void MakeItem(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Coin":
                    Coin coin = new Coin(new Vector2(locationX, locationY), false);
                    GameObjectManager.Instance.Updateables.Add(coin);
                    GameObjectManager.Instance.Drawables.Add(coin);
                    break;
                case "Flower":
                    Flower flower = new Flower(new Vector2(locationX, locationY), 480);
                    GameObjectManager.Instance.Updateables.Add(flower);
                    GameObjectManager.Instance.Drawables.Add(flower);
                    GameObjectManager.Instance.Static.Add(flower);
                    break;
                case "RedMushroom":
                    RedMushroom mushroom = new RedMushroom(new Vector2(locationX, locationY), 480);
                    GameObjectManager.Instance.Updateables.Add(mushroom);
                    GameObjectManager.Instance.Drawables.Add(mushroom);
                    GameObjectManager.Instance.Movers.Add(mushroom);
                    break;
                case "GreenMushroom":
                    GreenMushroom greenMushroom = new GreenMushroom(new Vector2(locationX, locationY), 480);
                    GameObjectManager.Instance.Updateables.Add(greenMushroom);
                    GameObjectManager.Instance.Drawables.Add(greenMushroom);
                    GameObjectManager.Instance.Movers.Add(greenMushroom);
                    break;
                case "Star":
                    Star star = new Star(new Vector2(locationX, locationY), 480);
                    GameObjectManager.Instance.Updateables.Add(star);
                    GameObjectManager.Instance.Drawables.Add(star);
                    GameObjectManager.Instance.Movers.Add(star);
                    break;
                default:
                    throw new InvalidOperationException("Item type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeEnemy(string name, int locationX, int locationY)
        {
            IEnemy enemy;
            switch (name)
            {
                
                case "Bowser":
                    //TODO: FIX BOWSER CONSTRUCTOR
                    //gameObjectManager.AddEnemy(new Bowser(new Vector2(locationX, locationY)));
                    break;
                case "Goomba":
                    enemy = new Goomba(new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Movers.Add(enemy);
                    GameObjectManager.Instance.Updateables.Add(enemy);
                    GameObjectManager.Instance.Drawables.Add(enemy);
                    break;
                case "Koopa":
                    enemy = new Koopa(new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Movers.Add(enemy);
                    GameObjectManager.Instance.Updateables.Add(enemy);
                    GameObjectManager.Instance.Drawables.Add(enemy);
                    break;
                case "Shell":
                    enemy = new Shell(new Vector2(locationX, locationY));
                    GameObjectManager.Instance.Movers.Add(enemy);
                    GameObjectManager.Instance.Updateables.Add(enemy);
                    GameObjectManager.Instance.Drawables.Add(enemy);
                    break;
                default:
                    throw new InvalidOperationException("Item type: \"" + name + "\" doesn't exist");
            }
        }
    }
}