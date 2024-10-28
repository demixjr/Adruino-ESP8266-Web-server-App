using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Threading;

namespace ArduinoControl
{
    public partial class MainWindow : Window
    {
        private SerialPort _serialPort;

        public MainWindow()
        {
            InitializeComponent();

            _serialPort = new SerialPort("COM3", 9600);
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _serialPort.ReadLine().Trim();

            if (data == "ButtonPressed")
            {
                Dispatcher.Invoke(() =>
                {
                    ButtonStatusText.Text = "Button pressed";
                });
            }
            else if (data == "ButtonReleased")
            {
                Dispatcher.Invoke(() =>
                {
                    ButtonStatusText.Text = "Button not pressed";
                });
            }
        }

        private void LedOnButton4_Click(object sender, RoutedEventArgs e)
        {
            _serialPort.Write("1"); 
        }

        private void LedOffButton4_Click(object sender, RoutedEventArgs e)
        {
            _serialPort.Write("2"); 
        }

        private void LedOnButton5_Click(object sender, RoutedEventArgs e)
        {
            _serialPort.Write("3"); 
        }

        private void LedOffButton5_Click(object sender, RoutedEventArgs e)
        {
            _serialPort.Write("4"); 
        }

        protected override void OnClosed(EventArgs e)
        {
            _serialPort.Close();
            base.OnClosed(e);
        }
    }
}
