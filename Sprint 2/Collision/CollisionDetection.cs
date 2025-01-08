
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_2.Collision
{
    public class CollisionDetection
    {
        
        private GameObjectManager gameObjectManager;
        private IPlayer player;
        public CollisionDetection(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
        }

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
    }
}
