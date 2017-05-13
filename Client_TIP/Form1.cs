using System;
using System.ComponentModel;
using NAudio.Wave;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;

namespace Client_TIP
{
    public partial class Form1 : Form
    {
        private int inputDeviceNumber;
        private InetworkChatCodec selectedCodec = new Codec();
        private volatile bool connected;
        bool connectionAvailibe = false;
        bool logged;
        bool isconnected = false;
        public static TcpClient tcpclnt;
        TcpClient inviteSender;
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 8001);
        TcpListener listenForCalls;
        private string serverIp = "";
        private WaveInEvent waveIn;
        private IWavePlayer waveOut;
        private BufferedWaveProvider waveProvider;
        private UdpClient udpSender;
        private UdpClient udpListener;
        public delegate void MakepanelVisibleDelegate();
        public delegate void MakeloginlabelvisibleDelegate();
        private IPEndPoint hisendPoint;
        private IPEndPoint hisendPoint2;
        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        XElement friends;

        public Form1()
        {
            InitializeComponent();
            loginPanel.Hide();
            mainPanel.Hide();
            PopulateInputDevicesCombo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Hide();
            Client_Load();
            labelValidation.Hide();
            panel1.Hide();
        }

        //Przycisk od akceptacji adresu IP
        private void acceptServIPBtn_Click(object sender, EventArgs e)
        {
            string[] splitValues = ServerIPTextBox.Text.Split('.');
            int dlugosc = splitValues.Length;
            if (splitValues.Length == 4)
            {
                serverIp = ServerIPTextBox.Text;
                loginPanel.Show();
            }
            else
            {
                MessageBox.Show("Niepoprawny adres IP!");
                ServerIPTextBox.Clear();
            }
        }

        //Label od rejestracji
        private void registerLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        //Przycisk zaloguj
        private void loginBtn_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            try
            {
                StringBuilder messagebuilder = new StringBuilder();
                if (userNameTextBox.Text != "" && passwordTextBox.Text != "")
                {
                    BinaryWriter writer = new BinaryWriter(tcpclnt.GetStream());
                    messagebuilder.Append("login@");
                    messagebuilder.Append(userNameTextBox.Text);
                    messagebuilder.Append("@");
                    messagebuilder.Append(getMD5(passwordTextBox.Text));
                    writer.Write(messagebuilder.ToString());
                    logged = true;
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "Błędny login lub hasło";
                }
            }

