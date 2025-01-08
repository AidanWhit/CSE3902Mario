using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sprint_2.Interfaces
{
    public interface ISound
    {
        void Play();
        //DEBUG
        SoundEffectInstance CreateInstance();
        // TODO: implement the followings after we have pause/win/gameover state
        void Stop();
        void Pause();
        void Resume();
        void SetVolume(float volume);
    }
}

