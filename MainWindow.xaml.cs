using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows;

namespace Netgatewaysaver
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadNetworkInterfaces();
        }


        public class NetworkInterfaceInfo
        {
            public required string Name { get; set; }
            public string OperationalStatus { get; set; }
            public string Description { get; set; }
            public long Speed { get; set; }
            public string MAC { get; set; }
            public bool IsReceiveOnly { get; set; }
            public string Channel { get; set; }
        }


        private void LoadNetworkInterfaces()
        {
            List<NetworkInterfaceInfo> networkInterfaces = new List<NetworkInterfaceInfo>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                networkInterfaces.Add(new NetworkInterfaceInfo
                {
                    Name = ni.Name,
                    OperationalStatus = ni.OperationalStatus.ToString(),
                    Description = ni.Description,
                    Speed = ni.Speed,
                    MAC = ni.GetPhysicalAddress().ToString(),
                    IsReceiveOnly = ni.IsReceiveOnly,
                    Channel = GetChannel(ni)
                });
            }

            this.DataContext = networkInterfaces;
        }

        private static string GetChannel(NetworkInterface ni)
        {
            return "Channel Info";
        }
    }

    
}

  