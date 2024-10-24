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
        // Load all background music
        public void LoadAllBGM(ContentManager content)
        {
            backgroundMusic.Add("mainTheme", content.Load<Song>("01-main-theme-overworld"));
            backgroundMusic.Add("starman", content.Load<Song>("05-starman"));
            backgroundMusic.Add("levelComplete", content.Load<Song>("06-level-complete"));
            backgroundMusic.Add("youAreDead", content.Load<Song>("08-you-re-dead"));
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
        //// Load 1 sound effect and add it to the dictionary
        //public void LoadSoundEffect(string name, SoundEffect soundEffect)
        //{
        //    if (!soundEffects.ContainsKey(name))
        //    {
        //        soundEffects.Add(name, new SoundEffectWrapper(soundEffect));
        //    }
        //}

        //// Load 1 background music and add it to the dictionary
        //public void LoadBackgroundMusic(string name, Song song)
        //{
        //    if (!backgroundMusic.ContainsKey(name))
        //    {
        //        backgroundMusic.Add(name, song);
        //    }
        //}

        //// Play a sound effect by name
        //public void PlaySoundEffect(string name)
        //{
        //    if (soundEffects.ContainsKey(name))
        //    {
        //        soundEffects[name].Play();
        //    }
        //}

        //// Play background music by name
        //public void PlayBackgroundMusic(string name)
        //{
        //    if (backgroundMusic.ContainsKey(name))
        //    {
        //        MediaPlayer.Play(backgroundMusic[name]);
        //    }
        //}

        //// Stop the currently playing background music
        //public void StopBackgroundMusic()
        //{
        //    MediaPlayer.Stop();
        //}

        //// Set volume for background music
        //public void SetMusicVolume(float volume)
        //{
        //    MediaPlayer.Volume = volume;
        //}

        //// Set volume for sound effects
        //public void SetSoundEffectVolume(string name, float volume)
        //{
        //    if (soundEffects.ContainsKey(name))
        //    {
        //        soundEffects[name].SetVolume(volume);
        //    }
        //}
    }
}
