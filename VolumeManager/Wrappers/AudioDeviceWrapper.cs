using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeManager.Wrappers
{
    public class AudioDeviceWrapper
    {
        public CoreAudioDevice _device { get; set; }

        public AudioDeviceWrapper (CoreAudioDevice device)
        {
            _device = device;
        }

        public override string ToString()
        {
            return _device.FullName;
        }
    }
}
