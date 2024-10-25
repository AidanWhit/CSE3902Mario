using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Commands.MarioAttackCommands;
using Sprint_2.Commands.MarioItemCommands;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Commands.ProgramCommands;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sprint_2.Controls
{
    internal static class InitControls
    {
        public static void initializeControls(KeyboardControl keyControl, IPlayer mario, Game1 game)
        {
            keyControl.RegisterCommand(Keys.W, new MarioFacingUpCommand(mario));
            keyControl.RegisterCommand(Keys.S, new MarioFacingDownCommand(mario));
            keyControl.RegisterCommand(Keys.D, new MarioFacingRightCommand(mario));
            keyControl.RegisterCommand(Keys.A, new MarioFacingLeftCommand(mario));

            keyControl.RegisterCommand(Keys.Up, new MarioFacingUpCommand(mario));
            keyControl.RegisterCommand(Keys.Down, new MarioFacingDownCommand(mario));
            keyControl.RegisterCommand(Keys.Left, new MarioFacingRightCommand(mario));
            keyControl.RegisterCommand(Keys.Right, new MarioFacingLeftCommand(mario));

            keyControl.RegisterOnPressCommand(Keys.Z, new MarioAttackNormalCommand(mario));
            keyControl.RegisterOnPressCommand(Keys.D3, new MarioPowerUpCommand(mario, null, Rectangle.Empty));
            keyControl.RegisterOnPressCommand(Keys.E, new MarioHurtCommand(mario, null, Rectangle.Empty));
            keyControl.RegisterCommand(Keys.Q, new QuitCommand(game));
            keyControl.RegisterCommand(Keys.R, new ResetCommand());

            keyControl.RegisterOnPressCommand(Keys.P, new PauseCommand());

            keyControl.RegisterOnReleaseCommand(Keys.S, new MarioOnCrouchRelease(mario));
            keyControl.RegisterOnPressCommand(Keys.S, new MarioOnCrouchPress(mario));
            keyControl.RegisterOnReleaseCommand(Keys.W, new MarioJumpReleaseCommand(mario));
        }

    }
}
