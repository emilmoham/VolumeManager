using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace VolumeManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoreAudioController _coreAudioController;
        private CoreAudioDevice _selectedDevice;

        private IDisposable _masterVolumeObserver;

        public MainWindow()
        {
            InitializeComponent();

            _coreAudioController = new();
            IEnumerable<CoreAudioDevice> playbackDevices = _coreAudioController.GetPlaybackDevices().Where(d => d.State != AudioSwitcher.AudioApi.DeviceState.Disabled);

            comboBoxDeviceList.ItemsSource = playbackDevices.ToList(); ;
            comboBoxDeviceList.SelectedIndex = 0;

            _selectedDevice = playbackDevices.ElementAt(0);

            //_masterVolumeObserver = _selectedDevice.VolumeChanged.Subscribe(new DeviceVolumeObserver(sliderMasterVolume));

        }

        //private void cbDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.AddedItems.Count < 1) 
        //    {
        //        Trace.WriteLine("No Device Selected");
        //        return; 
        //    }

        //    _selectedDevice = e.AddedItems[0]as CoreAudioDevice;
            
        //    sliderMasterVolume.Value = _selectedDevice.Volume;
        //    if (_masterVolumeObserver != null)
        //        _masterVolumeObserver.Dispose();
        //    _masterVolumeObserver = _selectedDevice.VolumeChanged.Subscribe(new DeviceVolumeObserver(sliderMasterVolume));
        //}

        //private void sliderMasterVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if(sliderMasterVolume.IsEnabled)
        //    {
        //        _selectedDevice.Volume = e.NewValue;
        //    }
        //}
    }
}
