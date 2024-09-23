﻿using Sprint_2.Interfaces;
using Sprint_2.Sprites;


namespace Sprint_2.Commands.MarioMovementCommands

{
    public class MarioFacingRightCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioFacingRightCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            mario.MoveRight();
        }
    }
}


