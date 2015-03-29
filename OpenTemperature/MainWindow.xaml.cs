using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using OpenHardwareMonitor.Hardware;

namespace OpenTemperature
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Computer _computer;
        private bool _isComputerOpen;
        private DispatcherTimer _dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(_dispatcherTimer == null || _dispatcherTimer.IsEnabled))
            {
                _dispatcherTimer.Stop();
                _dispatcherTimer = null;
            }
            if (_isComputerOpen)
                _computer.Close();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _computer = new Computer
            {
                CPUEnabled = true,
                FanControllerEnabled = true,
                GPUEnabled = true,
                HDDEnabled = true,
                MainboardEnabled = true,
                RAMEnabled = true
            };
            try
            {
                _computer.Open();
                _isComputerOpen = true;
                UpdateSensorValue();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        void UpdateSensorValue()
        {
            foreach (IHardware hardware in _computer.Hardware)
            {
                ;
            }
        }
    }
}
