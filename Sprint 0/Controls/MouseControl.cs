using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint_0.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0.Controls
{
    internal class MouseControl : IController
    {
        private MouseState oldState;
        private Texture2D texture;
        private ICommands commands;
        private Game1 game;
        public MouseControl(Game1 game)
        {
            this.game = game;
            commands = new Sprite1Command(game, texture);
        }

        public void getTexture(Texture2D texture)
        {
            this.texture = texture;
        }



        public void Update()
        {
            MouseState newState = Mouse.GetState();
            // Switch case? Oops!
            if (newState != oldState)
            {
                if (newState.RightButton == ButtonState.Pressed)
                {
                    commands = new QuitCommand(game);
                    commands.Execute();
                }
                else if (newState.LeftButton == ButtonState.Pressed)
                {
                    if (newState.Position.X < 400)
                    {
                        if (newState.Position.Y < 240)
                        {
                            commands = new Sprite1Command(game, texture);
                    }
                    else
                        {
                            commands = new Sprite3Command(game, texture);
                    }
                }
                    else
                    {
                        if (newState.Position.Y < 240)
                        {
                            commands = new Sprite2Command(game, texture);
                        }
                        else
                        {
                            commands = new Sprite4Command(game, texture);
                        }

                    }
                commands.Execute();
                }
        }

        oldState = newState;
        }
    }
}
