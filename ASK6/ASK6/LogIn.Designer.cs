namespace ASK6
{
    partial class LogIn
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
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label_login_prompt = new System.Windows.Forms.Label();
            this.button_log_in = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(120, 62);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(207, 20);
            this.textBox_user.TabIndex = 0;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(120, 106);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(207, 20);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(12, 65);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(102, 13);
            this.label_user.TabIndex = 2;
            this.label_user.Text = "Nazwa użytkownika";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(78, 109);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(36, 13);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Hasło";
            // 
            // label_login_prompt
            // 
            this.label_login_prompt.AutoSize = true;
            this.label_login_prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login_prompt.Location = new System.Drawing.Point(135, 9);
            this.label_login_prompt.Name = "label_login_prompt";
            this.label_login_prompt.Size = new System.Drawing.Size(168, 16);
            this.label_login_prompt.TabIndex = 4;
            this.label_login_prompt.Text = "Zaloguj się do systemu";
            // 
            // button_log_in
            // 
            this.button_log_in.Location = new System.Drawing.Point(120, 149);
            this.button_log_in.Name = "button_log_in";
            this.button_log_in.Size = new System.Drawing.Size(75, 23);
            this.button_log_in.TabIndex = 5;
            this.button_log_in.Text = "Zaloguj";
            this.button_log_in.UseVisualStyleBackColor = true;
            this.button_log_in.Click += new System.EventHandler(this.button_log_in_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 194);
            this.Controls.Add(this.button_log_in);
            this.Controls.Add(this.label_login_prompt);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_user);
            this.Name = "LogIn";
            this.Text = "ASK6 Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_login_prompt;
        private System.Windows.Forms.Button button_log_in;
    }
}