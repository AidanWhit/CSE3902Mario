using Microsoft.Xna.Framework.Input;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_2.Controls
{
    internal class KeyboardControl : IController
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Dictionary<Keys, ICommands> onPressCommandMappings;
        private Keys[] oldKeys = {};
        public KeyboardControl()
        {
            controllerMappings = new Dictionary<Keys, ICommands>();
            onPressCommandMappings = new Dictionary<Keys, ICommands>();
        }

        public void RegisterCommand(Keys key, ICommands command)
        {
            controllerMappings.Add(key, command);
        }
        public void RegisterOnPressCommand(Keys key, ICommands command)
        {
            onPressCommandMappings.Add(key, command);
        }
        
        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                /* Commands that will happens on press and hold will be executed here */
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
                /* Commands that will happen on press are executed here */
                if (!oldKeys.Contains(key) && onPressCommandMappings.ContainsKey(key))
                {
                    onPressCommandMappings[key].Execute();
                }
            }
            oldKeys = pressedKeys;

        }

        public void ClearCommands()
        {
            controllerMappings.Clear();
            onPressCommandMappings.Clear();
        }

    }
}
