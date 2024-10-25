using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Sprint_2.Interfaces;

public enum GameState
{
	Playing,
	Paused,
	GameOver
	//,Win
}

public class GameStateManager
{
	private static GameStateManager instance;
	private GameState currentState;

	private GameStateManager()
	{
		currentState = GameState.Playing;
	}

	// GameStateManager is a Singleton 
	public static GameStateManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameStateManager();
			}
			return instance;
		}
	}

	// gets the current state
	public GameState CurrentState
	{
		get { return currentState; }
	}

	// Pauses the game
	public void PauseGame()
	{
		currentState = GameState.Paused;
		MediaPlayer.Pause();  
	}

	// Resumes the game
	public void ResumeGame()
	{
		currentState = GameState.Playing;
		MediaPlayer.Resume(); 
	}

	public void WinGame()
	{
	}

	// Switch between Paused and Playing state
	public void TogglePause()
	{
		if (currentState == GameState.Playing)
		{
			PauseGame();
		}
		else if (currentState == GameState.Paused)
		{
			ResumeGame();
		}
	}
}
