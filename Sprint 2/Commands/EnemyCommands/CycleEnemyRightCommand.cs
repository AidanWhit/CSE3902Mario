using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_2.Commands.EnemyCommands
{
    public class CycleEnemyRightCommand : ICommands
    {
        private Game1 myGame;
        private Texture2D texture;

        public CycleEnemyRightCommand(Game1 game, Texture2D texture)
        {
            myGame = game;
            this.texture = texture;
        }

        public void Execute()
        {
            // Modified on 9/20 by Jingyu Fu
            myGame.CycleEnemyLeft();
        }
    }
}
