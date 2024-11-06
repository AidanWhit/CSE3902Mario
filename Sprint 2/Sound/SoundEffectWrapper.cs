using Microsoft.Xna.Framework.Audio;
using Sprint_2.Interfaces;

namespace Sprint_2.Sound
{
    public class SoundEffectWrapper : ISound
    {
        private SoundEffectInstance soundEffectInstance;

        public SoundEffectWrapper(SoundEffect soundEffect)
        {
            soundEffectInstance = soundEffect.CreateInstance();
        }

        public void Play()
        {
            soundEffectInstance.Play();
        }

        // TODO: implement the followings after we have pause/win/gameover state
        public void Stop()
        {
            soundEffectInstance.Stop();
        }

        public void Pause()
        {
            soundEffectInstance.Pause();
        }

        public void Resume()
        {
            soundEffectInstance.Resume();
        }

        public void SetVolume(float volume)
        {
            soundEffectInstance.Volume = volume;
        }
    }
}