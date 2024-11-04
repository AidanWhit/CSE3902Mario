using Microsoft.Xna.Framework;
using Sprint_2.Controls;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameStates
{
    public class PausedState : Interfaces.IUpdateable
    {
        private KeyboardControl keyboardControl;
        public PausedState(KeyboardControl keyboardControl)
        {
            this.keyboardControl = keyboardControl;
            InitControls.InitializeNonMovementControls(keyboardControl);
        }

        public void Update(GameTime gameTime)
        {
            keyboardControl.Update();
        }
    }
}
