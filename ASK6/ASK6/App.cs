using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;

namespace ASK6
{
    public partial class App : Form
    {
        static public bool open = false;

        public LogIn log_in_window;
        public check_of_presence_communique presence_window;

        public int check_of_presence_counter;
        public int log_out_counter;
        public int period_of_checking;
        public int CPU_usage_border;
        public int RAM_border;
        public int random_border;
        public bool CPU_usage_occured;
        public bool RAM_occured;
        public bool random_occured;
        public bool boom;
        public int time_to_boom_period;
        public int time_to_ignition_period;
        public int time_to_chain_reaction_period;
        public int time_to_boom;
        public int time_to_ignition;
        public int time_to_chain_reaction;

        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        List<string> log;


        public App(LogIn window)
        {
            this.log_in_window = window;
            open = true;
            period_of_checking = 30;
            CPU_usage_border = 30;
            RAM_border = 2800;
            random_border = 10;
            check_of_presence_counter = period_of_checking;
            CPU_usage_occured = false;
            RAM_occured = false;
            random_occured = false;
            boom = false;
            time_to_boom_period = 10;
            time_to_ignition_period = 10;
            time_to_chain_reaction_period = 10; ;
            time_to_boom = time_to_boom_period;
            time_to_ignition = time_to_ignition_period = 10;
            time_to_chain_reaction = time_to_chain_reaction_period;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            //CPU_usage_border = Convert.ToInt32(cpuCounter.NextValue());
            //CPU_usage_border = Convert.ToInt32(cpuCounter.NextValue());
            //CPU_usage_border = Convert.ToInt32(cpuCounter.NextValue());
            //MessageBox.Show(CPU_usage_border.ToString());
            //RAM_border = Convert.ToInt32(ramCounter.NextValue());
            //MessageBox.Show(RAM_border.ToString());
            log = new List<string>();
            InitializeComponent();
            label_CPU_usage.Text = 0.ToString();
            label_RAM.Text = 0.ToString();
            label_random.Text = 0.ToString();
            label_counter.Text = check_of_presence_counter.ToString();
            timer_time.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            log_in_window.Show();
        }

        private void timer_time_Tick(object sender, EventArgs e)
        {
            if (!boom)
            {
                if ((time_to_boom == 0) || (time_to_ignition == 0) || (time_to_chain_reaction == 0))
                {
                    boom = true;
                    MessageBox.Show("BOOM!");
                    System.Windows.Forms.Application.ExitThread();
                }
                if (!check_of_presence_communique.open)     // <- jeśli nie wystapił komunikat
                {
                    if (check_of_presence_counter == 0)
                    {
                        presence_window = new check_of_presence_communique(this);
                        presence_window.Show();
                    }
                    else
                    {
                        check_of_presence_counter--;
                        label_counter.Text = check_of_presence_counter.ToString();
                    }
                }
                else
                {
                    check_of_presence_counter = period_of_checking;
                }
                if (!CPU_usage_occured)
                {
                    if (CPU_usage())
                    {
                        CPU_usage_occured = true;
                        log_write("Nastąpiło przegrzanie! Włącz wentylator!");
                        log_write("Do wybuchu postało " + time_to_boom + "s. Włącz wentylator!");
                        button_CPU_usage.BackColor = System.Drawing.Color.Red;
                        time_to_boom--;
                    }
                }
                else
                {
                    log_write("Do wybuchu postało " + time_to_boom + "s. Włącz wentylator!");
                    time_to_boom--;
                }
                if (!RAM_occured)
                {
                    if (RAM())
                    {
                        RAM_occured = true;
                        log_write("Wybuchł pożar! Ugaś go!");
                        log_write("Do wybuchu pozostało " + time_to_ignition + "s. Ugaś pożar!");
                        button_RAM.BackColor = System.Drawing.Color.Red;
                        time_to_ignition--;
                    }
                }
                else
                {
                    log_write("Do wybuchu pozostało " + time_to_ignition + "s. Ugaś pożar!");
                    time_to_ignition--;
                }
                if (!random_occured)
                {
                    if (random())
                    {
                        random_occured = true;
                        log_write("Pręty kontrolne uległy uszkodzeniu! Wymień je");
                        log_write("Do wybuchu pozostało " + time_to_chain_reaction + "s. Wymień pręty kontrolne!");
                        button_random.BackColor = System.Drawing.Color.Red;
                        time_to_chain_reaction--;
                    }
                }
                else
                {
                    log_write("Do wybuchu pozostało " + time_to_chain_reaction + "s. Wymień pręty kontrolne!");
                    time_to_chain_reaction--;
                }
            }
        }

        private void log_write(string statement)
        {
            if (log.Count > 9)
            {
                log.RemoveAt(0);
            }
            log.Add(statement + "\n");
            string logs = "";
            for (int i = 0; i < log.Count; i++)
            {
                logs += log[i];
            }
            label_log.Text = logs;
        }

        private bool CPU_usage()
        {
            double CPU_usage = cpuCounter.NextValue();
            label_CPU_usage.Text = Math.Round(CPU_usage, 3).ToString();
            if (CPU_usage > CPU_usage_border)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool RAM()
        {
            double RAM = ramCounter.NextValue();
            label_RAM.Text = RAM.ToString();
            if (RAM < RAM_border)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool random()
        {
            Random rand = new Random();
            int val = rand.Next(100);
            label_random.Text = val.ToString();
            if (val > 10)               // <- 10% szansy na wystąpienie błędu
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private double Get_CPU_temperature()
        {
            double CPU_temperature = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            foreach (ManagementObject service in searcher.Get())
            {
                CPU_temperature = Convert.ToDouble(service["CurrentTemperature"]);
                CPU_temperature = (CPU_temperature - 2732) / 10.0;
            }
            return CPU_temperature;
        }

        private double Get_fan_speed()
        {
            double fan_speed = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_Fan");
            foreach (ManagementObject service in searcher.Get())
            {
                fan_speed = Convert.ToDouble(service["DesiredSpeed"]);
            }
            return fan_speed;
        }


        private void button_CPU_usage_Click(object sender, EventArgs e)
        {
            CPU_usage_occured = false;
            log_write("Włączono wentylator");
            button_CPU_usage.BackColor = SystemColors.Highlight;
            time_to_boom = time_to_boom_period;
        }

        private void button_RAM_Click(object sender, EventArgs e)
        {
            RAM_occured = false;
            log_write("Włączono system przeciwpożarowy");
            button_RAM.BackColor = SystemColors.Highlight;
            time_to_ignition = time_to_ignition_period;
        }

        private void button_random_Click(object sender, EventArgs e)
        {
            random_occured = false;
            log_write("Wymieniono pręty kontrolne");
            button_random.BackColor = SystemColors.Highlight;
            time_to_chain_reaction = time_to_chain_reaction_period;
        }
    }
}
