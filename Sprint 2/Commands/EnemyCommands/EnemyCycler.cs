using Sprint_2.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint_2.Commands.EnemyCommands
{
    public class EnemyCycler
    {
        private List<IEnemy> enemies;
        private int currentEnemyIndex;

        public EnemyCycler(List<IEnemy> enemies)
        {
            this.enemies = enemies;
            currentEnemyIndex = 0;
        }

        // Methods to cycle enemies
        public IEnemy CycleEnemyLeft()
        {
            currentEnemyIndex = (currentEnemyIndex - 1 + enemies.Count) % enemies.Count;
            return enemies[currentEnemyIndex];
        }

        public IEnemy CycleEnemyRight()
        {
            currentEnemyIndex = (currentEnemyIndex + 1) % enemies.Count;
            return enemies[currentEnemyIndex];
        }
    }
}
