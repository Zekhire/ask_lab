using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASK6
{
    public partial class LogIn : Form
    {
        public string login;
        public string password;
        public App form;
        public LogIn()
        {
            login = "Krzysio";
            password = "kremówka";
            InitializeComponent();
        }

        private void button_log_in_Click(object sender, EventArgs e)
        {
            string login_input = this.textBox_user.Text;
            string password_input = this.textBox_password.Text;
            if (login_input == login)
            {
                if (password_input == password)
                {
                    this.Hide();
                    if (!App.open) {
                        form = new App(this);
                        form.Show();
                        this.textBox_user.Text = "";
                        this.textBox_password.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Nazwa użytkownika lub hasło jest niepoprawne.");
                }
            }
            else
            {
                MessageBox.Show("Nazwa użytkownika lub hasło jest niepoprawne.");
            }
        }
    }
}
