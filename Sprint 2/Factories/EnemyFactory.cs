using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Sprint_0.Sprites;
using Sprint_0.Sprites.EnemySprites;
using Sprint_0.Interfaces;

namespace Sprint_0.Factories
{
    public class EnemyFactory
    {
        private static EnemyFactory instance = new EnemyFactory();

        private Texture2D goombaWalking1;
        private Texture2D goombaWalking2;
        private Texture2D goombaDying;

        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyFactory()
        {
        }

        public void LoadAllContent(ContentManager content)
        {
            goombaWalking1 = content.Load<Texture2D>("goomba_walking1");
            goombaWalking2 = content.Load<Texture2D>("goomba_walking2");
            goombaDying = content.Load<Texture2D>("goomba_dying1");
        }

        public IEnemy CreateGoomba(Vector2 position)
        {
            // Create a Goomba(instance) 
            return new Goomba(goombaWalking1, goombaWalking2, goombaDying, position);
        }
    }
}
