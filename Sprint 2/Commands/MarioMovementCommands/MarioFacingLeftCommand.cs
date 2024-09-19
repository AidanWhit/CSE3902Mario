using Sprint_2.Sprites;
using Sprint_2.Interfaces;

namespace Sprint_0.Commands.MarioMovementCommands
{
    public class MarioFacingLeftCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioFacingLeftCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            mario.MoveLeft();
        }
    }
}
