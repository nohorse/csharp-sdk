﻿using System;
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
using relayr_csharp_sdk;
using System.Net.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            testClient();
        }

        public async void testClient()
        {
            Relayr.OauthToken = "bD6fe1FoaXtvkg2E6MjRrNC6WLoyYeFQ";

            List<dynamic> transmitters = await Relayr.GetTransmittersAsync();
            
            Transmitter transmitter = Relayr.ConnectToBroker(transmitters[transmitters.Count - 1], "waka");

            List<dynamic> devices = await transmitter.GetDevicesAsync();
            Device device = await transmitter.SubscribeToDeviceDataAsync(devices[0]);
            device.PublishedDataReceived += device_PublishedDataReceived;
        }

        // Handler for the the sensor's data published event
        void device_PublishedDataReceived(object sender, PublishedDataReceivedEventArgs args)
        {
            // New sensor data is contained inside the args class
        }
    }
}
