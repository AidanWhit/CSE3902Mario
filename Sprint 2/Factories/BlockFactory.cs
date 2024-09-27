using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
