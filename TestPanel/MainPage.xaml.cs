using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Devices.Enumeration;
using Windows.Devices.Gpio;
using System.Diagnostics;
using Windows.UI.Core;

namespace TestPanel
{
    public sealed partial class MainPage : Page
    {
        private GpioPin io02; // pin 3, SDA
        private GpioPin io03; // pin 5, SCL
        private GpioPin io04; // pin 7, GCL
        private GpioPin io05; // pin 29
        private GpioPin io06; // pin 31
        private GpioPin io07; // pin 26, CE1
        private GpioPin io08; // pin 24, CE0
        private GpioPin io09; // pin 21, MISO
        private GpioPin io10; // pin 19, MOSI
        private GpioPin io11; // pin 23, CLK
        private GpioPin io12; // pin 32
        private GpioPin io13; // pin 33
        private GpioPin io16; // pin 36
        private GpioPin io17; // pin 11
        private GpioPin io18; // pin 12
        private GpioPin io19; // pin 35
        private GpioPin io20; // pin 38
        private GpioPin io21; // pin 40
        private GpioPin io22; // pin 15
        private GpioPin io23; // pin 16
        private GpioPin io24; // pin 18
        private GpioPin io25; // pin 22
        private GpioPin io26; // pin 37
        private GpioPin io27; // pin 13

        private Dictionary<String, GpioPin> pinDictionary = new Dictionary<string, GpioPin>();
        private Dictionary<ToggleSwitch, ToggleSwitch> tsDictionary = new Dictionary<ToggleSwitch, ToggleSwitch>();
        private Dictionary<int, ToggleSwitch> statusDictionary = new Dictionary<int, ToggleSwitch>();

