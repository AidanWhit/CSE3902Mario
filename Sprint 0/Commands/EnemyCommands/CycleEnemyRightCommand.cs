using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Commands;
using Sprint_0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_0.Commands.EnemyCommands
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
            myGame.SetSprite(new Sprite1(texture, 1, 2));
        }
    }
}