            catch (Exception se)
            {
                MessageBox.Show("Błąd logowania " + se.StackTrace);
            }
            if(logged)
            {
                mainPanel.Show();
            }
        }
        public static string getMD5(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.UTF8.GetBytes(password));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }

            return str.ToString();
        }
        //++++
        public static bool isClientConnected(TcpClient client)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation c in tcpConnections)
            {
                TcpState stateOfConnection = c.State;

                if (c.LocalEndPoint.Equals(client.Client.LocalEndPoint) && c.RemoteEndPoint.Equals(client.Client.RemoteEndPoint))
                {
                    if (stateOfConnection == TcpState.Established)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }

            return false;

        }
        //++++Background Worker
        private void waitforconnection_DoWork(object sender, DoWorkEventArgs e)
        {
            tcpclnt = new TcpClient();
            while (!isClientConnected(tcpclnt))
            {
                try
                {
                    if (serverIp != "")
                    {
                        tcpclnt.Connect(ServerIPTextBox.Text, 8001); // use the ipaddress as in the server program
                        isconnected = true;
                        Console.Write("Connected to:");
                    }
                    if (isconnected) waitformessage.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error on waitforconnection: " + ex.Message);
                }

            }
        }
        //++++
        private async void Client_Load()
        {
            waitforconnection.RunWorkerAsync();
            waitForMessage2.RunWorkerAsync();
            //mainPanel.Show();
            logged = false;

            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    Console.WriteLine(ipAddress.ToString());
                    endPoint = new IPEndPoint(IPAddress.Parse(ipAddress.ToString()), 8001);
                }
            }
            if (File.Exists(path + @"\Friends.xml"))
            {
                friends = XElement.Load(path + @"\Friends.xml");
                if (friends == null) friends = new XElement("Friends");
                else
                {
                    foreach (var x in friends.Descendants("Friend"))
                    {
                        friendsList.Items.Add(x.Value);
                    }
                }
            }
            else
            {
                new XDocument(
                    new XElement("Friends")).Save("Friends.xml");
            }

        }

        public void Makeloginlabelvisible()
        {
            //this.label4.Visible = true;
        }
        public void Makepanel1Visible()
        {
            this.loginPanel.Hide();
            this.mainPanel.Show();
        }
        public void Makepanel2Visible()
        {
            
            //this.MainPanel.Show();

        }
        public void MakesearchlabelVisible()
        {
            this.labelValidation.Visible = true;

        }
        //++++
        private void waitformessage_DoWork(object sender, DoWorkEventArgs e)
        {

            while (isClientConnected(tcpclnt))
            {
                try
                {
                    BinaryReader reader = new BinaryReader(tcpclnt.GetStream());
                    string recieved = reader.ReadString();
                    string[] recievedmessage = recieved.Split('@');
                    if (recievedmessage[0] == "userdata")
                    {

                    }
                    else if (recievedmessage[0] == "wrong")
                    {
                        MessageBox.Show("Login unsuccessfull");
                        //MakeloginlabelvisibleDelegate mydelegate = new MakeloginlabelvisibleDelegate(this.Makeloginlabelvisible);
                        //this.BeginInvoke(mydelegate);
                        //recievedmessage = null;
                    }
                    else if (recievedmessage[0] == "success")
                    {
                        MessageBox.Show("Zalogowano!");
                        MakepanelVisibleDelegate mypaneldelegate = new MakepanelVisibleDelegate(this.Makepanel1Visible);
                        this.BeginInvoke(mypaneldelegate);
                        recievedmessage = null;

                    }
                    else if (recievedmessage[0] == "registersuccess")
                    {
                        MessageBox.Show("Register Successfull");
                        MakepanelVisibleDelegate mypaneldelegate = new MakepanelVisibleDelegate(this.Makepanel2Visible);
                        this.BeginInvoke(mypaneldelegate);
                        recievedmessage = null;

                    }
                    else if (recievedmessage[0] == "searchsuccess")
                    {
                        DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz dodać tą osobę do znajomych?", "Znaleziono znajomego", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            friends.Add(new XElement("Friend", friendNameTextBox.Text.ToString()));
                            friends.Save("Friends.xml");
                            friendsList.Invoke(new MethodInvoker(delegate ()
                            {
                                var last = friends.Descendants("Friend").Last();
                                friendsList.Items.Add(last.Value);
                            }));
                            recievedmessage = null;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            recievedmessage = null;
                        }

                    }

                    else if (recievedmessage[0] == "searchwrong")
                    {
                        MakepanelVisibleDelegate mypaneldelegate = new MakepanelVisibleDelegate(this.MakesearchlabelVisible);
                        this.BeginInvoke(mypaneldelegate);
                        recievedmessage = null;

                    }
                    else if (recievedmessage[0] == "useravailible")
                    {
                        if (!connected)
                        {
                            hisendPoint = new IPEndPoint(IPAddress.Parse(recievedmessage[1].ToString()), 8001);
                            hisendPoint2 = new IPEndPoint(IPAddress.Parse(recievedmessage[1].ToString()), 7001);

                            tryConnect();
                        }
                        recievedmessage = null;
                    }
                    else if (recievedmessage[0] == "noipfound")
                    {
                        MessageBox.Show("User unavailible");
                        recievedmessage = null;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error on background:" + ex.Message);

                }
            }
            if (!isClientConnected(tcpclnt))
            {
                Console.WriteLine("Server " + tcpclnt.Client.RemoteEndPoint.ToString() + " has disconnected");
                MessageBox.Show("You have been logged out from the server", "Log in");
                logged = false;
                tcpclnt.GetStream().Close();
                tcpclnt.Close();
            }
        }
        //++++
        private void waitformessage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!waitforconnection.IsBusy) waitforconnection.RunWorkerAsync();
        }
        //++++
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] encoded = selectedCodec.Encode(e.Buffer, 0, e.BytesRecorded);
            udpSender.Send(encoded, encoded.Length);
        }
        //++++
        private void Connect(IPEndPoint myendPoint, IPEndPoint hisendPoint, int inputDeviceNumber, InetworkChatCodec codec)
        {
            waveIn = new WaveInEvent();
            waveIn.BufferMilliseconds = 50;
            waveIn.DeviceNumber = inputDeviceNumber;
            waveIn.WaveFormat = codec.RecordFormat;
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();

            udpSender = new UdpClient();
            udpListener = new UdpClient();

            // To allow us to talk to ourselves for test purposes:
            // http://stackoverflow.com/questions/687868/sending-and-receiving-udp-packets-between-two-programs-on-the-same-computer
            udpListener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpListener.Client.Bind(myendPoint);

            udpSender.Connect(hisendPoint);

            waveOut = new WaveOut();
            waveProvider = new BufferedWaveProvider(codec.RecordFormat);
            waveOut.Init(waveProvider);
            waveOut.Play();

            connected = true;
            var state = new ListenerThreadState { Codec = codec, EndPoint = myendPoint };
            ThreadPool.QueueUserWorkItem(ListenerThread, state);
            MessageBox.Show("Conncected");

        }

        class ListenerThreadState
        {
            public IPEndPoint EndPoint { get; set; }
            public InetworkChatCodec Codec { get; set; }
        }
        //++++
        private void ListenerThread(object state)
        {
            var listenerThreadState = (ListenerThreadState)state;
            var endPoint = listenerThreadState.EndPoint;
            try
            {
                while (!connected)
                {
                    byte[] b = udpListener.Receive(ref endPoint);

                }
                while (connected)
                {
                    byte[] b = udpListener.Receive(ref endPoint);
                    byte[] decoded = listenerThreadState.Codec.Decode(b, 0, b.Length);

                    waveProvider.AddSamples(decoded, 0, decoded.Length);
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("Disconnected");
            }
        }
        //++++
        private void waitForMessage2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                listenForCalls = new TcpListener(IPAddress.Any, 7001);
                listenForCalls.Start();

                TcpClient accepted = listenForCalls.AcceptTcpClient();
                BinaryReader reader = new BinaryReader(accepted.GetStream());
                BinaryWriter write = new BinaryWriter(accepted.GetStream());
                string recieved = reader.ReadString();
                string[] recievedmessage = recieved.Split('@');
                if (recievedmessage[0] == "invite")
                {
                    DialogResult dialogResult = MessageBox.Show("Incoming call from" + recievedmessage[1].ToString(), "Call", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        write.Write("OK");

                        hisendPoint = new IPEndPoint(IPAddress.Parse(recievedmessage[2].ToString()), 8001);
                        if (hisendPoint != null)
                        {
                            Connect(endPoint, hisendPoint, inputDeviceNumber, selectedCodec);
                        }
                        recievedmessage = null;
                    }
                    else
                    {
                        write.Write("Decline");
                        recievedmessage = null;
                        accepted.Close();
                    }
                }
            }
        }
        //++++
        private void tryConnect()
        {
            inviteSender = new TcpClient();
            inviteSender.Connect(hisendPoint2);

            BinaryWriter writer = new BinaryWriter(inviteSender.GetStream());
            StringBuilder builder = new StringBuilder();
            builder.Append("invite@");
            builder.Append(userNameTextBox.Text);
            builder.Append("@");
            builder.Append(endPoint.Address.ToString());
            writer.Write(builder.ToString());

            BinaryReader readerOnRecieve = new BinaryReader(inviteSender.GetStream());
            string recieved2 = readerOnRecieve.ReadString();
            if (recieved2 == "Decline")
            {
                MessageBox.Show("User has declined your call", "Call declined");
            }
            if (recieved2 == "OK")
            {
                connectionAvailibe = true;
            }
        }
        //++++
        private void PopulateInputDevicesCombo()
        {
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                var capabilities = WaveIn.GetCapabilities(n);
                deviceComboBox.Items.Add(capabilities.ProductName);
            }
            if (deviceComboBox.Items.Count > 0)
            {
                deviceComboBox.SelectedIndex = 0;
            }
        }

        private void cancelFriendBtn_Click(object sender, EventArgs e)
        {

        }

        private void friendNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        //++++
        private void searchFriendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (logged)
                {
                    if (friendNameTextBox.Text != null)
                    {
                        labelValidation.Visible = false;
                        StringBuilder messagebuilder = new StringBuilder();
                        messagebuilder.Append("search@");
                        messagebuilder.Append(friendNameTextBox.Text);
                        BinaryWriter writer = new BinaryWriter(tcpclnt.GetStream());
                        writer.Write(messagebuilder.ToString());
                    }
                    else
                    {
                        labelValidation.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("You must log in first");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }

        private void findFriendBtn_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private async void callBtn_Click(object sender, EventArgs e)
        {
            StringBuilder messagebuilder = new StringBuilder();
            if (friendsList.SelectedItems.Count != 0)
            {
                inputDeviceNumber = deviceComboBox.SelectedIndex;
                BinaryWriter writer = new BinaryWriter(tcpclnt.GetStream());
                messagebuilder.Append("call@");
                messagebuilder.Append(friendsList.SelectedItems[0].Text.ToString());
                writer.Write(messagebuilder.ToString());
                while (!connectionAvailibe)
                {
                    await Task.Delay(25);
                }
                Connect(endPoint, hisendPoint, inputDeviceNumber, selectedCodec);
            }
            else MessageBox.Show("Wybierz osobę do ktorej chcesz zadzwonic");
        }
        //++++
        private void Disconnect()
        {
            if (connected)
            {
                connected = false;
                waveIn.DataAvailable -= waveIn_DataAvailable;
                waveIn.StopRecording();
                waveOut.Stop();

                udpSender.Close();
                udpListener.Close();
                waveIn.Dispose();
                waveOut.Dispose();

                selectedCodec.Dispose();
                MessageBox.Show("Disconnected");
            }
        }


        //++++
        private void finishBtn_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                Disconnect();
            }

            else
            {
                MessageBox.Show("Musisz byc zalogowany");
            }
        }

        private void deleteFriendBtn_Click(object sender, EventArgs e)
        {
            var rulesNode = friends.Element("Friends");
            XDocument xmlDoc = XDocument.Load(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Friends.xml");

            foreach (ListViewItem item in friendsList.Items)
            {
                XName name = item.Text;
                XElement toDelete = friends.Element(name);
                toDelete.Remove();
                if (item.Selected)
                { 
                    friendsList.Items.Remove(item);
                }
                //foreach (XElement xx in friends.Elements())
                //{
                //    if (xx.Element("Friends"))
                //}
                RemoveNode(item.Selected.ToString());
                var elementsToDelete = from ele in xmlDoc.Elements("Friends")
                                       where ele != null && ele.Attribute("Friend").Value.Equals(name)
                                       select ele;
                foreach(var element in elementsToDelete)
                {
                    element.Remove();
                }
            }
            
        }
        private static void RemoveNode(string friendName)
        {
            
        }
    }

}
