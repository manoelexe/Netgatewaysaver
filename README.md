# Netgatewaysaver  

# Analisador de Redes Versão BETA
 
![Captura de tela 2025-03-26 123844](https://github.com/user-attachments/assets/84ec08f3-bcfe-45f9-9894-5aa549bcb3ed)


# ideia do projeto

 trazer interface das redes proximas ao usuário  além  de sua Propria rede para então poder criar estatisticas e realizar possiveis manutenções através  de um diagnostico


 # Tecnologias usadas 

 Framework .NET Core 8.0 
 linguagem :C#

 # libs

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
   calsse que armazena os dados de Estatísticas  e metricas da rede como Tranferencia de Dados por exemplo extraidos da Função Load SpeedTest() e os Armazena para visualização Grafica  
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

# Funções

 LoadNEtworkDataAsync():
 é uma função privada e assíncrona.Ultilizando o awaitcom o metodo scannetworkAsync() da bliblioteca NativeWifi do Windows ,em um intervalo (TimeSpan()) de 10 segundos, ela escaneia as redes proximas ao usuário  e tem como response as
 informações da interface de ada rede como o SSid, ,frequencia de sinal,Largura de Banda ,channel Etc. enquanto a variável  network, instância  NativeWifi.EnumerateBSsnetworks, criando um conjunto para armazenas temporariamente os dados da rede rescebidos logo é criada uma nova instancia da classe "AvailableNEtworksPacks " e é inteirada através  de um laço de repetição (foreach) com as redes e seus respectivos dados escaneados.



