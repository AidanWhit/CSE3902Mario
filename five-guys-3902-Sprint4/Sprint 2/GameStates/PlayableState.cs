using Microsoft.Xna.Framework;
using Sprint_2.Collision;
using Sprint_2.Controls;
using Sprint_2.LevelManager;
using Sprint_2.ScreenCamera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameStates
{
    public class PlayableState : Interfaces.IUpdateable
    {
        private KeyboardControl keyboardControl;
        private CollisionDetection collisionDetection;
        private Camera camera;

        public PlayableState(KeyboardControl keyboardControl)
        {
            this.keyboardControl = keyboardControl;
            InitControls.initializeControls(keyboardControl, Game1.Instance.mario);
            collisionDetection = Game1.Instance.CollisionDetection;
            camera = Game1.Instance.GetCamera();
        }
        public void Update(GameTime gameTime)
        {
            keyboardControl.Update();
            camera.Update(gameTime);

            foreach (Interfaces.IUpdateable obj in GameObjectManager.Instance.Updateables.ToList())
            {
                obj.Update(gameTime);
            }
            collisionDetection.DetectCollision();
        }
    }
}
