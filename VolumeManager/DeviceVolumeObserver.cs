using AudioSwitcher.AudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VolumeManager
{
    public class DeviceVolumeObserver : IObserver<DeviceVolumeChangedArgs>
    {
        Slider _slider;
        
        public DeviceVolumeObserver(Slider slider)
        {
            _slider = slider;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(DeviceVolumeChangedArgs value)
        {
            double discreteValue = Math.Round(value.Volume);
            _slider.Dispatcher.Invoke(() =>
            {
                _slider.IsEnabled = false;
                _slider.Value = discreteValue;
                _slider.IsEnabled = true;
            });
        }
    }
}
