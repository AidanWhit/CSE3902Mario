using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.LevelManager;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;


namespace Sprint_2.Factories
{
    public class BlockFactory
    {
        private static BlockFactory instance = new BlockFactory();
        public static BlockFactory Instance { get { return instance; } }


        private Texture2D blockSpriteSheet;

        //TODO : To be moved out of here for a later sprint
        private Dictionary<string, Rectangle[]> blockDictionary = new Dictionary<string, Rectangle[]> {
            {"SmallPipe", new Rectangle[]{new Rectangle(69, 1, 32, 32)} },
            {"MediumPipe", new Rectangle[]{new Rectangle(35, 1, 32, 48)} },
            {"LargePipe", new Rectangle[]{new Rectangle(1, 1, 32, 64)} },
            {"BlueBrick", new Rectangle[]{new Rectangle(69, 35, 16, 16)} },
            {"BlueGround", new Rectangle[]{new Rectangle(1, 67, 16, 16) } },
            {"BrownBrick", new Rectangle[]{new Rectangle(19, 67, 16, 16)} },
            {"Chiseled", new Rectangle[]{new Rectangle(37, 67, 16, 16)} },
            {"BrownGround", new Rectangle[]{new Rectangle(55, 67, 16, 16) } },
            {"Hit", new Rectangle[]{new Rectangle(73, 67,16, 16) } },
            {"Question", new Rectangle[]{new Rectangle(1, 85, 16, 16), new Rectangle(19, 85, 16, 16), new Rectangle(37, 85, 16, 16)} },
            {"Invisible", new Rectangle[]{new Rectangle(71, 85, 16, 16)} }

        };

        private BlockFactory()
        {
            
        }

        public void LoadAllContent(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("blocks");
        }
        
        public ISprite GetBrokenPieceSprite()
        {
            Rectangle[] source = new Rectangle[] {new Rectangle(55, 85, 8, 8), new Rectangle(63, 85, 8, 8),
            new Rectangle(55, 93, 16, 16), new Rectangle(63, 93, 16, 16)};
            return new FrameArrayFormattedSprite(blockSpriteSheet, source, 1);
        }
        public ISprite GetBlock(string id)
        {
            blockDictionary.TryGetValue(id, out Rectangle[] frames);
            return new FrameArrayFormattedSprite(blockSpriteSheet, frames, 1);
        }

    }
}
