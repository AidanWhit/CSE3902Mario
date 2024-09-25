using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
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

        private BlockFactory()
        {
        }

        public void LoadAllContent(ContentManager content)
        {
            questionBlock = content.Load<Texture2D>("questionBlock");
            brickBlock = content.Load<Texture2D>("brickBlock");
            hitBlock = content.Load<Texture2D>("hitBlock");
            groundBlock = content.Load<Texture2D>("groundBlock");
        }

        public IBlock createQuestionBlock(Vector2 position)
        {
            return new QuestionBlock(questionBlock, position);
        }
        public IBlock createBrickBlock(Vector2 position)
        {
            return new BrickBlock(brickBlock, position);
        }
        public IBlock createHitBlock(Vector2 position)
        {
            return new HitBlock(hitBlock, position);
        }
        public IBlock createGroundBlock(Vector2 position)
        {
            return new GroundBlock(groundBlock, position);
        }
    }
}
