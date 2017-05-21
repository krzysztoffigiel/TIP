using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;

namespace ServerVOIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static DataSet myDataSet;
        List<User> usersonline = new List<User>();
        public static string getUserIp(string name)
        {
            string ip = "";
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=KF\\SQLEXPRESS;Initial Catalog=TIP;Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Opened!");
                string com = "Select ID, Login, IP from Users";
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                myDataSet = new DataSet();
                adpt.Fill(myDataSet, "Users");
                DataTable myDataTable = myDataSet.Tables[0];
                DataRow tempRow = null;
                foreach (DataRow tempRow_Variable in myDataTable.Rows)
                {
                    tempRow = tempRow_Variable;
                    if (name == tempRow["Login"].ToString())
                    {
                        ip = tempRow["IP"].ToString();
                    }


                }
                cnn.Close();
                return ip;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Napotkano blad: "+ex);
                return ip;
            }
        }
        public static bool searchdb(string name)
        {
            bool valid = false;
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=KF\\SQLEXPRESS;Initial Catalog=TIP;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Opened!");
                string com = "Select ID, Login from Users";
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                myDataSet = new DataSet();
                adpt.Fill(myDataSet, "Users");
                DataTable myDataTable = myDataSet.Tables[0];
                DataRow tempRow = null;
                foreach (DataRow tempRow_Variable in myDataTable.Rows)
                {
                    tempRow = tempRow_Variable;
                    if (name == tempRow["Login"].ToString())
                    {
                        valid = true;
                        break;
                    }
                    valid = false;

                }
                cnn.Close();
                return valid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Napotkano blad: " + ex);
                return false;
            }
        }
        public static void registertodb(string username, string passwd, string ip)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=KF\\SQLEXPRESS;Initial Catalog=TIP;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string com = "Select ID, Login, IP FROM Users";
                //string com = "INSERT INTO USERS (UserID, Username, Passwd,IP,Status)VALUES(1, '"+username+"', '"+passwd+"', '"+ip+"', 1)";
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                DataSet myDataSet = new DataSet();
                adpt.Fill(myDataSet, "Users");
                DataTable myDataTable = myDataSet.Tables[0];
                DataRow tempRow = null;
                int i = 0;
                foreach (DataRow tempRow_Variable in myDataTable.Rows)
                {
                    tempRow = tempRow_Variable;
                    i++;
                }
                string com2 = "INSERT INTO Users VALUES('" + username + "', '" + passwd + "', '" + ip + "', 1)";
                SqlCommand command = new SqlCommand(com2, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
        public void connecttodb()
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=KF\\SQLEXPRESS;Initial Catalog=TIP;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Opened!");
                string com = "Select ID, Login, IP from Users";
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                myDataSet = new DataSet();
                adpt.Fill(myDataSet, "Users");
                DataTable myDataTable = myDataSet.Tables[0];
                DataRow tempRow = null;
                foreach (DataRow tempRow_Variable in myDataTable.Rows)
                {
                    tempRow = tempRow_Variable;
                    if (this.listBox2.InvokeRequired) this.Invoke((MethodInvoker)(() => listBox1.Items.Add(tempRow["ID"] + "\t " + tempRow["Login"] + "\t\t" + " [" + tempRow["IP"] + "]")));
                    else
                        listBox2.Items.Add(tempRow["ID"] + "\t " + tempRow["Login"] + "\t\t" + " [" + tempRow["IP"] + "]");
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! " +ex.Message);
            }
        }
        public static bool databasecheck(string username, string password)
        {
            bool valid=false;
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=KF\\SQLEXPRESS;Initial Catalog=TIP;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Opened!");
                string com = "Select ID, Login, IP, Password from Users";
                SqlDataAdapter adpt = new SqlDataAdapter(com, cnn);
                myDataSet = new DataSet();
                adpt.Fill(myDataSet, "Users");
                DataTable myDataTable = myDataSet.Tables[0];
                DataRow tempRow = null;
                foreach (DataRow tempRow_Variable in myDataTable.Rows)
                {
                    tempRow = tempRow_Variable;
                    if(username==tempRow["Login"].ToString()&&password ==tempRow["Password"].ToString())
                    {
                        valid = true;
                        break;
                    }
                    valid = false;
                    //listBox1.Items.Add(tempRow["UserID"] + "\t " + tempRow["Username"] + "\t\t" + " [" + tempRow["IP"] + "]");
                }
                cnn.Close();
                return valid;
               
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Can not open connection ! " + ex.Message);
                return false;
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            connecttodb();
        }
        
        private void waitforconnection_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serversocket = new TcpListener(8001);
            TcpClient clientSocket = default(TcpClient);
            try
            {
                serversocket.Start();
                int counter = 0;
                MessageBox.Show("Uruchomiono serwer");
                while (true)
                {
                    counter++;
                    clientSocket = serversocket.AcceptTcpClient();
                    handleClinet client = new handleClinet(this);
                    client.startClient(clientSocket, counter.ToString());
                    clientSocket.Close();
                    serversocket.Stop();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Wprowadzono bledny adres serwera.");
            }
        }
        public delegate void ShowUsersOnlineDelegate();
        public void ShowUsersOnline(List<User> list)
        {
            if (this.listBox1.InvokeRequired) this.Invoke((MethodInvoker)(() => listBox1.Items.Clear()));
            else
                listBox1.Items.Clear();
            for(int i =0;i<list.Count;i++)
            {
                string username = list[i].Username;
                string ip = list[i].IP;
                string status = "offline";
                if (list[i].online == 1)
                {
                    status = "online";
                    if (this.listBox1.InvokeRequired) this.Invoke((MethodInvoker)(() => listBox1.Items.Add(i.ToString() + "\t " + username + "\t\t" + " [" + ip + "]" + "\t\t" + status)));
                    else
                        listBox1.Items.Add(i.ToString() + "\t " + username + "\t\t" + " [" + ip + "]" + "\t\t" + status);
                }
                
            }
            
        }
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
        public class handleClinet 
        {
            private Form1 parentform;
            TcpClient clientSocket;
            string clNo;
            public handleClinet(Form1 mainform)
            {
                parentform = mainform;
            }
            public void startClient(TcpClient inClientSocket, string clineNo)
            {
                this.clientSocket = inClientSocket;
                this.clNo = clineNo;
                Thread ctThread = new Thread(doChat);
                ctThread.Start();
            }
            private void doChat()
            {
                int id=-3;
                while (isClientConnected(clientSocket))
                {
                    try
                    {
                        Console.WriteLine("Client " + clientSocket.Client.RemoteEndPoint.ToString() + " has connected");
                        BinaryReader reader = new BinaryReader(clientSocket.GetStream());
                        BinaryWriter write = new BinaryWriter(clientSocket.GetStream());
                        string recieved = reader.ReadString();
                        Console.WriteLine(recieved);
                        if(recieved=="exit@@")
                        {
                            clientSocket.Close();
                            Console.Write("disconnected");
                            break;
                        }
                        string[] recieveddata = recieved.Split('@');
                        if(recieveddata[0]=="register")
                        {
                            registertodb(recieveddata[1], recieveddata[2], recieveddata[3]);
                            parentform.connecttodb();
                            write.Write("registersuccess");
                        }
                        else if(recieveddata[0]=="login")
                        {
                            bool valid = databasecheck(recieveddata[1],recieveddata[2]);
                            if (valid)
                            {
                                User added = new User(recieveddata[1], getUserIp(recieveddata[1]));
                                parentform.usersonline.Add(added);
                                parentform.usersonline[parentform.usersonline.Count - 1].online = 1;
                                parentform.ShowUsersOnline(parentform.usersonline);
                                id = parentform.usersonline.Count - 1;
                                write.Write("success");  
                            }
                            else write.Write("wrong");
                        }
                        else if (recieveddata[0] == "search")
                        {
                            bool valid = searchdb(recieveddata[1]);
                            if (valid)
                            {
                                StringBuilder builder = new StringBuilder();
                                write.Write("searchsuccess");
                            }
                            else write.Write("searchwrong");
                        }
                        else if (recieveddata[0] == "call")
                        {
                            string ipresult = getUserIp(recieveddata[1]);
                            if (ipresult != "" && parentform.usersonline.Exists(m=>m.Username == recieveddata[1].ToString()) )
                            {
                                StringBuilder builder = new StringBuilder();
                                builder.Append("useravailible@");
                                builder.Append(ipresult);
                                write.Write(builder.ToString());
                            }
                            else write.Write("noipfound");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(" >> " + ex.ToString());
                    }
                }
                if(!isClientConnected(clientSocket))
                {
                    if (parentform.usersonline.Count!=0&& id!=-3)
                    {
                        parentform.usersonline[id].online = 2;
                        parentform.ShowUsersOnline(parentform.usersonline);
                    }
                    Console.WriteLine("Client " + clientSocket.Client.RemoteEndPoint.ToString()+" has disconnected");
                    //clientSocket.GetStream().Close();
                    clientSocket.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IPbox.Text != "")
            {
                if (!waitforconnection.IsBusy)
                {
                    waitforconnection.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Wpisz IP serwera.");
            }
        }
        private void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            // check error, check cancel, then use result
            /*
            if (e.Error != null)
            {
                MessageBox.Show("Empty argument");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }
            else
            {
                string result = e.Result as String;
                string[] splited = result.Split('@');
                // registertodb(splited[0],splited[1],splited[2]);
                // connecttodb();
                for (int i = 0; i < splited.Length; i++)
                {
                    Console.Write(splited[i] + " ");
                }

                // use it on the UI thread
            }
            // general cleanup code, runs when there was an error or not.*/
        }

        private void readmessage_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IPbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
