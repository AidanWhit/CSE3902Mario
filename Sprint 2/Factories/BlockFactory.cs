using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System.Collections.Generic;
using System.Diagnostics;


namespace Sprint_2.Factories
{
    public class BlockFactory
    {
        private static BlockFactory instance = new BlockFactory();
        public static BlockFactory Instance { get { return instance; } }

        private Texture2D questionBlock;
        private Texture2D brickBlock;
        private Texture2D hitBlock;
        private Texture2D groundBlock;
        private Texture2D chiseledBlock;

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
            {"QuestionMark", new Rectangle[]{new Rectangle(1, 83, 16, 16), new Rectangle(19, 83, 16, 16), new Rectangle(37, 83, 16, 16)} }

        };

        private BlockFactory()
        {
            
        }

        public void LoadAllContent(ContentManager content)
        {
            questionBlock = content.Load<Texture2D>("questionBlock");
            brickBlock = content.Load<Texture2D>("brickBlock");
            hitBlock = content.Load<Texture2D>("hitBlock");
            groundBlock = content.Load<Texture2D>("groundBlock");
            chiseledBlock = content.Load<Texture2D>("Chiseled Block");

            blockSpriteSheet = content.Load<Texture2D>("blocks");
        }

        public ISprite GetBlock(string id)
        {
            blockDictionary.TryGetValue(id, out Rectangle[] frames);
            int X;
            return null;
        }
        public ISprite CreateQuestionBlock()
        {
            return new RowsColumnsFormattedSprite(questionBlock, 1, 3, 3);
        }
        public ISprite CreateBrickBlock()
        {
            return new RowsColumnsFormattedSprite(brickBlock, 1, 1, 3);
        }
        public ISprite CreateHitBlock()
        {
            return new RowsColumnsFormattedSprite(hitBlock, 1, 1, 3);
        }
        public ISprite CreateGroundBlock()
        {
            return new RowsColumnsFormattedSprite(groundBlock, 1, 1, 3);
        }

        public ISprite CreateChiseledBlock()
        {
            return new RowsColumnsFormattedSprite(chiseledBlock, 1, 1, 3);
        }
    }
}
