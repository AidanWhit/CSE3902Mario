using Sprint_2.Interfaces;
using Sprint_2.Sprites;

namespace Sprint_0.Commands.MarioMovementCommands
{
    public class MarioFacingUpCommand : ICommands
    {
        private Game1 myGame;
        private Player mario;

        public MarioFacingUpCommand(Game1 game, Player player)
        {
            myGame = game;
            mario = player;
        }

        public void Execute()
        {
            mario.Jump();
        }
    }
}