        public MainPage()
        {
            this.InitializeComponent();
            var gpio = GpioController.GetDefault();

            io02 = gpio.OpenPin(2);
            io03 = gpio.OpenPin(3);
            io04 = gpio.OpenPin(4);
            io05 = gpio.OpenPin(5);
            io06 = gpio.OpenPin(6);
            io07 = gpio.OpenPin(7);
            io08 = gpio.OpenPin(8);
            io09 = gpio.OpenPin(9);
            io10 = gpio.OpenPin(10);
            io11 = gpio.OpenPin(11);
            io12 = gpio.OpenPin(12);
            io13 = gpio.OpenPin(13);
            io16 = gpio.OpenPin(16);
            io17 = gpio.OpenPin(17);
            io18 = gpio.OpenPin(18);
            io19 = gpio.OpenPin(19);
            io20 = gpio.OpenPin(20);
            io21 = gpio.OpenPin(21);
            io22 = gpio.OpenPin(22);
            io23 = gpio.OpenPin(23);
            io24 = gpio.OpenPin(24);
            io25 = gpio.OpenPin(25);
            io26 = gpio.OpenPin(26);
            io27 = gpio.OpenPin(27);

            io02.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io03.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io04.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io05.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io06.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io07.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io08.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io09.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io10.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io11.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io12.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io13.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io16.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io17.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io18.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io19.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io20.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io21.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io22.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io23.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io24.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io25.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io26.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io27.SetDriveMode(GpioPinDriveMode.InputPullDown);

            io02.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io03.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io04.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io05.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io06.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io07.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io08.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io09.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io10.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io11.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io12.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io13.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io16.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io17.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io18.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io19.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io20.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io21.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io22.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io23.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io24.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io25.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io26.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            io27.DebounceTimeout = TimeSpan.FromMilliseconds(50);

            io02.ValueChanged += Pin_ValueChanged;
            io03.ValueChanged += Pin_ValueChanged;
            io04.ValueChanged += Pin_ValueChanged;
            io05.ValueChanged += Pin_ValueChanged;
            io06.ValueChanged += Pin_ValueChanged;
            io07.ValueChanged += Pin_ValueChanged;
            io08.ValueChanged += Pin_ValueChanged;
            io09.ValueChanged += Pin_ValueChanged;
            io10.ValueChanged += Pin_ValueChanged;
            io11.ValueChanged += Pin_ValueChanged;
            io12.ValueChanged += Pin_ValueChanged;
            io13.ValueChanged += Pin_ValueChanged;
            io16.ValueChanged += Pin_ValueChanged;
            io17.ValueChanged += Pin_ValueChanged;
            io18.ValueChanged += Pin_ValueChanged;
            io19.ValueChanged += Pin_ValueChanged;
            io20.ValueChanged += Pin_ValueChanged;
            io21.ValueChanged += Pin_ValueChanged;
            io22.ValueChanged += Pin_ValueChanged;
            io23.ValueChanged += Pin_ValueChanged;
            io24.ValueChanged += Pin_ValueChanged;
            io25.ValueChanged += Pin_ValueChanged;
            io26.ValueChanged += Pin_ValueChanged;
            io27.ValueChanged += Pin_ValueChanged;

            pinDictionary.Add("02", io02);
            pinDictionary.Add("03", io03);
            pinDictionary.Add("04", io04);
            pinDictionary.Add("05", io05);
            pinDictionary.Add("06", io06);
            pinDictionary.Add("07", io07);
            pinDictionary.Add("08", io08);
            pinDictionary.Add("09", io09);
            pinDictionary.Add("10", io10);
            pinDictionary.Add("11", io11);
            pinDictionary.Add("12", io12);
            pinDictionary.Add("13", io13);
            pinDictionary.Add("16", io16);
            pinDictionary.Add("17", io17);
            pinDictionary.Add("18", io18);
            pinDictionary.Add("19", io19);
            pinDictionary.Add("20", io20);
            pinDictionary.Add("21", io21);
            pinDictionary.Add("22", io22);
            pinDictionary.Add("23", io23);
            pinDictionary.Add("24", io24);
            pinDictionary.Add("25", io25);
            pinDictionary.Add("26", io26);
            pinDictionary.Add("27", io27);

            tsDictionary.Add(IO02_toggle, IO02_status);
            tsDictionary.Add(IO03_toggle, IO03_status);
            tsDictionary.Add(IO04_toggle, IO04_status);
            tsDictionary.Add(IO05_toggle, IO05_status);
            tsDictionary.Add(IO06_toggle, IO06_status);
            tsDictionary.Add(IO07_toggle, IO07_status);
            tsDictionary.Add(IO08_toggle, IO08_status);
            tsDictionary.Add(IO09_toggle, IO09_status);
            tsDictionary.Add(IO10_toggle, IO10_status);
            tsDictionary.Add(IO11_toggle, IO11_status);
            tsDictionary.Add(IO12_toggle, IO12_status);
            tsDictionary.Add(IO13_toggle, IO13_status);
            tsDictionary.Add(IO16_toggle, IO16_status);
            tsDictionary.Add(IO17_toggle, IO17_status);
            tsDictionary.Add(IO18_toggle, IO18_status);
            tsDictionary.Add(IO19_toggle, IO19_status);
            tsDictionary.Add(IO20_toggle, IO20_status);
            tsDictionary.Add(IO21_toggle, IO21_status);
            tsDictionary.Add(IO22_toggle, IO22_status);
            tsDictionary.Add(IO23_toggle, IO23_status);
            tsDictionary.Add(IO24_toggle, IO24_status);
            tsDictionary.Add(IO25_toggle, IO25_status);
            tsDictionary.Add(IO26_toggle, IO26_status);
            tsDictionary.Add(IO27_toggle, IO27_status);

            statusDictionary.Add(02, IO02_status);
            statusDictionary.Add(03, IO03_status);
            statusDictionary.Add(04, IO04_status);
            statusDictionary.Add(05, IO05_status);
            statusDictionary.Add(06, IO06_status);
            statusDictionary.Add(07, IO07_status);
            statusDictionary.Add(08, IO08_status);
            statusDictionary.Add(09, IO09_status);
            statusDictionary.Add(10, IO10_status);
            statusDictionary.Add(11, IO11_status);
            statusDictionary.Add(12, IO12_status);
            statusDictionary.Add(13, IO13_status);
            statusDictionary.Add(16, IO16_status);
            statusDictionary.Add(17, IO17_status);
            statusDictionary.Add(18, IO18_status);
            statusDictionary.Add(19, IO19_status);
            statusDictionary.Add(20, IO20_status);
            statusDictionary.Add(21, IO21_status);
            statusDictionary.Add(22, IO22_status);
            statusDictionary.Add(23, IO23_status);
            statusDictionary.Add(24, IO24_status);
            statusDictionary.Add(25, IO25_status);
            statusDictionary.Add(26, IO26_status);
            statusDictionary.Add(27, IO27_status);
        }

        private void Pin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            // need to invoke UI updates on the UI thread because this event
            // handler gets invoked on a separate thread.
            var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var PinTextName = GetPinTextName(sender.PinNumber);
                
