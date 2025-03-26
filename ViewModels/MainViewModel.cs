using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ManagedNativeWifi;
using System.Windows;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore;

namespace Netgatewaysaver.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            AvailableNetworks = new ObservableCollection<AvailableNetworkPack>();
            SpeedTests = new ObservableCollection<SpeedTest>();
            SsidList = new ObservableCollection<Ssidonly>();
            LoadNetworkDataAsync();
            LoadSpeedtest();
        }
        public ObservableCollection<Ssidonly> SsidList { get; set; }
        public ObservableCollection<AvailableNetworkPack> AvailableNetworks { get; set; }
        public ObservableCollection<SpeedTest> SpeedTests { get; set; }

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

        public class SpeedTest
        {
            public required string Download { get; set; }
            public required string Upload { get; set; }
            public required string Ping { get; set; }
            public required string Jitter { get; set; }
            public required string Server { get; set; }
            public required string Ip { get; set; }
            public required string Host { get; set; }
            public required string Location { get; set; }
        }
        public class Ssidonly
        {
            public required string Ssid { get; set; }
        }
        private async Task LoadNetworkDataAsync()
        {
            try
            {
                await NativeWifi.ScanNetworksAsync(timeout: TimeSpan.FromSeconds(10));
                var networks = NativeWifi.EnumerateBssNetworks();

                AvailableNetworks.Clear();
                foreach (var network in networks)
                {
                    AvailableNetworks.Add(new AvailableNetworkPack
                    {
                        Ssid = network.Ssid.ToString(),
                        Description = $"{{Adaptador de rede: {network.Interface.Description} ({network.Interface.Id})" + Environment.NewLine,
                        BSS = $"BSS: {network.BssType}" + Environment.NewLine,
                        BSSID = $"BSSID: {network.Bssid}" + Environment.NewLine,
                        Signalstrength = $"SignalStrength: {network.SignalStrength}" + Environment.NewLine,
                        Linkquality = $"LinkQuality: {network.LinkQuality}" + Environment.NewLine,
                        Frequency = $"Frequency: {network.Frequency} KHz" + Environment.NewLine,
                        Largurabanda = $"Largura de Banda: {network.Band} GHz" + Environment.NewLine,
                        Channel = $"Channel: {network.Channel}" + Environment.NewLine,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar redes: {ex.Message}");
            }
        }

        private void LoadSpeedtest()
        {
            List<SpeedTest> statistics = new List<SpeedTest>();
            var speeduv = GetNetworkStatistics();
            var ssid = NativeWifi.EnumerateAvailableNetworkSsids();

            SpeedTests.Clear();
            SpeedTests.Add(new SpeedTest
            {
                Download = $"Download: {speeduv.BytesReceived / 1024} KB" + Environment.NewLine,
                Upload = $"Upload: {speeduv.BytesSent / 1024} KB" + Environment.NewLine,
                Ping = $"Ping: {speeduv.BytesReceived / 1024} ms" + Environment.NewLine,
                Jitter = $"Jitter: {speeduv.BytesSent / 1024} ms" + Environment.NewLine,
                Server = $"Server: {speeduv.BytesReceived / 1024} ms" + Environment.NewLine,
                Ip = $"Ip: {speeduv.BytesSent / 1024} ms" + Environment.NewLine,
                Host = $"Host: {speeduv.BytesReceived / 1024} ms" + Environment.NewLine,
                Location = $"Location: {speeduv.BytesSent / 1024} ms" + Environment.NewLine,
            });

            if (ssid.Any())
            {
                SsidList.Add(new Ssidonly
                {
                    Ssid = ssid.First().ToString()
                });
            }
        }
        
        
     
        private static (long BytesReceived, long BytesSent) GetNetworkStatistics()
        {
            long totalBytesReceived = 0;
            long totalBytesSent = 0;

            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var netInterface in networkInterfaces)
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    IPv4InterfaceStatistics stats = netInterface.GetIPv4Statistics();
                    totalBytesReceived += stats.BytesReceived;
                    totalBytesSent += stats.BytesSent;
                }
            }

            return (totalBytesReceived, totalBytesSent);
        }

   

        private void PlotSpeed()
        {



            GaugeGenerator.BuildSolidGauge(
                new GaugeItem(
                    30,          // the gauge value
                    series =>    // the series style
                    {
                        series.MaxRadialColumnWidth = 50;
                        series.DataLabelsSize = 50;

                    }));
        }

    }
}

