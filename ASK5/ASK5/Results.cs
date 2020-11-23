using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ASK5
{
    public partial class Results : Form
    {
        static public bool open = false;
        App app;
        public Results(App window, double[] time, int[] mistakes)
        {
            open = true;
            app = window;
            InitializeComponent();
            results_time_chart.ChartAreas[0].AxisX.Minimum = 1;
            results_time_chart.ChartAreas[0].AxisX.Maximum = 10;
            results_mistakes_chart.ChartAreas[0].AxisX.Minimum = 1;
            results_mistakes_chart.ChartAreas[0].AxisX.Maximum = 10;
            DataTable table = new DataTable();
            table.Columns.Add("round", typeof(int));
            table.Columns.Add("time [ms]", typeof(double));
            table.Columns.Add("mistakes [n]", typeof(int));
            for (int i = 0; i < 10; i++)
            {
                results_time_chart.Series["time [ms]"].Points.AddXY(i + 1, time[i]);
                results_mistakes_chart.Series["mistakes [n]"].Points.AddXY(i + 1, mistakes[i]);
                table.Rows.Add(i + 1, time[i], mistakes[i]);
            }
            results_grid.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
