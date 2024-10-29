using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2;
using Sprint_2.GameStates;

public class PauseCommand : ICommands
{
    public void Execute()
    {
        // Switch between Pasuse and Playing state
        SoundManager.Instance.PlaySoundEffect("pause");
        GameStateManager.Instance.TogglePause();

        if (Game1.Instance.gameState.GetType() == typeof(PausedState))
        {
            Game1.Instance.gameState = new PlayableState(Game1.Instance.GetKeyboardControl());
        }
        else
        {
            Game1.Instance.gameState = new PausedState(Game1.Instance.GetKeyboardControl());
        }
        
    }
}
