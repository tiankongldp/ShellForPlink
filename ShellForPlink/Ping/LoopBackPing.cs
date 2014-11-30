using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ShellForPlink
{
    public enum SocketObjType
    {
        Client,
        Server
    }
    public class StateObject
    {
        public SocketObjType Type;
        public Socket workSocket = null;
        public const int BufferSize = 256;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    public delegate void DoAcceptLoopHandler(Socket listen);
    public delegate void SocketErrAccHandler(string errdes);
    public delegate void LoopBackDataRevHandler(string data);
    public delegate void DoConnectHandler(Socket handle);
    public delegate void PingFaildThreeHandler();

    public class LoopBackPing
    {
        public PlinkConfig plinkConfig;
        private System.Timers.Timer PingWaitTimer;
        private System.Timers.Timer PingDelayTimer;
        private bool HasReceived = false;
        private int PingFailedTimes = 0;

        //Client
        private String PingData = String.Empty;
        private IAsyncResult arConnect;
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        public event PingFaildThreeHandler PingFaildThree;
        //Server
        private Socket Listener;
        private bool bDoAcceptLoop = false;
        private IAsyncResult arDoAcceptLoop;
        public ManualResetEvent allDone = new ManualResetEvent(false);
        public event SocketErrAccHandler SocketErrAccur;

        
        public LoopBackPing()
        {
            PingWaitTimer = new System.Timers.Timer();
            PingWaitTimer.Interval = 16 * 1000;
            PingWaitTimer.Enabled = false;
            PingWaitTimer.Elapsed += new System.Timers.ElapsedEventHandler(PingWaitTimer_Elapsed);
            PingDelayTimer = new System.Timers.Timer();
            PingDelayTimer.Interval = 30 * 1000;
            PingDelayTimer.Enabled = false;
            PingDelayTimer.Elapsed += new System.Timers.ElapsedEventHandler(PingDelayTimer_Elapsed);
        }
        
        public void Start()
        {
            PingData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sssssss");
            StartServer();
            this.PingDelayTimer.Enabled = true;
        }
        public void Stop()
        {
            if (this.Listener != null)
            {
                this.PingDelayTimer.Enabled = false;
                this.PingWaitTimer.Enabled = false;
                StopServer();
                StopClient();
            }
        }

        private void PingDelayTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            StartClient();
        }
        private void PingWaitTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PingWaitTimer.Enabled = false;
            PingData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sssssss");

            try
            {
                this.StopClient();
            }
            catch (Exception err)
            {
                if (SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("PingWaitTimer_Elapsed Err" + err.Message, null, this);
            }

            if (HasReceived)
            {
                HasReceived = false;
                PingFailedTimes = 0;
                if (SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("PingTest success", null, this);
            }
            else
            {
                PingFailedTimes++;
                if (SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("PingTest failed " + PingFailedTimes + " times", null, this);

                if (PingFailedTimes >= 3)
                {
                    PingFailedTimes = 0;
                    if (PingFaildThree != null)
                        PingFaildThree.BeginInvoke(null, this);
                }
            }
        }


        private void StartClient()
        {
            try
            {
                PingWaitTimer.Enabled = true;
                Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                if (SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("StartClient", null, this);

                DoConnectHandler conn = new DoConnectHandler(ConnectSync);
                arConnect = conn.BeginInvoke(Client, null, Client);
            }
            catch (Exception e)
            {
                if (SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("StartClient Err:" + e.Message, null, this);
            }
        }
        private void StopClient()
        {
            if (arConnect != null)
            {
                Socket client = (Socket)arConnect.AsyncState;
                if (client.Connected)
                {
                    client.Shutdown(SocketShutdown.Send);
                    client.Close();
                }
                arConnect.AsyncWaitHandle.WaitOne();
            }
            arConnect = null;
        }
        private void ConnectSync(Socket handle)
        {
            try
            {
                handle.Connect(IPAddress.Parse("127.0.0.1"),
                    plinkConfig.LoopBackPingPort);

                byte[] byteData = Encoding.ASCII.GetBytes(PingData + "<EOF>");
                handle.SendTimeout = 10 * 1000;
                handle.Send(byteData, 0, byteData.Length, 0);
                
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("Sending Ping Data:" + PingData, null, this);
                //关闭后收不到数据
                //handle.Shutdown(SocketShutdown.Send);
            }
            catch (Exception e)
            {
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("ConnectSync Err:" + e.Message, null, this);
            }
        }
        private void ConnectASync()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"),
                    plinkConfig.LoopBackPingPort);
            Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), Client);

            connectDone.WaitOne();

            // Send test data to the remote device.
            Send(Client, "This is a test<EOF>");
            sendDone.WaitOne();

            Client.Shutdown(SocketShutdown.Both);
            Client.Close();
        }
        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                // Signal that the connection has been made.
                connectDone.Set();
                Send(client, PingData);
            }
            catch (Exception e)
            {
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("ConnectCallback Err:" + e.Message, null, this);
            }
        }
        private void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), handler);
        }
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("SendCallback Err:" + e.Message, null, this);
            }
        }
        
        private void StartServer()
        {
            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), plinkConfig.LoopBackPingPort + 1));
            Listener.Listen(10);
            
            DoAcceptLoopHandler doloop = new DoAcceptLoopHandler(DoAcceptLoop);
            bDoAcceptLoop = true;
            arDoAcceptLoop = doloop.BeginInvoke(Listener, new AsyncCallback(AcceptLoopStopCallBack), Listener);
        }
        private void StopServer()
        {
            if (bDoAcceptLoop && !arDoAcceptLoop.IsCompleted)
            {
                bDoAcceptLoop = false;
                allDone.Set();
                arDoAcceptLoop.AsyncWaitHandle.WaitOne();

                //Listener.Shutdown(SocketShutdown.Both);
                
                Listener.Close();
            }
            arDoAcceptLoop = null;
            Listener = null;
        }
        private void AcceptLoopStopCallBack(IAsyncResult ar)
        {
            //if (this.SocketErrAccur != null)
            //    SocketErrAccur.BeginInvoke("AcceptLoopStopCallBack", null, this);
        }
        private void DoAcceptLoop(Socket listen)
        {
            if (this.SocketErrAccur != null)
                SocketErrAccur.BeginInvoke("DoAcceptLoop", null, this);

            while (this.bDoAcceptLoop)
            {
                try
                {
                    allDone.Reset();

                    Listener.BeginAccept(new AsyncCallback(AcceptCallback), listen);

                    allDone.WaitOne();
                }
                catch (Exception e)
                {
                    if (this.SocketErrAccur != null)
                        SocketErrAccur.BeginInvoke("DoAcceptLoop Err:" + e.Message, null, this);
                }
            }
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listen = (Socket)ar.AsyncState;

                Socket handler = listen.EndAccept(ar);

                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("AcceptCallback：" + handler.RemoteEndPoint.ToString(), null, this);

                Receive(handler);
            }
            catch (Exception e)
            {
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("AcceptCallback Err：" + e.Message, null, this);
            }
        }
        private void Receive(Socket handler)
        {
            try
            {
                StateObject state = new StateObject();
                state.workSocket = handler;
                state.Type = SocketObjType.Server;

                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("Begin Receive", null, this);

                handler.ReceiveTimeout = 13 * 1000;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("Receive Err:" + e.Message, null, this);
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    content = state.sb.ToString();
                    if (content == this.PingData + "<EOF>")
                    {
                        HasReceived = true;
                        if (this.SocketErrAccur != null)
                            SocketErrAccur.BeginInvoke("ReceiveCallback data:" + content, null, this);
                    }
                    handler.Shutdown(SocketShutdown.Receive);
                    handler.Close();

                    //if (content.IndexOf("<EOF>") > -1)
                    //else
                    //{
                    //    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    //    new AsyncCallback(ReceiveCallback), state);
                    //}
                }
                else
                    if (this.SocketErrAccur != null)
                        SocketErrAccur.BeginInvoke("ReceiveCallback No Data Received", null, this);
            }
            catch (Exception e)
            {
                if (this.SocketErrAccur != null)
                    SocketErrAccur.BeginInvoke("ReceiveCallback Err:" + e.Message, null, this);
            }
        }
    }
}
