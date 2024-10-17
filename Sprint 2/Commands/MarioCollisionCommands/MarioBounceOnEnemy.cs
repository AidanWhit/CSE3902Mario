using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioBounceOnEnemy : ICommands
    {
        private IPlayer player;
        private IEnemy enemy;
        private Rectangle collisionRect;

        public MarioBounceOnEnemy(IPlayer player, IEnemy enemy, Rectangle collisionRect)
        {
            this.player = player;
            this.enemy = enemy;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            if (player.isFalling)
            {
                player.PlayerVelocity = new Vector2(player.PlayerVelocity.X, MarioPhysicsConstants.bounceVelocity);
                player.Jump();
                player.isJumping = true;
            }
        }
    }
}
