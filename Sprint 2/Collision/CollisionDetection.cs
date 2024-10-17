
using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sprint_2.Collision
{
    public class CollisionDetection
    {
        
        private GameObjectManager gameObjectManager;
        private CollisionResponse collisionResponse;
        private IPlayer player;
        public CollisionDetection(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
            collisionResponse = new CollisionResponse(gameObjectManager);
        }

        /*
        public void DetectCollisions()
        {
            player = Game1.Instance.mario;
            int marioColumn = player.XPos / 16;
            List<IBlock> blocks = gameObjectManager.GetNearbyBlocks(marioColumn);
            foreach (IBlock block in blocks.ToList())
            {
                if (player.GetHitBox().Intersects(block.GetHitBox()))
                {
                    BlockCollisionResponse.BlockReponseForPlayer(player, block);
                }
            }

            foreach (IItem item in gameObjectManager.Items.ToList())
            {
                int itemColumn = (int)(item.XPos / 16);
                blocks = gameObjectManager.GetNearbyBlocks(itemColumn);
                foreach(IBlock block in blocks.ToList())
                {
                    if (item.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockCollisionResponseForItem(item, block);
                    }
                }
                foreach(IPipe pipe in gameObjectManager.Pipes)
                {
                    if (item.GetHitBox().Intersects(pipe.GetHitBox()))
                    {
                        PipeCollisionResponse.PipeResponseForItem(item, pipe);
                    }
                }
                if (item.GetHitBox().Intersects(player.GetHitBox()))
                {
                    ItemCollisionResponse.ItemResponseForPlayer(item, player);
                }
            }

            foreach (IProjectile fireball in player.fireballs)
            {
                int fireballColumn = (int)(fireball.XPos / 16);
                blocks = gameObjectManager.GetNearbyBlocks(fireballColumn);
                foreach(IBlock block in blocks)
                {
                    if (fireball.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockResponseForFireball(fireball, block);
                    }
                }
                foreach (IPipe pipe in gameObjectManager.Pipes)
                {
                    if (fireball.GetHitBox().Intersects(pipe.GetHitBox()))
                    {
                        PipeCollisionResponse.PipeResponseForFireBall(pipe, fireball);
                    }
                }
                foreach (IEnemy enemy in gameObjectManager.Enemies)
                {
                    if (fireball.GetHitBox().Intersects(enemy.GetHitBox()))
                    {
                        FireballCollisionResponder.FireballResponderForEnemies(fireball, enemy);
                    }
                }
            }

            foreach (IPipe pipe in gameObjectManager.Pipes)
            { 
                if (player.GetHitBox().Intersects(pipe.GetHitBox()))
                {
                    PipeCollisionResponse.PipeResponseForPlayer(player, pipe);
                }
            }

            foreach (IEnemy enemy in gameObjectManager.Enemies.ToList())
            {
                int enemyColumn = (int)(enemy.XPos / 16);
                blocks = gameObjectManager.GetNearbyBlocks(enemyColumn);
                foreach (IBlock block in blocks)
                {
                    if (enemy.GetHitBox().Intersects(block.GetHitBox()))
                    {
                        BlockCollisionResponse.BlockResponseForEnemy(enemy, block);
                    }
                }
                foreach (IPipe pipe in gameObjectManager.Pipes)
                {
                    if (enemy.GetHitBox().Intersects(pipe.GetHitBox()))
                    {
                        PipeCollisionResponse.PipeResponseForEnemy(enemy, pipe);
                    }
                }
                foreach (IEnemy enemy2 in gameObjectManager.Enemies.ToList())
                {
                    if (!enemy.Equals(enemy2) && enemy.GetHitBox().Intersects(enemy2.GetHitBox()))
                    {
                        EnemyCollisionResponder.EnemyResponseForEnemy(enemy, enemy2);
                    }
                }
                if (enemy.GetHitBox().Intersects(player.GetHitBox()))
                {
                    if (enemy is Shell)
                    {
                        EnemyCollisionResponder.ShellResponseForPlayer(enemy, player);
                    }
                    else
                    {
                        EnemyCollisionResponder.EnemyResponseForPlayer(enemy, player);
                    }
                }
            }
        }
        */
        public void DetectCollision()
        {
            player = Game1.Instance.mario;
            GameObjectManager.Instance.Movers.Add(player);

            foreach(ICollideable mover in GameObjectManager.Instance.Movers.ToList())
            {
                
                int column = mover.GetColumn();
                List<ICollideable> nearbyBlocks = GameObjectManager.Instance.GetNearbyBlocks2(column);
                foreach(ICollideable nonmover in GameObjectManager.Instance.Static.ToList())
                {
                    if (mover.GetHitBox().Intersects(nonmover.GetHitBox()))
                    {
                        Rectangle collisionRect;
                        CollisionSideDetector.side side;
                        (collisionRect, side) = CollisionSideDetector.DetermineCollisionSide(mover.GetHitBox(), nonmover.GetHitBox());

                        collisionResponse.ResolveCollision(mover, nonmover, side.ToString(), collisionRect);
                    }
                }
                GameObjectManager.Instance.RemoveBlocksFromStatic(nearbyBlocks);
            }
            foreach(ICollideable mover1 in GameObjectManager.Instance.Movers.ToList())
            {
                foreach(ICollideable mover2 in GameObjectManager.Instance.Movers.ToList())
                {
                    if (!mover1.Equals(mover2) && mover1.GetHitBox().Intersects(mover2.GetHitBox()))
                    {
                        Rectangle collisionRect;
                        CollisionSideDetector.side side;
                        (collisionRect, side) = CollisionSideDetector.DetermineCollisionSide(mover1.GetHitBox(), mover2.GetHitBox());

                        collisionResponse.ResolveCollision(mover1, mover2, side.ToString(), collisionRect);
                    }
                }
            }
            GameObjectManager.Instance.Movers.Remove(player);
            //int marioColumn = player.XPos / 16;
            //List<ICollideable> blocks = gameObjectManager.GetNearbyBlocks2(marioColumn);
            //foreach (ICollideable block in blocks)
            //{
            //    if (player.GetHitBox().Intersects(block.GetHitBox()))
            //    {
            //        Rectangle collisionRect;
            //        CollisionSideDetector.side side;
            //        (collisionRect, side) = CollisionSideDetector.DetermineCollisionSide(player.GetHitBox(), block.GetHitBox());
            //        collisionResponse.ResolveCollision(player, block, side.ToString(), collisionRect);
            //    }
            //}
        }
    }
}
