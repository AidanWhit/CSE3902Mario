using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sound;
using System;
using System.Diagnostics;
using System.Timers;


namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class EnterPipeFromRight : ICommands
    {
        private IPlayer player;
        private ICollideable collideable;
        private Rectangle collisionRect;
        private int rightSide;
        private Timer enterPipeTimer;
        public EnterPipeFromRight(IPlayer player, ICollideable collideable, Rectangle collisionRect)
        {
            this.player = player;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
            rightSide = collisionRect.Right;
        }

        public void Execute()
        {
            Debug.WriteLine("EnteredPipe");
            GameObjectManager.Instance.Updateables.Remove(player);
            GameObjectManager.Instance.Movers.Remove(player);
            SoundManager.Instance.PlaySoundEffect("pipe");

            enterPipeTimer = new Timer(MarioPhysicsConstants.timeBetweenMovementForAnimations);
            enterPipeTimer.Enabled = true;
            enterPipeTimer.AutoReset = true;
            enterPipeTimer.Elapsed += (s, e) => EnterPipe(s, e, collideable, enterPipeTimer);
        }

        private void EnterPipe(Object source, ElapsedEventArgs e, ICollideable collideable, Timer timer)
        {

            if (player.XPos < rightSide)
            {
                player.XPos++;
            }
            else /* Finished moving into the pipe */
            {
                /* Load 1-1 and tp mario to the exit */
                player.PlayerVelocity = Vector2.Zero;
                LevelLoader levelLoader = new LevelLoader();
                GameObjectManager.Instance.Reset();

                levelLoader.LoadLevel(@"LevelManager\level-1_data_pretty.xml");
                Game1.Instance.camera.Reset();
                Game1.Instance.GetCamera().SetLevelBounds(new Vector2(3744, 240));

                player.XPos = 2624;
                player.YPos = 400;
                

                timer.Dispose();
            }
        }
    }
}
