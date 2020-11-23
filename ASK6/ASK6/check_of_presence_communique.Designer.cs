namespace ASK6
{
    partial class check_of_presence_communique
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
            this.components = new System.ComponentModel.Container();
            this.label_counter = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.label_confirm_prompt = new System.Windows.Forms.Label();
            this.timer_time = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_counter
            // 
            this.label_counter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_counter.ForeColor = System.Drawing.Color.Red;
            this.label_counter.Location = new System.Drawing.Point(52, 42);
            this.label_counter.Name = "label_counter";
            this.label_counter.Size = new System.Drawing.Size(179, 62);
            this.label_counter.TabIndex = 0;
            this.label_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_confirm
            // 
            this.button_confirm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_confirm.Location = new System.Drawing.Point(105, 135);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 1;
            this.button_confirm.Text = "jestem";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // label_confirm_prompt
            // 
            this.label_confirm_prompt.AutoSize = true;
            this.label_confirm_prompt.BackColor = System.Drawing.SystemColors.Control;
            this.label_confirm_prompt.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_confirm_prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_confirm_prompt.Location = new System.Drawing.Point(34, 9);
            this.label_confirm_prompt.Name = "label_confirm_prompt";
            this.label_confirm_prompt.Size = new System.Drawing.Size(221, 20);
            this.label_confirm_prompt.TabIndex = 2;
            this.label_confirm_prompt.Text = "Do wylogowania pozostało";
            // 
            // timer_time
            // 
            this.timer_time.Enabled = true;
            this.timer_time.Interval = 1000;
            this.timer_time.Tick += new System.EventHandler(this.timer_time_Tick);
            // 
            // check_of_presence_communique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 191);
            this.Controls.Add(this.label_confirm_prompt);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label_counter);
            this.Name = "check_of_presence_communique";
            this.Text = "ASK6 Log Out";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_counter;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Label label_confirm_prompt;
        private System.Windows.Forms.Timer timer_time;
    }
}