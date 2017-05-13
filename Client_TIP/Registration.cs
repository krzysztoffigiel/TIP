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

namespace Client_TIP
{
    public partial class Registration : Form
    {
        
        public Registration()
        {
            InitializeComponent();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            label5.Hide();
        }
        private void registerBtn_Click(object sender, EventArgs e)
        {
            if(registerPasswordTextBox.Text==registerConfirmTextBox.Text)
            {
                try
                {
                    if (registerLoginTextBox.Text != null && registerIPTextBox.Text != null && registerPasswordTextBox.Text != null)
                    {
                        StringBuilder messagebuilder = new StringBuilder();
                        messagebuilder.Append("register@");
                        messagebuilder.Append(registerLoginTextBox.Text);
                        messagebuilder.Append("@");
                        messagebuilder.Append(getMD5(registerPasswordTextBox.Text));
                        messagebuilder.Append("@");
                        messagebuilder.Append(registerIPTextBox.Text);
                        BinaryWriter writer = new BinaryWriter(Form1.tcpclnt.GetStream());
                        writer.Write(messagebuilder.ToString());
                        MessageBox.Show("Zarejestrowano");
                    }
                }
                catch (Exception se)
                {
                    Console.WriteLine("Błąd rejestracji " + se.StackTrace);
                }
            }
            else
            {
                label5.Show();
                label5.Text = "Hasło musi być takie samo";
            }  
        }

        private void cancelBtn2_Click(object sender, EventArgs e)
        {
            registerLoginTextBox.Clear();
            registerIPTextBox.Clear();
            registerPasswordTextBox.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            //Form1 form1 = new Form1();
            //form1.Show();
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
    }
}
