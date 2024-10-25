using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PauseCommand : ICommands
{
    public void Execute()
    {
        // Switch between Pasuse and Playing state
        SoundManager.Instance.PlaySoundEffect("pause");
        GameStateManager.Instance.TogglePause();
    }
}
