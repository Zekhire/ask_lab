using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ASK5
{
    public partial class App : Form
    {
        public int difficulty_level;
        public string easy_symbols;
        public string medium_symbols;
        public string hard_symbols;
        public string insane_symbols;
        public string active;
        public bool running;
        public int round_nr;
        public int[] mistakes;
        public double[] time;
        public Results results;
        public bool get_results;
        Stopwatch stopwatch;

    public App()
        {
            easy_symbols = "aąbcćdeęfghijklłmnńoóprsśtuwyzźż";
            medium_symbols = "あいうえおんかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわを";
            hard_symbols = "アイウエオンカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲ";
            insane_symbols = "言䚯訄訅訇訃訂計討訏訑訒訔訕訞訖訐訌訓訊記託設許訟訡訠訢訤訦訫訬訯訳訛訝訥訣訪註評詞証詔訴訵訷訽訾詀詠詃詅詇詉詍詎詓詖詗詘詜詝訶詁詛詒詆診詈詑詐詰誇該詮詩試詳話詫詡詥詧詵詶詷詹詺詻詾詿誀誃詼誆詭詬詢";
            running = false;
            round_nr = 0;
            mistakes = new int[10];
            time = new double[10];
            get_results = true;
            stopwatch = new Stopwatch();
            for (int i=0; i<10; i++)
            {
                mistakes[i] = 0;
                time[i] = 0;
            }
            InitializeComponent();
        }

        private void tutorial_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                running = true;
                MessageBox.Show("Aplikacja polega na jak najszybszym kliknięciu odpowiedniego przycisku z symbolem wskazanym na wyświetlaczu.");
                MessageBox.Show("Pojedynczy test składa się z 10 rund.");
                MessageBox.Show("Po kliknięciu poprawnego przycisku automatycznie następuje losowanie następnych symboli.");
                MessageBox.Show("Po przejściu 10 rund zostaną wyświetlone wyniki:\n- czas między wylosowaniem nowych symboli a wciśnięciem poprawnego przycisku\n-ilość popełnionych błędów");
                MessageBox.Show("Użytkownik ma do wyboru 4 tryby różniące się zestawem symboli.");
                MessageBox.Show("Za chwilę rozpocznie się przykładowy test. Wyniki nie zostaną wyświetlone.");
                active = easy_symbols;
                get_results = false;
                generate_text(easy_symbols);
            }
        }


        private void generate_text(string table)
        {
            displayer2.Text = (round_nr + 1).ToString();
            if (round_nr < 10)
            {
                Random random = new Random();
                int[] Ids = new int[10];
                for (int i = 0; i < 10; i++)         // Losowanie różnych znaków na każdy przycisk
                {
                    int id = random.Next(0, table.Length - 1);
                    for (int j = 0; j < i; j++)
                    {
                        if (id == Ids[j])
                        {
                            i--;
                            break;
                        }
                    }
                    Ids[i] = id;
                }
                Ids[random.Next(1, 9)] = Ids[9];

                displayer.Text = table[Ids[9]].ToString();
                button1.Text = table[Ids[0]].ToString();
                button2.Text = table[Ids[1]].ToString();
                button3.Text = table[Ids[2]].ToString();
                button4.Text = table[Ids[3]].ToString();
                button5.Text = table[Ids[4]].ToString();
                button6.Text = table[Ids[5]].ToString();
                button7.Text = table[Ids[6]].ToString();
                button8.Text = table[Ids[7]].ToString();
                button9.Text = table[Ids[8]].ToString();
            }
            else
            {
                if (get_results)
                {
                    results = new Results(this, time, mistakes);
                    results.Show();
                }
                else
                {
                    get_results = true;
                }

                round_nr = 0;
                running = false;
                displayer.Text = "";
                displayer2.Text = "";
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
                for (int i = 0; i < 10; i++)
                {
                    mistakes[i] = 0;
                }
            }

        }

        private void start_buttons_Click(String table)
        {
            if(!Results.open)
            {
                if (!running)
                {
                    running = true;
                    active = table;
                    generate_text(table);
                    stopwatch.Start();
                }
            }
        }


        private void easy_button_Click(object sender, EventArgs e)
        {
            start_buttons_Click(easy_symbols);
        }

        private void medium_button_Click(object sender, EventArgs e)
        {
            start_buttons_Click(medium_symbols);
        }

        private void hard_button_Click(object sender, EventArgs e)
        {
            start_buttons_Click(hard_symbols);
        }

        private void insane_Click(object sender, EventArgs e)
        {
            start_buttons_Click(insane_symbols);
        }

        private void buttons_Click(string text)
        {
            if (running)
            {
                if (text == displayer.Text)
                {
                    if (get_results)
                    {
                        stopwatch.Stop();
                        time[round_nr] = stopwatch.Elapsed.TotalMilliseconds;
                    }
                    round_nr++;
                    generate_text(active);
                    stopwatch.Restart();
                }
                else
                {
                    mistakes[round_nr]++;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            buttons_Click(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttons_Click(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttons_Click(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttons_Click(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttons_Click(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttons_Click(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttons_Click(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttons_Click(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttons_Click(button9.Text);
        }

    }
}
