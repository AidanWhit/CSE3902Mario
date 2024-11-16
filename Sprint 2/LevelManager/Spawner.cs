using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.LevelManager;
using Sprint_2.ScreenCamera;
using Sprint_2.GameStates;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Diagnostics;

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
            spawnLocation = Vector2.Zero; // Default location, will be set to a proper one after read the xml
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

        // Default spawn location, may vary based on the level
        public void Spawn(IPlayer player)
        {
            player.XPos = (int)spawnLocation.X;
            player.YPos = (int)spawnLocation.Y;
        }

        public void TeleportToLevel(string newWorld, Vector2 spawnLocation, string bgm)
        {
            /* I think this game state change fixes that weird crashing bug. It just prevents objects from being updated/drawn
             when the lists are being modified. ~Aidan */
            Game1.Instance.gameState = new TransitionGameState();
            GameWorldManager.CurrentGameWorld = newWorld;

            LevelLoader levelLoader = new LevelLoader();
            GameObjectManager.Instance.Reset();
            levelLoader.LoadLevel($"LevelManager\\{newWorld}.xml");

            //Game1.Instance.GetCamera().Reset();
            //Game1.Instance.GetCamera().SetLevelBounds(new Vector2(0, MiscConstants.levelBounds.Y));

            //SetSpawnLocation(spawnLocation);
            //Spawn(Game1.Instance.mario);
            //Teleport(Game1.Instance.mario, spawnLocation);

            SoundManager.Instance.StopBackgroundMusic();
            SoundManager.Instance.PlayBackgroundMusic(bgm);

            Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
        }


        // Teleport Mario via specific (x,y) location
        public void Teleport(IPlayer player, Vector2 newPosition)
        {
            player.XPos = (int)newPosition.X;
            player.YPos = (int)newPosition.Y;
        }

        //// Halt or Hold, just a timer to handle respawn and level transition
        //// Does not freeze the game
        //// Unit in f, for example hold 5 seconds -- .Hold(5.0f)
        //public void Hold(float seconds)
        //{
        //    isHolding = true;
        //    holdTime = seconds;
        //    elapsedTime = 0;
        //}

        //public bool IsHolding()
        //{
        //    return isHolding;
        //}

        //public void Update(GameTime gameTime)
        //{
        //    // Timer
        //    if (isHolding)
        //    {
        //        elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //        if (elapsedTime >= holdTime)
        //        {
        //            isHolding = false;
        //        }
        //    }
        //}



    }
}
