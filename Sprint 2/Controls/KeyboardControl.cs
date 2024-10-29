using Microsoft.Xna.Framework.Input;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sprint_2.Controls
{
    public class KeyboardControl : IController
    {
        private Dictionary<Keys, ICommands> controllerMappings;
        private Dictionary<Keys, ICommands> onPressCommandMappings;
        private Dictionary<Keys, ICommands> onReleaseCommandMappings;
        private Keys[] oldKeys = {};
        public KeyboardControl()
        {
            controllerMappings = new Dictionary<Keys, ICommands>();
            onPressCommandMappings = new Dictionary<Keys, ICommands>();
            onReleaseCommandMappings = new Dictionary<Keys, ICommands>();
        }

        public void RegisterCommand(Keys key, ICommands command)
        {
            controllerMappings.Add(key, command);
        }
        public void RegisterOnPressCommand(Keys key, ICommands command)
        {
            onPressCommandMappings.Add(key, command);
        }
        public void RegisterOnReleaseCommand(Keys key, ICommands command)
        {
            onReleaseCommandMappings.Add(key, command);
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
            foreach (Keys key in oldKeys)
            {
                /* Execute on release command */
                if (!pressedKeys.Contains(key) && onReleaseCommandMappings.ContainsKey(key))
                {
                    onReleaseCommandMappings[key].Execute();
                }
            }
            oldKeys = pressedKeys;

        }

        public void ClearCommands()
        {
            controllerMappings.Clear();
            onPressCommandMappings.Clear();
            onReleaseCommandMappings.Clear();
        }

        /* Testing 3 below to switch between different key mappings */
        public void SetControllerCommands(Dictionary<Keys, ICommands> commands)
        {
            controllerMappings = commands;
        }
        public void SetOnPressCommands(Dictionary<Keys, ICommands> onPressCommands)
        {
            onPressCommandMappings = onPressCommands;
        }
        public void SetOnReleaseCommands(Dictionary<Keys, ICommands> onReleaseCommands)
        {
            onReleaseCommandMappings = onReleaseCommands;
        }
    }
}
