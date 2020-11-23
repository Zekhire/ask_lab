using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
   
    public partial class Form1 : Form
    {
        //double ANS, val, dec_pt;
        bool point = false, oper_pressed;
        string operation;
        double val;
        Color color;
        Color buttonscollor;

        public Form1()
        {
            //op_1 = "";
          // input = "";
            InitializeComponent();
        }

      //  private void zero_Click(object sender, EventArgs e)


        private void button_click_handler(object sender, EventArgs e)
        {
            if ((Answ_box.Text == "0") || (oper_pressed))
            {
                Answ_box.Clear();
                point = false;
            }

            oper_pressed = false;
            Button b = (Button)sender;
            if (b.Text == "," && !point)
            {
                point = true;
                Answ_box.Text = Answ_box.Text + b.Text;
            }
            if (b.Text != ",")
            {
                Answ_box.Text = Answ_box.Text + b.Text;
            }

        }
        private void zero_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }
        private void one_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }
        
        private void two_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void three_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void four_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void five_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void six_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void seven_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void eight_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void nine_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }

        private void pt_Click(object sender, EventArgs e)
        {
            button_click_handler(sender, e);
        }
        private void operation_handler(object sender)
        {
            Button b = (Button)sender;
            operation = b.Text;
            val = Double.Parse(Answ_box.Text);
            oper_pressed = true;
            equation.Text = val + " " + operation;
        }


        private void ADD_Click(object sender, EventArgs e)
        {
            operation_handler(sender);
        }

        private void SUB_Click(object sender, EventArgs e)
        {
            operation_handler(sender);
        }

        private void MUL_Click(object sender, EventArgs e)
        {
            operation_handler(sender);
        }

        private void ans_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    Answ_box.Text = (val + Double.Parse(Answ_box.Text)).ToString();
                    break;
                case "-":
                    Answ_box.Text = (val - Double.Parse(Answ_box.Text)).ToString();
                    break;
                case "*":
                    Answ_box.Text = (val * Double.Parse(Answ_box.Text)).ToString();
                    break;
                case "/":
                    Answ_box.Text = (val / Double.Parse(Answ_box.Text)).ToString();
                    break;
                default:
                    break;
            }
            double ans = double.Parse(Answ_box.Text);
            if (ans == (double)ans)
            {
                point = true;
            }
            else
                point = false;
        }

        private void Answ_box_TextChanged(object sender, EventArgs e)
        {
        }

        private void clear_all_Click(object sender, EventArgs e)
        {
            point = false;
            Answ_box.Text = "0";
        }
        
        private void clear_Click(object sender, EventArgs e)
        {
            val = 0;
            point = false;
            Answ_box.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            color = this.BackColor;
            buttonscollor = this.zero.BackColor;
        }

        private void change_colors(Color color_buttons, Color back_color)
        {
            this.BackColor = back_color;
            this.zero.BackColor = color_buttons;
            this.one.BackColor = color_buttons;
            this.two.BackColor = color_buttons;
            this.three.BackColor = color_buttons;
            this.four.BackColor = color_buttons;
            this.five.BackColor = color_buttons;
            this.six.BackColor = color_buttons;
            this.seven.BackColor = color_buttons;
            this.eight.BackColor = color_buttons;
            this.nine.BackColor = color_buttons;
            this.clear.BackColor = color_buttons;
            this.clear_all.BackColor = color_buttons;
            this.DIV.BackColor = color_buttons;
            this.MUL.BackColor = color_buttons;
            this.ADD.BackColor = color_buttons;
            this.SUB.BackColor = color_buttons;
            this.pt.BackColor = color_buttons;
            this.ans.BackColor = color_buttons;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_colors(buttonscollor, color);
            this.BackgroundImage = null;
        }

        private void dark_theme_Click(object sender, EventArgs e)
        {
            change_colors(
                Color.FromKnownColor(KnownColor.DimGray),
                Color.FromKnownColor(KnownColor.DimGray)
                );
            this.BackgroundImage = null;
        }

        private void shrek_theme_Click(object sender, EventArgs e)
        {
            change_colors(
                Color.FromKnownColor(KnownColor.SaddleBrown),
                Color.FromKnownColor(KnownColor.YellowGreen)
            );
            Image myimage = new Bitmap(@"D:\Moje\Projekty\ASK\ASK3\Kalkulator\Kalkulator\shrek.jpg");
            //Image myimage = new Bitmap(global::Kalkulator.Properties.Resources.);
            this.BackgroundImage = myimage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;
            string sec = Convert.ToString(seconds);
            string min = Convert.ToString(minutes);
            string hrs = Convert.ToString(hours);
            if (hours < 10)
            {
                hrs = "0" + hrs;
            }
            if (minutes < 10)
            {
                min = "0" + min;
            }
            if (seconds < 10)
            {
                sec = "0" + sec;
            }
            label1.Text = hrs + ":" + min + ":" + sec;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DIV_Click(object sender, EventArgs e)
        {
            operation_handler(sender);
        }

    }
}
