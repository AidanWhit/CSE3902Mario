using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;

namespace Sprint_2.LevelManager
{
    public class Spawner
    {
        private static Spawner instance;
        private Vector2 spawnLocation;
        private float holdTime;
        private float elapsedTime;
        private bool isHolding;

        public static Spawner Instance => instance ??= new Spawner();

        private Spawner()
        {
            spawnLocation = Vector2.Zero; // Default location
            holdTime = 0;
            elapsedTime = 0;
            isHolding = false;
        }

        public void SetSpawnLocation(Vector2 location)
        {
            spawnLocation = location;
        }

        public Vector2 GetSpawnLocation()
        {
            return spawnLocation;
        }

        public void Hold(float seconds)
        {
            isHolding = true;
            holdTime = seconds;
            elapsedTime = 0;
        }

        public bool IsHolding()
        {
            return isHolding;
        }

        public void Update(GameTime gameTime)
        {
            if (isHolding)
            {
                elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (elapsedTime >= holdTime)
                {
                    isHolding = false;
                }
            }
        }

        public void Spawn(IPlayer player)
        {
            player.XPos = (int)spawnLocation.X;
            player.YPos = (int)spawnLocation.Y;
        }
    }
}
