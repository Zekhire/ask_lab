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
    public partial class check_of_presence_communique : Form
    {
        static public bool open = false;
        public int time_to_confirm;
        public int counter;
        public bool blockade;
        App app_window;

        public check_of_presence_communique(App app_window)
        {
            open = true;
            this.app_window = app_window;
            time_to_confirm = 10;
            blockade = false;
            counter = time_to_confirm;
            InitializeComponent();
            this.label_counter.Text = time_to_confirm.ToString();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_time_Tick(object sender, EventArgs e)
        {
            if (!blockade)
            {
                if (time_to_confirm == 0)
                {
                    blockade = true;
                    MessageBox.Show("Zostałeś automatycznie wylogowany");
                    app_window.Close();
                    Close();
                }
                else
                {
                    time_to_confirm--;
                    this.label_counter.Text = time_to_confirm.ToString();
                }
            }
        }
    }
}
