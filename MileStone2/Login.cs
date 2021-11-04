using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MileStone2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register test = new Register();
            test.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentRecords test = new StudentRecords();
            test.Show();
            Visible = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
