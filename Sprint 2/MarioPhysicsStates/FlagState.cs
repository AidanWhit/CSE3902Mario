using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioStates;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;

namespace Sprint_2.MarioPhysicsStates
{
    public class FlagState : IMarioPhysicsStates
    {
        private IPlayer player;
        private int bottomOfFlagPole;
        private int widthOfFlagPole;
        
        private Timer moveRightTimer;
        public FlagState(int bottomOfFlagPole, int widthOfFlagPole)
        {
            player = Game1.Instance.mario;
            this.bottomOfFlagPole = bottomOfFlagPole;
            this.widthOfFlagPole = widthOfFlagPole;

            PlayerStateMachine.Facing facing = player.GetFacing();
            if (facing == PlayerStateMachine.Facing.Left)
            {
                player.MoveRight();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (player.GetHitBox().Bottom != bottomOfFlagPole)
            {
                player.YPos++;
            }
            else
            {
                player.XPos += widthOfFlagPole;
                player.MoveLeft();
                player.PlayerVelocity = MarioPhysicsConstants.velocityJumpingOffFlagPole;
                player.Jump();
                player.PhysicsState = new Grounded(player);

                /* Might be a better way to do this but it works */
                Timer timer = new Timer(MarioPhysicsConstants.timeToReachCastle);
                moveRightTimer = new Timer(MarioPhysicsConstants.timeBetweenMovementForAnimations);
                moveRightTimer.Elapsed += (source, e) => MoveRight(source, e, player);
                moveRightTimer.Enabled = true;
                moveRightTimer.AutoReset = true;
                timer.Elapsed += (source, e) => OnTimedEvent(source, e, player, moveRightTimer);
                timer.Enabled = true;
            }
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e, IPlayer player, Timer moveRightTimer)
        {
            GameObjectManager.Instance.Drawables.Remove(player);
            moveRightTimer.Dispose();
        }

        private static void MoveRight(Object source, ElapsedEventArgs e, IPlayer player)
        {
            player.MoveRight();
        }
    }
}
