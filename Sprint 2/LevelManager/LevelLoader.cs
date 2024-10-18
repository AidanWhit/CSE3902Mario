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
using System.Reflection.Emit;
using Sprint_2.Collision;
using Sprint_2.Constants;
using System.Reflection;
using System.Data.Common;

namespace Sprint_2.LevelManager
{
    public class LevelLoader
    {
        private XmlReader LevelReader;
        private BackgroundFactory backgroundFactory;

        public LevelLoader(string level, GameObjectManager gameObjectManager)
        {
            //TODO: Find a way to avoid having to do this
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            directory = directory + level;

            LevelReader = XmlReader.Create(directory);
        }


        public void LoadCommandDictionary(string collisionTableFile)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            int index = directory.IndexOf(@"\bin");
            directory = directory.Substring(0, index + 1);
            directory = directory + collisionTableFile;

            XmlReader collisionReader = XmlReader.Create(directory);
            collisionReader.MoveToContent();
            while (collisionReader.Read())
            {
                string sourceType;
                string receiverType;
                string collisionSide;
                string sourceCommand;
                string receiverCommand;
                if ((collisionReader.NodeType == XmlNodeType.Element) && (collisionReader.Name == "Entry"))
                {
                    collisionReader.ReadToDescendant("SourceType");
                    sourceType = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    receiverType = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    collisionSide = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    sourceCommand = collisionReader.ReadElementContentAsString();

                    collisionReader.Read();
                    receiverCommand = collisionReader.ReadElementContentAsString();

                    string key = sourceType + receiverType + collisionSide;
                    Type command1 = Type.GetType(sourceCommand);
                    Type command2 = Type.GetType(receiverCommand);

                    GameObjectManager.Instance.AddCommandMapping(key, command1, command2);
                }
            }
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
                case "Pipe":
                    MakePipe(name, locationX, locationY);
                    break;
                default:
                    throw new InvalidOperationException("Game Object type: \"" + type + "\" doesn't exist.");

            }
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

        private void MakeItem(string name, int locationX, int locationY, IBlock source)
        {
            //switch (name)
            //{
            //    case "Coin":
            //        gameObjectManager.AddItem(new Coin(new Vector2(locationX, locationY), gameObjectManager));
            //        break;
            //    case "Flower":
            //        gameObjectManager.AddItem(new Flower(new Vector2(locationX, locationY), source));
            //        break;
            //    case "RedMushroom":
            //        gameObjectManager.AddItem(new RedMushroom(new Vector2(locationX, locationY), source));
            //        break;
            //    case "GreenMushroom":
            //        gameObjectManager.AddItem(new GreenMushroom(new Vector2(locationX, locationY), source));
            //        break;
            //    case "Star":
            //        gameObjectManager.AddItem(new Star(new Vector2(locationX, locationY), source));
            //        break;
            //    default:
            //        throw new InvalidOperationException("Item type: \"" + name + "\" doesn't exist");
            //}
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