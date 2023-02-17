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

        public string SourceName
        {
            get { return (string)GetValue(SourceNameProperty); }
            set { SetValue(SourceNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceNameProperty =
            DependencyProperty.Register("SourceName", typeof(string), typeof(DeviceVolumeControl), new PropertyMetadata(string.Empty));



        public DeviceVolumeControl()
        {
            InitializeComponent();
        }
    }
}
