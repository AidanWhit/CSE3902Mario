using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sprites;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Sprint_2.Collision
{
    public class EnemyCollisionResponder
    { 
        public static void EnemyResponseForPlayer(IEnemy enemy, IPlayer player)
        {
            Rectangle collisionIntersection;

            //side is in the view of the player. So top of the enemy will be bottom of the player
            CollisionSideDetector.side side;

            Rectangle enemyHitBox = enemy.GetHitBox();
            Rectangle playerHitBox = player.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(enemyHitBox, playerHitBox);
            if (!enemy.Flipped)
            {
                if (player is not StarMario)
                {
                    if (side == CollisionSideDetector.side.Bottom)
                    {
                        if (player.isFalling)
                        {
                            enemy.TakeStompDamage();
                            player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, MarioPhysicsConstants.bounceVelocity);
                            player.isJumping = true;
                        }

                    }
                    else
                    {
                        player.Damage();
                    }
                }
                else /* Player is Star Mario */
                {
                    /* Misleading name but makes the enemies flip */
                    enemy.TakeFireballDamage();
                }
            }
            
        }

        public static void ShellResponseForPlayer(IEnemy shell, IPlayer player)
        {
            Rectangle collisionIntersection;

            //side is in the view of the player. So top of the shell will be bottom of the player
            CollisionSideDetector.side side;

            Rectangle shellHitBox = shell.GetHitBox();
            Rectangle playerHitBox = player.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(shellHitBox, playerHitBox);
            
            if (player is StarMario && !shell.Flipped)
            {
                shell.TakeFireballDamage();
            }
            else if(!shell.Flipped)
            {
                if (shell.Velocity.X == 0)
                {
                    if (side == CollisionSideDetector.side.Left)
                    {
                        player.XPos -= collisionIntersection.Width;

                        shell.Velocity = new Vector2(EnemyConstants.shellMoveSpeed, shell.Velocity.Y);
                    }
                    else if (side == CollisionSideDetector.side.Right)
                    {
                        player.XPos += collisionIntersection.Width;

                        shell.Velocity = new Vector2(-EnemyConstants.shellMoveSpeed, shell.Velocity.Y);
                    }
                }
                else
                {
                    if (side == CollisionSideDetector.side.Bottom && player.isFalling)
                    {
                        shell.Velocity = Vector2.Zero;
                        player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, MarioPhysicsConstants.bounceVelocity);
                    }
                    else
                    {
                        player.Damage();
                    }
                }
            }
            
        }

        public static void EnemyResponseForEnemy(IEnemy source, IEnemy target)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            Rectangle sourceHitBox = source.GetHitBox();
            Rectangle targetHitBox = target.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(sourceHitBox, targetHitBox);

            if (!target.Flipped && !source.Flipped)
            {
                if ((source is Shell && source.Velocity.X != 0) || (target is Shell && target.Velocity.X != 0))
                {
                    if (source is Shell)
                    {
                        target.TakeFireballDamage();
                    }
                    else
                    { 
                        source.TakeFireballDamage();
                    }
                }
                else
                {
                    if (target is Shell)
                    {
                        if (side == CollisionSideDetector.side.Right)
                        {
                            source.XPos -= collisionIntersection.Width;

                            source.ChangeDirection();
                            target.ChangeDirection();
                        }
                        else if (side == CollisionSideDetector.side.Left)
                        {
                            source.XPos += collisionIntersection.Width;
                            source.ChangeDirection();
                            target.ChangeDirection();
                        }
                    } else if (source is Shell)
                    {
                        if (side == CollisionSideDetector.side.Right)
                        {
                            target.XPos += collisionIntersection.Width;

                            source.ChangeDirection();
                            target.ChangeDirection();
                        }
                        else if (side == CollisionSideDetector.side.Left)
                        {
                            target.XPos -= collisionIntersection.Width;
                            source.ChangeDirection();
                            target.ChangeDirection();
                        }
                        else
                        {
                            if (side == CollisionSideDetector.side.Right)
                            {
                                source.XPos -= collisionIntersection.Width;

                                source.ChangeDirection();
                                target.ChangeDirection();
                            }
                            else if (side == CollisionSideDetector.side.Left)
                            {
                                source.XPos += collisionIntersection.Width;
                                source.ChangeDirection();
                                target.ChangeDirection();
                            }
                        }
                    }
                    
                }
            }
            
        }
    }
}
