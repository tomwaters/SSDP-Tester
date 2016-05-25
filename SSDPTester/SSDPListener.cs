using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SSDPTester
{
    public class UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
    }

    public delegate void MessageReceiverDelegate(DateTime dtReceived, string from, string to, string message);
    class SSDPListener
    {
        private static bool running;
        private static string multicastIP;
        private static int multicastPort;
        private static int unicastPort;
        private static UdpClient udpMulticastClient;
        private static UdpClient udpUnicastClient;
        private static MessageReceiverDelegate msgReceiver;
 
        public SSDPListener()
        {
            multicastIP = "239.255.255.250";
            multicastPort = 1900;
            unicastPort = 57377;
            running = false;
        }

        public static void MulticastReceiveCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
                IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;

                if (u.Client != null)
                {
                    Byte[] receiveBytes = u.EndReceive(ar, ref e);
                    string receiveString = Encoding.ASCII.GetString(receiveBytes);
                    
                    string from = e.ToString();
                    string to = ((UdpState)(ar.AsyncState)).e.ToString();
                    msgReceiver(DateTime.Now, from, to, receiveString);
                }
                if (running)
                    MulticastSetBeginReceive();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void MulticastSetBeginReceive()
        {
            IPAddress ipSSDP = IPAddress.Parse(multicastIP);
            IPEndPoint ipRXEnd = new IPEndPoint(ipSSDP, multicastPort);
            UdpState udpListener = new UdpState();
            udpListener.e = ipRXEnd;

            if (udpMulticastClient == null)
                udpMulticastClient = new UdpClient(multicastPort);
            udpListener.u = udpMulticastClient;
            udpMulticastClient.BeginReceive(new AsyncCallback(MulticastReceiveCallback), udpListener);
        }

        public static void UnicastReceiveCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
                IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;

                if (u.Client != null)
                {
                    Byte[] receiveBytes = u.EndReceive(ar, ref e);
                    string receiveString = Encoding.ASCII.GetString(receiveBytes);

                    string from = e.ToString();
                    string to = ((UdpState)(ar.AsyncState)).e.ToString();
                    msgReceiver(DateTime.Now, from, to, receiveString);
                }
                if (running)
                    UnicastSetBeginReceive();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UnicastSetBeginReceive()
        {
            IPEndPoint ipRXEnd = new IPEndPoint(IPAddress.Any, unicastPort);
            UdpState udpListener = new UdpState();
            udpListener.e = ipRXEnd;

            if (udpUnicastClient == null)
                udpUnicastClient = new UdpClient(unicastPort);
            
            udpListener.u = udpUnicastClient;
            udpUnicastClient.BeginReceive(new AsyncCallback(UnicastReceiveCallback), udpListener);
        }

        public void Send(string message)
        {
            try
            {
                if (udpUnicastClient == null)
                    udpUnicastClient = new UdpClient(unicastPort);

                byte[] req = Encoding.ASCII.GetBytes(message);
                IPAddress ipSSDP = IPAddress.Parse(multicastIP);
                IPEndPoint ipTXEnd = new IPEndPoint(ipSSDP, multicastPort);
                udpUnicastClient.Send(req, req.Length, ipTXEnd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Start(MessageReceiverDelegate receiver)
        {
            try
            {
                msgReceiver = receiver;

                udpUnicastClient = new UdpClient();
                
                udpMulticastClient = new UdpClient();

                // Tries to enable a multi-client connection
                // Note that any subclient must be initialized with those same parameters (options)
                // in order to not get an exception.
                try
                {
                    udpUnicastClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    udpMulticastClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                }
                catch (Exception)
                {
                    // Throw? Ignore? 
                }

                udpUnicastClient.Client.Bind(new IPEndPoint(IPAddress.Any, unicastPort));
                udpMulticastClient.Client.Bind(new IPEndPoint(IPAddress.Any, multicastPort));

                IPAddress ipSSDP = IPAddress.Parse(multicastIP);
                udpMulticastClient.JoinMulticastGroup(ipSSDP);

                running = true;
                UnicastSetBeginReceive();
                MulticastSetBeginReceive();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public void Stop()
        {
            running = false;
            udpMulticastClient.Close();
            udpUnicastClient.Close();
        }

        public bool IsRunning()
        {
            return running;
        }
    }
}
