using System.Net.NetworkInformation;
using System.Threading;


namespace CodeFile2
{
    public class Class2
    {
        public void Method2()
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send("www.google.com");
            Console.WriteLine(reply.Status);
        }
    }
}