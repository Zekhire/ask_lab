namespace ASK5
{
    partial class Results
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            open = false;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.results_time_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.results_mistakes_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.results_grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.results_time_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.results_mistakes_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.results_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(882, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 46);
            this.button1.TabIndex = 18;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // results_time_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.results_time_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.results_time_chart.Legends.Add(legend1);
            this.results_time_chart.Location = new System.Drawing.Point(12, 12);
            this.results_time_chart.Name = "results_time_chart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "time [ms]";
            series1.YValuesPerPoint = 2;
            this.results_time_chart.Series.Add(series1);
            this.results_time_chart.Size = new System.Drawing.Size(410, 300);
            this.results_time_chart.TabIndex = 19;
            // 
            // results_mistakes_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.results_mistakes_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.results_mistakes_chart.Legends.Add(legend2);
            this.results_mistakes_chart.Location = new System.Drawing.Point(329, 65);
            this.results_mistakes_chart.Name = "results_mistakes_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "mistakes [n]";
            this.results_mistakes_chart.Series.Add(series2);
            this.results_mistakes_chart.Size = new System.Drawing.Size(430, 300);
            this.results_mistakes_chart.TabIndex = 20;
            // 
            // results_grid
            // 
            this.results_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.results_grid.Location = new System.Drawing.Point(659, 144);
            this.results_grid.Name = "results_grid";
            this.results_grid.Size = new System.Drawing.Size(353, 283);
            this.results_grid.TabIndex = 21;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 439);
            this.Controls.Add(this.results_grid);
            this.Controls.Add(this.results_mistakes_chart);
            this.Controls.Add(this.results_time_chart);
            this.Controls.Add(this.button1);
            this.Name = "Results";
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this.results_time_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.results_mistakes_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.results_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart results_time_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart results_mistakes_chart;
        private System.Windows.Forms.DataGridView results_grid;
    }
}