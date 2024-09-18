using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sprint_0.Controls
{
    internal class KeyboardControl : IController
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Keys[] oldKeys = {};
        public KeyboardControl()
        {
            controllerMappings = new Dictionary<Keys, ICommands>();
        }

        public void RegisterCommand(Keys key, ICommands command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (!oldKeys.Contains(key) && controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
            oldKeys = pressedKeys;

        }

        public void ClearCommands()
        {
            controllerMappings.Clear();
        }

    }
}
