﻿using Sprint_2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.MarioPhysicsStates;
using System.Diagnostics;
using Sprint_2.Constants;

namespace Sprint_2.Collision
{
    public class BlockCollisionResponse
    {

        public static void BlockReponseForPlayer(IPlayer player, IBlock block)
        {
            Rectangle collisionIntersection;
            /* TODO: Think of a better way to represent the side to reduce coupling */
            CollisionSideDetector.side side;

            Rectangle playerHitBox = player.GetHitBox();
            Rectangle blockHitBox = block.GetHitBox();
            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(playerHitBox, blockHitBox);

            if (side == CollisionSideDetector.side.Right)
            {
                player.XPos -= collisionIntersection.Width;

            }
            else if (side == CollisionSideDetector.side.Left)
            {
                player.XPos += collisionIntersection.Width;
            }
            else if (side == CollisionSideDetector.side.Top)
            {
                if (!player.isJumping)
                {
                    player.YPos -= collisionIntersection.Height;
                    player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, MarioPhysicsConstants.gravity);
                }
                if (player.isFalling)
                {
                    player.YPos -= collisionIntersection.Height;
                    player.Idle();
                    player.PhysicsState = new Grounded(player);
                }
                

            }
            else
            {
                player.YPos += collisionIntersection.Height;
                player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, 0);
                player.Fall();
                player.PhysicsState = new Falling(player);

                block.BeHit(player);
            }

        }
    

        public void BlockResponseForEnemy()
        {

        }
    }
}
