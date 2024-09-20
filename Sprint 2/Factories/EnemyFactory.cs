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

        // Modified 9/19 added koopa's sprites
        private Texture2D koopaWalkingLeft1;
        private Texture2D koopaWalkingLeft2;
        private Texture2D koopaWalkingRight1;
        private Texture2D koopaWalkingRight2;
        private Texture2D koopaShell;



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

            // Modified 9/19 added koopa's sprites
            koopaWalkingLeft1 = content.Load<Texture2D>("koopa_walkingleft1");
            koopaWalkingLeft2 = content.Load<Texture2D>("koopa_walkingleft2");
            koopaWalkingRight1 = content.Load<Texture2D>("koopa_walkingright1");
            koopaWalkingRight2 = content.Load<Texture2D>("koopa_walkingright2");
            koopaShell = content.Load<Texture2D>("koopa_shell");
        }

        public IEnemy CreateGoomba(Vector2 position)
        {
            // Create a Goomba(instance) 
            return new Goomba(goombaWalking1, goombaWalking2, goombaDying, position);
        }

        public IEnemy CreateKoopa(Vector2 position)
        {
            // Create a koopa(instance) 
            return new Koopa(koopaWalkingLeft1, koopaWalkingLeft2, koopaWalkingRight1, koopaWalkingRight2, koopaShell, position);
        }

        public IEnemy CreateKoopaShell(Vector2 position)
        {
            // Create a shell
            return new Shell(koopaShell, position);
        }
    }
}
