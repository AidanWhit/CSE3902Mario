using Sprint_2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.MarioPhysicsStates;
using System.Diagnostics;
using Sprint_2.Constants;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.GameObjects;
using Sprint_2.Factories;
using Sprint_2.GameObjects.BlockStates;

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
                if (block.GetBlockState() is not InvisibleState)
                {
                    player.XPos -= collisionIntersection.Width;
                }
                
            }
            else if (side == CollisionSideDetector.side.Left)
            {
                if (block.GetBlockState() is not InvisibleState)
                {
                    player.XPos += collisionIntersection.Width;
                }
            }
            else if (side == CollisionSideDetector.side.Top)
            {
                if (block.GetBlockState() is not InvisibleState)
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
                
                

            }
            else
            {
                if (!player.isFalling)
                {
                    player.YPos += collisionIntersection.Height;
                    player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, 0);
                    player.Fall();
                    player.PhysicsState = new Falling(player);

                    block.BeHit(player);
                }
                
            }

        }
    
        public static void BlockResponseForEnemy(IEnemy enemy, IBlock block)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            Rectangle enemyHitBox = enemy.GetHitBox();
            Rectangle blockHitBox = block.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(enemyHitBox, blockHitBox);
            if (!enemy.Flipped)
            {
                if (side == CollisionSideDetector.side.Right)
                {
                    enemy.XPos -= collisionIntersection.Width;
                    enemy.ChangeDirection();
                }
                else if (side == CollisionSideDetector.side.Left)
                {
                    enemy.XPos += collisionIntersection.Width;
                    enemy.ChangeDirection();
                }
                else if (side == CollisionSideDetector.side.Top)
                {
                    enemy.Velocity = new Vector2(enemy.Velocity.X, EnemyConstants.fallVelocity.Y);
                    //TODO: Fix this becuase it was a quick fix for jittery collision with the shell
                    enemy.YPos = blockHitBox.Top - enemyHitBox.Height;
                    //enemy.YPos -= collisionIntersection.Height;
                }
                else //Bottom side (Shouldnt happen)
                {
                    enemy.YPos += collisionIntersection.Height;
                }
            }
            
        }

        public static void BlockCollisionResponseForItem(IItem item, IBlock block)
        {
            Rectangle collisionIntersection;
            /* TODO: Think of a better way to represent the side to reduce coupling */
            CollisionSideDetector.side side;

            Rectangle itemHitBox = item.GetHitBox();
            Rectangle blockHitBox = block.GetHitBox();
            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(itemHitBox, blockHitBox);
            if (!item.OnSpawn)
            {
                if (side == CollisionSideDetector.side.Right)
                {
                    item.XPos -= collisionIntersection.Width;
                    item.ChangeDirection();
                }
                else if (side == CollisionSideDetector.side.Left)
                {
                    item.XPos += collisionIntersection.Width;
                    item.ChangeDirection();
                }
                else if (side == CollisionSideDetector.side.Top)
                {
                    item.YPos -= collisionIntersection.Height;
                    if (item is Star)
                    {
                        item.Velocity = new Vector2(item.Velocity.X, ItemPhysicsConstants.bounceVelocity);
                    }
                    else
                    {
                        item.Velocity = new Vector2(item.Velocity.X, 0);
                    }
                }
                /* Collisions from the bottom should never happen*/
                else
                {
                    item.YPos += collisionIntersection.Height;
                }
            }
        }

        public static void BlockResponseForFireball(IProjectile fireball, IBlock block)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            Rectangle fireballHitBox = fireball.GetHitBox();
            Rectangle blockHitBox = block.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(fireballHitBox, blockHitBox);

            if (block.GetBlockState() is not InvisibleState)
            {
                if (side == CollisionSideDetector.side.Top)
                {
                    fireball.YPos -= collisionIntersection.Height;
                    fireball.Speed = new Vector2(fireball.Speed.X, FireBallConstants.bounceSpeed);
                }
                else
                {
                    fireball.ChangeSprite(MarioSpriteFactory.Instance.FireballExplosion());
                    fireball.EnteredExplosionState = true;

                }
            }
            
        }
    }
}
