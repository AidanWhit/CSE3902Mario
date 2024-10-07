using Sprint_2.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sprint_2.Sprites.EnemySprites;
using SprintZero.LevelLoader;

namespace Sprint_2.Interfaces
{
    public interface IItem
    {
        public bool OnSpawn { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }

        public Vector2 Velocity { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void DeleteItem(GameObjectManager gameObjectManager);

        public Rectangle GetHitBox();

        public void ChangeDirection();
    }

}
