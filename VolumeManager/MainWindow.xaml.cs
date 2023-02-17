using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public MainWindow()
        {
            InitializeComponent();

            _coreAudioController = new();
            IEnumerable<CoreAudioDevice> playbackDevices = _coreAudioController.GetPlaybackDevices();

            cbDeviceList.ItemsSource = playbackDevices.Select(p => p.Name).ToList(); ;
            cbDeviceList.SelectedIndex = 0;

            sliderMasterVolume.Maximum = 100;

            _selectedDevice = playbackDevices.ElementAt(0);
        }

        private void cbDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedDevice = _coreAudioController.GetPlaybackDevices().First(p => p.Name == e.AddedItems[0]?.ToString());
            
            sliderMasterVolume.Value = _selectedDevice.Volume;
        }
    }
}
