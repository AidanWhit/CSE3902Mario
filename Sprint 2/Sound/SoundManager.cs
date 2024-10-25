using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Sprint_2.Interfaces;

namespace Sprint_2.Sound
{
    public class SoundManager
    {
        
        private static SoundManager instance;
        private Dictionary<string, ISound> soundEffects; // holds all SFX
        private Dictionary<string, Song> backgroundMusic; // holds all BGM

        private SoundManager()
        {
            soundEffects = new Dictionary<string, ISound>();
            backgroundMusic = new Dictionary<string, Song>();
        }

        // SoundManager is a Singleton
        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundManager();
                }
                return instance;
            }
        }
        // Load all background music for now, this will become a load-from-xml-file thing later
        public void LoadAllBGM(ContentManager content)
        {
            LoadBackgroundMusic("mainTheme", content.Load<Song>("01-main-theme-overworld"));
            LoadBackgroundMusic("starman", content.Load<Song>("05-starman"));
            LoadBackgroundMusic("levelComplete", content.Load<Song>("06-level-complete"));
            LoadBackgroundMusic("youAreDead", content.Load<Song>("08-you-re-dead"));
        }

        // Load all sound effects for now, this will become a load-from-xml-file thing later
        public void LoadAllSFX(ContentManager content)
        {
            LoadSoundEffect("breakBlock", content.Load<SoundEffect>("smb_breakblock"));
            LoadSoundEffect("stomp", content.Load<SoundEffect>("smb_stomp"));
            LoadSoundEffect("stageClear", content.Load<SoundEffect>("smb_stage_clear"));
            LoadSoundEffect("marioDie", content.Load<SoundEffect>("smb_mariodie"));
            LoadSoundEffect("kick", content.Load<SoundEffect>("smb_kick"));
            LoadSoundEffect("jumpSmall", content.Load<SoundEffect>("smb_jumpsmall"));
            LoadSoundEffect("flagpole", content.Load<SoundEffect>("smb_flagpole"));
            LoadSoundEffect("coin", content.Load<SoundEffect>("smb_coin"));
            //
            LoadSoundEffect("1-up", content.Load<SoundEffect>("smb_1-up"));
            LoadSoundEffect("bump", content.Load<SoundEffect>("smb_bump"));
            LoadSoundEffect("fireball", content.Load<SoundEffect>("smb_fireball"));
            LoadSoundEffect("pause", content.Load<SoundEffect>("smb_pause"));
            LoadSoundEffect("powerUp", content.Load<SoundEffect>("smb_powerup"));
            LoadSoundEffect("powerUpAppears", content.Load<SoundEffect>("smb_powerup_appears"));

        }
        // Play the background music by the key in the dictionary ("main theme" is default)
        public void PlayBGM(string musicKey)
        {
            if (backgroundMusic.ContainsKey(musicKey))
            {
                MediaPlayer.Play(backgroundMusic[musicKey]);
                MediaPlayer.IsRepeating = musicKey == "mainTheme";  // playing the music looped
            }
        }
        // Load 1 sound effect and add it to the dictionary
        public void LoadSoundEffect(string name, SoundEffect soundEffect)
        {
            if (!soundEffects.ContainsKey(name))
            {
                soundEffects.Add(name, new SoundEffectWrapper(soundEffect));
            }
        }

        // Load 1 background music and add it to the dictionary
        public void LoadBackgroundMusic(string name, Song song)
        {
            if (!backgroundMusic.ContainsKey(name))
            {
                backgroundMusic.Add(name, song);
            }
        }

        // Play a sound effect by name
        public void PlaySoundEffect(string name)
        {
            if (soundEffects.ContainsKey(name))
            {
                soundEffects[name].Play();
            }
        }

        // Play background music by name
        public void PlayBackgroundMusic(string name)
        {
            if (backgroundMusic.ContainsKey(name))
            {
                MediaPlayer.Play(backgroundMusic[name]);
            }
        }

        // Stop the currently playing background music
        public void StopBackgroundMusic()
        {
            MediaPlayer.Stop();
        }

        // Set volume for background music
        public void SetMusicVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }

        // Set volume for sound effects
        public void SetSoundEffectVolume(string name, float volume)
        {
            if (soundEffects.ContainsKey(name))
            {
                soundEffects[name].SetVolume(volume);
            }
        }

        // DEBUG: when the game resets, there will be an error: System.ObjectDisposedException: 'Cannot access a disposed object.
        // Reset SoundManager to handle game reload
        public void Reset()
        {
            MediaPlayer.Stop();
            soundEffects.Clear();
            backgroundMusic.Clear();
        }
    }
}
