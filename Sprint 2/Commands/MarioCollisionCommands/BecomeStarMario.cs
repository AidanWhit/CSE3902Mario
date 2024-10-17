using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class BecomeStarMario : ICommands
    {
        private IPlayer player;
        private Star star;
        private Rectangle collisionRectangle;

        public BecomeStarMario(IPlayer player, Star star, Rectangle collisionRectangle)
        {
            this.player = player;
            this.star = star;
            this.collisionRectangle = collisionRectangle;
        }

        public void Execute()
        {
            Game1.Instance.mario = new StarMario(player);
        }
    }
}
