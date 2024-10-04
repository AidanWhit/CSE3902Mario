using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SprintZero.LevelLoader
{
    public class GameObjectManager
    {
        private Collection<IEnemy> Enemies = new Collection<IEnemy>();
        private Collection<IItem> Items = new Collection<IItem>();
        private Collection<IBlock> Blocks = new Collection<IBlock>();
        private Collection<ISprite> BackGround = new Collection<ISprite>();
        private Collection<IGameObject> GameObjects = new Collection<IGameObject>();



        //public IPlayer Player { get; set; }



        public Collection<IGameObject> GetObjects()
        {
            return GameObjects;
        }

        public void AddObject(IGameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void RemoveObject(IGameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }


        private void UnloadObjects()
        {

        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D allSpriteSheet, Color color)
        {
        }
    }
}