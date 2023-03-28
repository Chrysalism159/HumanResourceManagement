using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || password.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else if (user.Text == "Admin" && password.Text == "Admin123")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
                MessageBox.Show("Wrong Username or Password");
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            user.Text = "";
            password.Text = "";
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
