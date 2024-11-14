﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Commands.MarioAttackCommands;
using Sprint_2.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;

namespace Sprint_2.Controls
{
    public class MouseController : IController
    {
        private MouseState mouseState;
        private MouseState previousState;

        /* Potentially will only have one mouse command */
        private ICommands shoot = new MarioShootCommand(Game1.Instance.mario);

        private ICommands currentCommand;
        private bool pressedFlag = false;
        public MouseController()
        {
            previousState = Mouse.GetState();
            currentCommand = null;
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
            /* Only executes shoot on a left click */
            if (mouseState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released) 
            {
                shoot.Execute();
            }
            previousState = mouseState;
            
        }

        public Point GetCurrentMousePos()
        {
            return mouseState.Position;
        }
    }
}
