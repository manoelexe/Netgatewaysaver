# Netgatewaysaver  

# Analisador de Redes Versão BETA
 
![Captura de tela 2025-03-31 113229](https://github.com/user-attachments/assets/92a02f26-8a5b-499c-a04b-df70d5eed0d8)




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
 É  uma função privada e assíncrona. Ultilizando o awaitcom o metodo scannetworkAsync() da bliblioteca NativeWifi do Windows ,em um intervalo (TimeSpan()) de 10 segundos, ela escaneia as redes proximas ao usuário  e tem como response as
 informações da interface de ada rede como o SSid, ,frequencia de sinal,Largura de Banda ,channel Etc. enquanto a variável  network, instância  NativeWifi.EnumerateBSsnetworks, criando um conjunto para armazenas temporariamente os dados da rede rescebidos logo é criada uma nova instancia da classe "AvailableNEtworksPacks " e é inteirada através  de um laço de repetição (foreach) com as redes e seus respectivos dados escaneados.


LoadSpeedTest() ,GetNetworkStatistics():

São duas funções complementares a Função GetNetworkStatistics() è uma função estática  que cria uma instância em formato de Array  da classe NetworkInterface sobre o Namespace NetworkInfo , ultilizando o metododo GetnetrokInterfaces() que tem como Resposta os Dados do Adptador de rede, logo em seguida aatravés de uma estrutura de repetição os dados são interados sobre o metodo de status operacionais (operationalstatus) para calcular as taxas de tranferencia e Ping que passam pela comutação da rede e seu trafego. o Numero de bytes Enviados e rescebidos São armazernados nas Variáveis  Bytessent E bytesReceived.logo Após  tudo isso a Função LoadSpeedTest Trás  uma nova Intancia da classe SpeedTest e por fim armazena os dados rescebidos da função GetNetworkStatistics() e gera os Dados Para estatísticas 



