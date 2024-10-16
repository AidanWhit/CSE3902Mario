using Microsoft.Xna.Framework;
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

namespace Sprint_2.LevelManager
{
    public class LevelLoader
    {
        private XmlReader LevelReader;
        private GameObjectManager gameObjectManager;
        private BackgroundFactory backgroundFactory;

        public LevelLoader(string level, GameObjectManager gameObjectManager)
        {
            //TODO: Find a way to avoid having to do this
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            directory = directory + level;

            this.gameObjectManager = gameObjectManager;
            LevelReader = XmlReader.Create(directory);
        }



        public void LoadLevel()
        {
            LevelReader.MoveToContent();
            while (LevelReader.Read())
            {
                string type;
                string name;
                string location;
                if ((LevelReader.NodeType == XmlNodeType.Element) && (LevelReader.Name == "Item"))
                {
                    LevelReader.ReadToDescendant("ObjectType");
                    type = LevelReader.ReadElementContentAsString();
                    LevelReader.ReadToNextSibling("ObjectName");
                    name = LevelReader.ReadElementContentAsString();
                    LevelReader.ReadToNextSibling("Location");
                    location = LevelReader.ReadElementContentAsString();
                    LoadObject(name, type, location);
                }
            }
        }
        private void LoadObject(string name, string type, string location)
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
                    MakeItem(name, locationX, locationY, new Block("ItemWithCoin", new Vector2(locationX, locationY)));
                    break;
                default:
                    throw new InvalidOperationException("Game Object type: \"" + type + "\" doesn't exist.");

            }
        }

        private void MakePlayer(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Mario":
                    gameObjectManager.Player = new Player(new Vector2(locationX, locationY));
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
                    gameObjectManager.AddBackground(backgroundFactory.CreateBush1(new Vector2(locationX, locationY)));
                    break;
                case "Bush2":
                    gameObjectManager.AddBackground(backgroundFactory.CreateBush2(new Vector2(locationX, locationY)));
                    break;
                case "Hill1":
                    gameObjectManager.AddBackground(backgroundFactory.CreateHill1(new Vector2(locationX, locationY)));
                    break;
                case "Hill2":
                    gameObjectManager.AddBackground(backgroundFactory.CreateHill2(new Vector2(locationX, locationY)));
                    break;
                case "Cloud1":
                    gameObjectManager.AddBackground(backgroundFactory.CreateCloud1(new Vector2(locationX, locationY)));
                    break;
                case "Cloud2":
                    gameObjectManager.AddBackground(backgroundFactory.CreateCloud2(new Vector2(locationX, locationY)));
                    break;
                case "LevelImage":
                    gameObjectManager.AddBackground(backgroundFactory.CreateLevelImage(new Vector2(locationX, locationY)));
                    break;
                default:
                    throw new InvalidOperationException("Scenery type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeBlocks(string name, int locationX, int locationY)
        {
            int column = locationX / 16;
            switch (name)
            {
                case "BrownGround":
                    gameObjectManager.blocks[column].Add(new Block("BrownGround", new Vector2(locationX, locationY)));
                    break;
                case "BrownBrick":
                    gameObjectManager.blocks[column].Add(new Block("BrownBrick", new Vector2(locationX, locationY)));
                    break;
                case "BlueBrick":
                    gameObjectManager.blocks[column].Add(new Block("BlueBrick", new Vector2(locationX, locationY)));
                    break;
                case "BlueGround":
                    gameObjectManager.blocks[column].Add(new Block("BlueGround", new Vector2(locationX, locationY)));
                    break;
                case "ItemWithCoin":
                    gameObjectManager.blocks[column].Add(new Block("ItemWithCoin", new Vector2(locationX, locationY)));
                    break;
                case "ItemWithPowerUp":
                    gameObjectManager.blocks[column].Add(new Block("ItemWithPowerUp", new Vector2(locationX, locationY)));
                    break;
                case "Chiseled":
                    gameObjectManager.blocks[column].Add(new Block("Chiseled", new Vector2(locationX, locationY)));
                    break;
                case "BrownBrickWithStar":
                    gameObjectManager.blocks[column].Add(new Block("BrownBrickWithStar", new Vector2(locationX, locationY)));
                    break;
                case "BrownBrickWithCoins":
                    gameObjectManager.blocks[column].Add(new Block("BrownBrickWithCoins", new Vector2(locationX, locationY)));
                    break;
                case "Invisible":
                    gameObjectManager.blocks[column].Add(new Block("Invisible", new Vector2(locationX, locationY)));
                    break;
                default:
                    throw new InvalidOperationException("Block type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeItem(string name, int locationX, int locationY, IBlock source)
        {
            switch (name)
            {
                case "Coin":
                    gameObjectManager.AddItem(new Coin(new Vector2(locationX, locationY), gameObjectManager));
                    break;
                case "Flower":
                    gameObjectManager.AddItem(new Flower(new Vector2(locationX, locationY), source));
                    break;
                case "RedMushroom":
                    gameObjectManager.AddItem(new RedMushroom(new Vector2(locationX, locationY), source));
                    break;
                case "GreenMushroom":
                    gameObjectManager.AddItem(new GreenMushroom(new Vector2(locationX, locationY), source));
                    break;
                case "Star":
                    gameObjectManager.AddItem(new Star(new Vector2(locationX, locationY), source));
                    break;
                default:
                    throw new InvalidOperationException("Item type: \"" + name + "\" doesn't exist");
            }
        }

        private void MakeEnemy(string name, int locationX, int locationY)
        {
            switch (name)
            {
                case "Bowser":
                    //TODO: FIX BOWSER CONSTRUCTOR
                    //gameObjectManager.AddEnemy(new Bowser(new Vector2(locationX, locationY)));
                    break;
                case "Goomba":
                    gameObjectManager.AddEnemy(new Goomba(new Vector2(locationX, locationY)));
                    break;
                case "Koopa":
                    gameObjectManager.AddEnemy(new Koopa(new Vector2(locationX, locationY)));
                    break;
                case "Shell":
                    gameObjectManager.AddEnemy(new Shell(new Vector2(locationX, locationY)));
                    break;
                default:
                    throw new InvalidOperationException("Item type: \"" + name + "\" doesn't exist");
            }
        }
    }
}