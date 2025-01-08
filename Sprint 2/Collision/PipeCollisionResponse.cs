using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using System;


namespace Sprint_2.Collision
{
    public class PipeCollisionResponse
    {
        public static void PipeResponseForFireBall(IPipe pipe, IProjectile fireball)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            Rectangle fireballHitBox = fireball.GetHitBox();
            Rectangle pipeHitBox = pipe.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(fireballHitBox, pipeHitBox);

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

        public static void PipeResponseForItem(IItem item, IPipe pipe)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(item.GetHitBox(), pipe.GetHitBox());

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
            else /* Should never be able to collide with the bottom*/
            {
                item.YPos += collisionIntersection.Height;
            }
        }

        public static void PipeResponseForEnemy(IEnemy enemy, IPipe pipe)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(enemy.GetHitBox(), pipe.GetHitBox());

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
                    enemy.YPos = pipe.GetHitBox().Top - enemy.GetHitBox().Bottom;
                }
                else /* Bottom Collision shouldn't happen*/
                {
                    enemy.YPos += collisionIntersection.Height;
                }
            }
        }

        public static void PipeResponseForPlayer(IPlayer player, IPipe pipe)
        {
            Rectangle collisionIntersection;
            CollisionSideDetector.side side;

            Rectangle playerHitBox = player.GetHitBox();
            Rectangle pipeHitBox = pipe.GetHitBox();

            (collisionIntersection, side) = CollisionSideDetector.DetermineCollisionSide(playerHitBox, pipeHitBox);

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
            else /* Shouldn't happen*/
            {
                /* Code not written because mario shouldn't be able to collide
                 * with underside of the pipe */
            }
        }
    }
}
