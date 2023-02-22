using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi;
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
using VolumeManager.Wrappers;

namespace VolumeManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoreAudioController _coreAudioController;

        public MainWindow()
        {
            InitializeComponent();

            _coreAudioController = new();
            IEnumerable<CoreAudioDevice> playbackDevices = _coreAudioController.GetPlaybackDevices().Where(d => d.State != AudioSwitcher.AudioApi.DeviceState.Disabled);
            List<AudioDeviceWrapper> myList = new();
            playbackDevices.Where(d => d.State == DeviceState.Active).ToList().ForEach(p => {
                myList.Add(new(p)); 
            });

            comboBoxDeviceList.ItemsSource = myList;
            comboBoxDeviceList.SelectedIndex = 0;
        }

        private void comboBoxDeviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count < 1)
            {
                Trace.WriteLine("No Device Selected");
                return;
            }
            AudioDeviceWrapper selectedDevice = e.AddedItems[0] as AudioDeviceWrapper;
            Trace.WriteLine(selectedDevice.ToString());
            masterVolumeControl.ChangeDevice(selectedDevice._device);
        }
    }
}
