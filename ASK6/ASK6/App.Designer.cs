namespace ASK6
{
    partial class App
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            open = false;
            if(!boom)
                log_in_window.Show();
            if (check_of_presence_communique.open)
            {
                presence_window.Close();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer_time = new System.Windows.Forms.Timer(this.components);
            this.label_counter = new System.Windows.Forms.Label();
            this.label_RAM = new System.Windows.Forms.Label();
            this.label_CPU_usage = new System.Windows.Forms.Label();
            this.label_random = new System.Windows.Forms.Label();
            this.button_CPU_usage = new System.Windows.Forms.Button();
            this.button_RAM = new System.Windows.Forms.Button();
            this.button_random = new System.Windows.Forms.Button();
            this.label_log = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer_time
            // 
            this.timer_time.Interval = 1000;
            this.timer_time.Tick += new System.EventHandler(this.timer_time_Tick);
            // 
            // label_counter
            // 
            this.label_counter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_counter.ForeColor = System.Drawing.Color.Green;
            this.label_counter.Location = new System.Drawing.Point(512, 20);
            this.label_counter.Name = "label_counter";
            this.label_counter.Size = new System.Drawing.Size(150, 40);
            this.label_counter.TabIndex = 2;
            this.label_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_RAM
            // 
            this.label_RAM.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_RAM.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_RAM.Location = new System.Drawing.Point(158, 40);
            this.label_RAM.Name = "label_RAM";
            this.label_RAM.Size = new System.Drawing.Size(120, 20);
            this.label_RAM.TabIndex = 5;
            this.label_RAM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CPU_usage
            // 
            this.label_CPU_usage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_CPU_usage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_CPU_usage.Location = new System.Drawing.Point(15, 40);
            this.label_CPU_usage.Name = "label_CPU_usage";
            this.label_CPU_usage.Size = new System.Drawing.Size(120, 20);
            this.label_CPU_usage.TabIndex = 4;
            this.label_CPU_usage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_random
            // 
            this.label_random.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_random.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_random.Location = new System.Drawing.Point(302, 40);
            this.label_random.Name = "label_random";
            this.label_random.Size = new System.Drawing.Size(120, 20);
            this.label_random.TabIndex = 6;
            this.label_random.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_CPU_usage
            // 
            this.button_CPU_usage.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_CPU_usage.Location = new System.Drawing.Point(15, 63);
            this.button_CPU_usage.Name = "button_CPU_usage";
            this.button_CPU_usage.Size = new System.Drawing.Size(120, 35);
            this.button_CPU_usage.TabIndex = 7;
            this.button_CPU_usage.Text = "włącz wentylator";
            this.button_CPU_usage.UseVisualStyleBackColor = false;
            this.button_CPU_usage.Click += new System.EventHandler(this.button_CPU_usage_Click);
            // 
            // button_RAM
            // 
            this.button_RAM.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_RAM.Location = new System.Drawing.Point(158, 63);
            this.button_RAM.Name = "button_RAM";
            this.button_RAM.Size = new System.Drawing.Size(120, 35);
            this.button_RAM.TabIndex = 8;
            this.button_RAM.Text = "włącz system przeciwpożarowy";
            this.button_RAM.UseVisualStyleBackColor = false;
            this.button_RAM.Click += new System.EventHandler(this.button_RAM_Click);
            // 
            // button_random
            // 
            this.button_random.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_random.Location = new System.Drawing.Point(302, 63);
            this.button_random.Name = "button_random";
            this.button_random.Size = new System.Drawing.Size(120, 35);
            this.button_random.TabIndex = 9;
            this.button_random.Text = "wymień pręty kontrolne";
            this.button_random.UseVisualStyleBackColor = false;
            this.button_random.Click += new System.EventHandler(this.button_random_Click);
            // 
            // label_log
            // 
            this.label_log.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_log.ForeColor = System.Drawing.Color.Lime;
            this.label_log.Location = new System.Drawing.Point(15, 101);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(407, 135);
            this.label_log.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Zużycie procesora [%]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(158, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dostępny RAM [MB]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(305, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Liczba pseudolosowa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 278);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.button_random);
            this.Controls.Add(this.button_RAM);
            this.Controls.Add(this.button_CPU_usage);
            this.Controls.Add(this.label_random);
            this.Controls.Add(this.label_RAM);
            this.Controls.Add(this.label_CPU_usage);
            this.Controls.Add(this.label_counter);
            this.Name = "App";
            this.Text = "ASK6 App";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer_time;
        private System.Windows.Forms.Label label_counter;
        private System.Windows.Forms.Label label_RAM;
        private System.Windows.Forms.Label label_random;
        private System.Windows.Forms.Label label_CPU_usage;
        private System.Windows.Forms.Button button_CPU_usage;
        private System.Windows.Forms.Button button_RAM;
        private System.Windows.Forms.Button button_random;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

