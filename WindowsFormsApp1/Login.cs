using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameText.Text=="admin"&&passwordText.Text=="admin")
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Wrong username or password!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
