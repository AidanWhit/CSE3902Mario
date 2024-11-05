﻿using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using Sprint_2.LevelManager;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using Sprint_2.GameStates;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    /* Create very similar command for exiting the underground, some little things will be different
     but the overall structure will be the exact same*/
    public class EnterPipeFromTop : ICommands
    {
        private IPlayer player;
        private ICollideable collideable;
        private Rectangle collisionRectangle;

        private Timer moveDownTimer;

        public EnterPipeFromTop(IPlayer player, ICollideable collideable, Rectangle collisionRectangle)
        {
            this.player = player;
            this.collideable = collideable;
            this.collisionRectangle = collisionRectangle;
        }

        public void Execute()
        {
            if (player.isCrouching)
            {
                GameObjectManager.Instance.Updateables.Remove(player);
                GameObjectManager.Instance.Movers.Remove(player);
                player.MoveRight();

                SoundManager.Instance.PlaySoundEffect("pipe");

                moveDownTimer = new Timer(MarioPhysicsConstants.timeBetweenMovementForAnimations);
                moveDownTimer.Enabled = true;
                moveDownTimer.Elapsed += (source, e) => MoveDown(source, e, player, collideable, moveDownTimer);
                moveDownTimer.AutoReset = true;
            }
            
        }

        private static void MoveDown(Object source, ElapsedEventArgs e, IPlayer player, ICollideable collediable, Timer timer)
        {
            if (player.YPos < collediable.GetHitBox().Bottom)
            {
                player.Crouch();
                player.YPos++;
                
            }
            else
            {
                Debug.WriteLine("Entered Underground: " + System.DateTime.Now);
                player.PlayerVelocity = Vector2.Zero;
                LevelLoader leveLoader = new LevelLoader();
                GameObjectManager.Instance.Reset();
                leveLoader.LoadLevel(@"LevelManager\XMLFiles\UndergroundXML.xml");
                Game1.Instance.GetCamera().Reset();
                Game1.Instance.GetCamera().SetLevelBounds(new Vector2(240, 240));

                SoundManager.Instance.StopBackgroundMusic();
                SoundManager.Instance.PlayBackgroundMusic("underworld");

                /* TODO: Teleport mario to underground section*/
                timer.Dispose();
            }
        }
    }
}
