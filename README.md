# Netgatewaysaver  

#Analisador de Redes Versão BETA
 
![Captura de tela 2025-03-26 111724](https://github.com/user-attachments/assets/a9820b99-d724-4f6a-9486-901aee290878)

#ideia do projeto

 trazer interface das redes proximas ao usuário  além  de sua Propria rede para então poder criar estatisticas e realizar possiveis manutenções através  de um diagnostico


 #tecnologias usadas 

 Framework .NET Core 8.0 
 linguagem :C#

 #liBS

NetworkinterfaceInfo;
ManagedNativeWifi;
Live Charts;
 # classes 

 Avalailable Network Packs: Classe que armazena os dados recebidos da Função loadNetworkDataAsync() e os renderiza no XAMl nos objetos Ssid 
            public required string Description { get; set; }
            public required string BSS { get; set; }
            public required string BSSID { get; set; }
            public required string Signalstrength { get; set; }
            public required string Linkquality { get; set; }
            public required string Frequency { get; set; }
            public required string Largurabanda { get; set; }
            public required string Channel { get; set; }
 SpeedTest;
   calsse que 
