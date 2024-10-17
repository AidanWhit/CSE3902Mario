using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.ItemSprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.CollisionCommands.ItemCollisionCommands
{
    public class StarCollidesWithPlayer : ICommands
    {
        private Star star;
        private IPlayer player;
        private Rectangle collisionIntersection;

        public StarCollidesWithPlayer(Star star, IPlayer player, Rectangle collisionIntersection)
        {
            this.star = star;
            this.player = player;
            this.collisionIntersection = collisionIntersection;
        }

        public void Execute()
        {
            star.DeleteItem();
        }
    }
}
