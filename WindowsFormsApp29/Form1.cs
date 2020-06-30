using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp29
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string send(string str)
        {
            byte [] b=Encoding.Default.GetBytes(str);
            socket.Send(b);
            byte[] re = new byte[1024];
            socket.Receive(re);

            return Encoding.Default.GetString(re).Trim();
        }


        public static Socket socket;
        public string ConnectServer()
        {
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10086));
            byte[] re = new byte[1024];
            socket.Receive(re);
            string s = Encoding.Default.GetString(re).Trim().TrimEnd().Replace("\0","");
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if( ConnectServer()=="Login")
            {
                MessageBox.Show("登录成功");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(send("GET"));
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals('w'))
            {
                if(send("w").Equals("OK"))
                {

                }
            }
            if (e.KeyChar.Equals('a'))
            {
                if (send("a").Equals("OK"))
                {

                }
            }
            if (e.KeyChar.Equals('s'))
            {
                if (send("s").Equals("OK"))
                {

                }
            }
            if (e.KeyChar.Equals('d'))
            {
                if (send("d").Equals("OK"))
                {

                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
