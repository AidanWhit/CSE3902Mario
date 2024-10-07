using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using SprintZero.LevelLoader;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;


namespace Sprint_2.Factories
{
    public class BlockFactory
    {
        private static BlockFactory instance = new BlockFactory();
        public static BlockFactory Instance { get { return instance; } }

        private GameObjectManager gameObjectManager;


        private Texture2D blockSpriteSheet;

        //TODO : To be moved out of here for a later sprint
        private Dictionary<string, Rectangle[]> blockDictionary = new Dictionary<string, Rectangle[]> {
            {"SmallPipe", new Rectangle[]{new Rectangle(69, 1, 32, 32)} },
            {"MediumPipe", new Rectangle[]{new Rectangle(35, 1, 32, 47)} },
            {"LargePipe", new Rectangle[]{new Rectangle(1, 1, 32, 62)} },
            {"BlueBrick", new Rectangle[]{new Rectangle(69, 35, 16, 16)} },
            {"BlueGround", new Rectangle[]{new Rectangle(1, 65, 16, 16) } },
            {"BrownBrick", new Rectangle[]{new Rectangle(19, 65, 16, 16)} },
            {"Chiseled", new Rectangle[]{new Rectangle(37, 65, 16, 16)} },
            {"BrownGround", new Rectangle[]{new Rectangle(55, 65, 16, 16) } },
            {"Hit", new Rectangle[]{new Rectangle(73, 65,16, 16) } },
            {"Question", new Rectangle[]{new Rectangle(1, 83, 16, 16), new Rectangle(19, 83, 16, 16), new Rectangle(37, 83, 16, 16)} }

        };

        private BlockFactory()
        {
            
        }

        public void LoadAllContent(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("blocks");
        }

        public ISprite GetBlock(string id)
        {
            blockDictionary.TryGetValue(id, out Rectangle[] frames);
            Vector2 size = new Vector2(frames[0].Size.X, frames[0].Size.Y);
            return new FrameArrayFormattedSprite(blockSpriteSheet, frames, 3);
        }


        public void SetGameObjectManager(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
        }
        public void AddBlockToBlocksList(IBlock block)
        {
            gameObjectManager.AddBlock(block);
        }

        public void RemoveBlockFromList(IBlock block)
        {
            gameObjectManager.RemoveBlock(block);
        }

    }
}
