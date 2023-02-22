using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VolumeManager.Components
{
    /// <summary>
    /// Interaction logic for VolumeManager.xaml
    /// </summary>
    public partial class DeviceVolumeControl : UserControl
    {
        public CoreAudioDevice? _device { get; set; }
        private IDisposable? _deviceVolumeObserver;

        public DeviceVolumeControl()
        {
            InitializeComponent();
            
        }

        public void ChangeDevice (CoreAudioDevice device)
        {
            if (device == null) return;

            // Stop observing the old device
            if (_deviceVolumeObserver != null)
                _deviceVolumeObserver.Dispose();

            // Change our device reference
            _device = device;

            // Begin observing the new device
            _deviceVolumeObserver = _device.VolumeChanged.Subscribe(new DeviceVolumeObserver(sliderVolume));
            
            // Make the visual changes to reflect the device change
            labelSource.Content = _device.FullName;
            SetVolume(_device.Volume);
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderVolume.IsEnabled && _device != null)
            {
                SetVolume(e.NewValue);
            }
        }

        private void SetVolume(double volume)
        {
            if (_device == null) return;

            double val = Math.Round(volume);

            _device.Volume = val;
            labelPercenValue.Content = $"{val}%";
        }
    }
}
