using Microsoft.Xna.Framework;
using Sprint_2.Constants;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class ShellStateIdle : AbstractShellState
    {
        private Shell shell;
        private float timeUntilShellBecomesKoopa;
        public ShellStateIdle(Shell shell) : base(shell)
        {
            timeUntilShellBecomesKoopa = EnemyConstants.timeUntilShellBecomesKoopa;
            this.shell = shell;
        }
        public override void Update(GameTime gameTime)
        {
            timeUntilShellBecomesKoopa -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeUntilShellBecomesKoopa < 0)
            {
                Koopa koopa = new Koopa(new Vector2(shell.XPos, shell.YPos - shell.GetHitBox().Height));
                GameObjectManager.Instance.Movers.Add(koopa);
                GameObjectManager.Instance.Updateables.Add(koopa);
                GameObjectManager.Instance.Drawables.Add(koopa);

                GameObjectManager.Instance.Movers.Remove(shell);
                GameObjectManager.Instance.Updateables.Remove(shell);
                GameObjectManager.Instance.Drawables.Remove(shell);
            }
            UpdatePosition(gameTime);
        }
    }
}
