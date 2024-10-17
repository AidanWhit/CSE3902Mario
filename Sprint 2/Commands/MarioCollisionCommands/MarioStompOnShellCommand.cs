using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioStompOnShellCommand : ICommands
    {
        private IPlayer player;
        private Shell shell;
        private Rectangle collisionRect;

        public MarioStompOnShellCommand(Shell shell, IPlayer player, Rectangle collisionRect)
        {
            this.player = player;
            this.shell = shell;
            this.collisionRect = collisionRect;
        }
        public void Execute()
        {
            if (shell.Velocity.X != 0)
            {
                shell.Velocity = Vector2.Zero;
            }
        }
    }
}
