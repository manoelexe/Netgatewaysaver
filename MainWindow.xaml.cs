
using System;
using System.Linq;
using System.Windows;
using ManagedNativeWifi;
using System.Collections.Generic;

namespace Netgatewaysaver
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadNetworkData();
        }

        public class AvailableNetworkPack
        {
            public required string Ssid { get; set; }
            public required string Description { get; set; }
            public required string BSS { get; set; }
            public required string BSSID { get; set; }
            public required string Signalstrength { get; set; }
            public required string Linkquality { get; set; }
            public required string Frequency { get; set; }
            public required string Largurabanda { get; set; }
            public required string Channel { get; set; }



        }

        private void LoadNetworkData()
        {
            List<AvailableNetworkPack> networkPacks = new List<AvailableNetworkPack>();
            var networks = NativeWifi.EnumerateBssNetworks();
            foreach (var network in networks)
            {
                networkPacks.Add(new AvailableNetworkPack
                {
                    Ssid = network.Ssid.ToString(),
                    Description = $"{{adaptador de rede : {network.Interface.Description} ({network.Interface.Id})" + Environment.NewLine,
                   
                    BSS= $" BSS: {network.BssType}" + Environment.NewLine,
                    BSSID= $" BSSID: {network.Bssid}" + Environment.NewLine,
                    Signalstrength= $" SignalStrength: {network.SignalStrength}" + Environment.NewLine,
                    
                    Linkquality= $" LinkQuality: {network.LinkQuality}" + Environment.NewLine,
                    Frequency= $" Frequency: {network.Frequency} KHz" + Environment.NewLine,
                    Largurabanda = $" largura de Banda: {network.Band} GHz" + Environment.NewLine,
                    Channel= $" Channel: {network.Channel}" + Environment.NewLine,

                });
            }
            this.DataContext = networkPacks;
        }
    }
}