                if (e.Edge == GpioPinEdge.FallingEdge)
                {
                    statusDictionary[sender.PinNumber].IsOn = false;
                }
                else
                {
                    statusDictionary[sender.PinNumber].IsOn = true;
                }
            });
        }

        private string GetPinTextName(int pinNumber)
        {
            return $"Gpio {pinNumber:D2}";
        }

        private void IO_Direction_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch ts = (ToggleSwitch)sender;
            String pinNumber = ts.Name.Substring(2, 2);
            var pin = pinDictionary[pinNumber];
            if (ts.IsOn)
            {
                pin.SetDriveMode(GpioPinDriveMode.Output);
                pin.Write(GpioPinValue.Low);

                tsDictionary[ts].IsEnabled = true;
            }
            else
            {
                pin.Write(GpioPinValue.Low);
                pin.SetDriveMode(GpioPinDriveMode.InputPullDown);

                tsDictionary[ts].IsOn = false;
                tsDictionary[ts].IsEnabled = false;
            }
        }

        private void IO_Status_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch ts = (ToggleSwitch)sender;
            String pinNumber = ts.Name.Substring(2, 2);
            var pin = pinDictionary[pinNumber];

            if (ts.IsOn)
            {
                pin.Write(GpioPinValue.High);
            }
            else
            {
                pin.Write(GpioPinValue.Low);
            }
        }

        private void AllInput_click(object sender, RoutedEventArgs e)
        {
            AllHigh.IsEnabled = false;
            AllLow.IsEnabled = false;

            io02.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io03.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io04.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io05.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io06.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io07.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io08.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io09.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io10.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io11.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io12.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io13.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io16.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io17.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io18.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io19.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io20.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io21.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io22.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io23.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io24.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io25.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io26.SetDriveMode(GpioPinDriveMode.InputPullDown);
            io27.SetDriveMode(GpioPinDriveMode.InputPullDown);

            IO02_toggle.IsOn = false;
            IO03_toggle.IsOn = false;
            IO04_toggle.IsOn = false;
            IO05_toggle.IsOn = false;
            IO06_toggle.IsOn = false;
            IO07_toggle.IsOn = false;
            IO08_toggle.IsOn = false;
            IO09_toggle.IsOn = false;
            IO10_toggle.IsOn = false;
            IO11_toggle.IsOn = false;
            IO12_toggle.IsOn = false;
            IO13_toggle.IsOn = false;
            IO16_toggle.IsOn = false;
            IO17_toggle.IsOn = false;
            IO18_toggle.IsOn = false;
            IO19_toggle.IsOn = false;
            IO20_toggle.IsOn = false;
            IO21_toggle.IsOn = false;
            IO22_toggle.IsOn = false;
            IO23_toggle.IsOn = false;
            IO24_toggle.IsOn = false;
            IO25_toggle.IsOn = false;
            IO26_toggle.IsOn = false;
            IO27_toggle.IsOn = false;
        }

        private void AllOutput_click(object sender, RoutedEventArgs e)
        {
            AllHigh.IsEnabled = true;
            AllLow.IsEnabled = true;
            io02.SetDriveMode(GpioPinDriveMode.Output);
            io03.SetDriveMode(GpioPinDriveMode.Output);
            io04.SetDriveMode(GpioPinDriveMode.Output);
            io05.SetDriveMode(GpioPinDriveMode.Output);
            io06.SetDriveMode(GpioPinDriveMode.Output);
            io07.SetDriveMode(GpioPinDriveMode.Output);
            io08.SetDriveMode(GpioPinDriveMode.Output);
            io09.SetDriveMode(GpioPinDriveMode.Output);
            io10.SetDriveMode(GpioPinDriveMode.Output);
            io11.SetDriveMode(GpioPinDriveMode.Output);
            io12.SetDriveMode(GpioPinDriveMode.Output);
            io13.SetDriveMode(GpioPinDriveMode.Output);
            io16.SetDriveMode(GpioPinDriveMode.Output);
            io17.SetDriveMode(GpioPinDriveMode.Output);
            io18.SetDriveMode(GpioPinDriveMode.Output);
            io19.SetDriveMode(GpioPinDriveMode.Output);
            io20.SetDriveMode(GpioPinDriveMode.Output);
            io21.SetDriveMode(GpioPinDriveMode.Output);
            io22.SetDriveMode(GpioPinDriveMode.Output);
            io23.SetDriveMode(GpioPinDriveMode.Output);
            io24.SetDriveMode(GpioPinDriveMode.Output);
            io25.SetDriveMode(GpioPinDriveMode.Output);
            io26.SetDriveMode(GpioPinDriveMode.Output);
            io27.SetDriveMode(GpioPinDriveMode.Output);
            io02.Write(GpioPinValue.Low);
            io03.Write(GpioPinValue.Low);
            io04.Write(GpioPinValue.Low);
            io05.Write(GpioPinValue.Low);
            io06.Write(GpioPinValue.Low);
            io07.Write(GpioPinValue.Low);
            io08.Write(GpioPinValue.Low);
            io09.Write(GpioPinValue.Low);
            io10.Write(GpioPinValue.Low);
            io11.Write(GpioPinValue.Low);
            io12.Write(GpioPinValue.Low);
            io13.Write(GpioPinValue.Low);
            io16.Write(GpioPinValue.Low);
            io17.Write(GpioPinValue.Low);
            io18.Write(GpioPinValue.Low);
            io19.Write(GpioPinValue.Low);
            io20.Write(GpioPinValue.Low);
            io21.Write(GpioPinValue.Low);
            io22.Write(GpioPinValue.Low);
            io23.Write(GpioPinValue.Low);
            io24.Write(GpioPinValue.Low);
            io25.Write(GpioPinValue.Low);
            io26.Write(GpioPinValue.Low);
            io27.Write(GpioPinValue.Low);
            
            IO02_toggle.IsOn = true;
            IO03_toggle.IsOn = true;
            IO04_toggle.IsOn = true;
            IO05_toggle.IsOn = true;
            IO06_toggle.IsOn = true;
            IO07_toggle.IsOn = true;
            IO08_toggle.IsOn = true;
            IO09_toggle.IsOn = true;
            IO10_toggle.IsOn = true;
            IO11_toggle.IsOn = true;
            IO12_toggle.IsOn = true;
            IO13_toggle.IsOn = true;
            IO16_toggle.IsOn = true;
            IO17_toggle.IsOn = true;
            IO18_toggle.IsOn = true;
            IO19_toggle.IsOn = true;
            IO20_toggle.IsOn = true;
            IO21_toggle.IsOn = true;
            IO22_toggle.IsOn = true;
            IO23_toggle.IsOn = true;
            IO24_toggle.IsOn = true;
            IO25_toggle.IsOn = true;
            IO26_toggle.IsOn = true;
            IO27_toggle.IsOn = true;
        }

        private void AllHigh_click(object sender, RoutedEventArgs e)
        {
            io02.Write(GpioPinValue.High);
            io03.Write(GpioPinValue.High);
            io04.Write(GpioPinValue.High);
            io05.Write(GpioPinValue.High);
            io06.Write(GpioPinValue.High);
            io07.Write(GpioPinValue.High);
            io08.Write(GpioPinValue.High);
            io09.Write(GpioPinValue.High);
            io10.Write(GpioPinValue.High);
            io11.Write(GpioPinValue.High);
            io12.Write(GpioPinValue.High);
            io13.Write(GpioPinValue.High);
            io16.Write(GpioPinValue.High);
            io17.Write(GpioPinValue.High);
            io18.Write(GpioPinValue.High);
            io19.Write(GpioPinValue.High);
            io20.Write(GpioPinValue.High);
            io21.Write(GpioPinValue.High);
            io22.Write(GpioPinValue.High);
            io23.Write(GpioPinValue.High);
            io24.Write(GpioPinValue.High);
            io25.Write(GpioPinValue.High);
            io26.Write(GpioPinValue.High);
            io27.Write(GpioPinValue.High);
        }

        private void AllLow_click(object sender, RoutedEventArgs e)
        {
            io02.Write(GpioPinValue.Low);
            io03.Write(GpioPinValue.Low);
            io04.Write(GpioPinValue.Low);
            io05.Write(GpioPinValue.Low);
            io06.Write(GpioPinValue.Low);
            io07.Write(GpioPinValue.Low);
            io08.Write(GpioPinValue.Low);
            io09.Write(GpioPinValue.Low);
            io10.Write(GpioPinValue.Low);
            io11.Write(GpioPinValue.Low);
            io12.Write(GpioPinValue.Low);
            io13.Write(GpioPinValue.Low);
            io16.Write(GpioPinValue.Low);
            io17.Write(GpioPinValue.Low);
            io18.Write(GpioPinValue.Low);
            io19.Write(GpioPinValue.Low);
            io20.Write(GpioPinValue.Low);
            io21.Write(GpioPinValue.Low);
            io22.Write(GpioPinValue.Low);
            io23.Write(GpioPinValue.Low);
            io24.Write(GpioPinValue.Low);
            io25.Write(GpioPinValue.Low);
            io26.Write(GpioPinValue.Low);
            io27.Write(GpioPinValue.Low);
        }
    }
}
