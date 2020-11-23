namespace ASK4
{
    partial class Form1
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
            this.send = new System.Windows.Forms.Button();
            this.sender_TB = new System.Windows.Forms.TextBox();
            this.sender = new System.Windows.Forms.Label();
            this.chain = new System.Windows.Forms.Label();
            this.receiver = new System.Windows.Forms.Label();
            this.chain_TB = new System.Windows.Forms.TextBox();
            this.receiver_TB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.AllowDrop = true;
            this.send.Location = new System.Drawing.Point(21, 253);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(370, 34);
            this.send.TabIndex = 0;
            this.send.Text = "wyślij";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // sender_TB
            // 
            this.sender_TB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sender_TB.Location = new System.Drawing.Point(21, 37);
            this.sender_TB.Multiline = true;
            this.sender_TB.Name = "sender_TB";
            this.sender_TB.Size = new System.Drawing.Size(370, 210);
            this.sender_TB.TabIndex = 1;
            this.sender_TB.TextChanged += new System.EventHandler(this.sender_TB_TextChanged);
            // 
            // sender
            // 
            this.sender.Location = new System.Drawing.Point(21, 9);
            this.sender.Name = "sender";
            this.sender.Size = new System.Drawing.Size(370, 20);
            this.sender.TabIndex = 4;
            this.sender.Text = "nadajnik";
            this.sender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chain
            // 
            this.chain.Cursor = System.Windows.Forms.Cursors.Default;
            this.chain.Location = new System.Drawing.Point(406, 9);
            this.chain.Name = "chain";
            this.chain.Size = new System.Drawing.Size(370, 20);
            this.chain.TabIndex = 5;
            this.chain.Text = "łańcuch bitów";
            this.chain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // receiver
            // 
            this.receiver.Location = new System.Drawing.Point(791, 14);
            this.receiver.Name = "receiver";
            this.receiver.Size = new System.Drawing.Size(370, 20);
            this.receiver.TabIndex = 6;
            this.receiver.Text = "odbiornik";
            this.receiver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chain_TB
            // 
            this.chain_TB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chain_TB.Location = new System.Drawing.Point(406, 37);
            this.chain_TB.Multiline = true;
            this.chain_TB.Name = "chain_TB";
            this.chain_TB.ReadOnly = true;
            this.chain_TB.Size = new System.Drawing.Size(370, 210);
            this.chain_TB.TabIndex = 7;
            // 
            // receiver_TB
            // 
            this.receiver_TB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.receiver_TB.Location = new System.Drawing.Point(791, 37);
            this.receiver_TB.Multiline = true;
            this.receiver_TB.Name = "receiver_TB";
            this.receiver_TB.ReadOnly = true;
            this.receiver_TB.Size = new System.Drawing.Size(370, 210);
            this.receiver_TB.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1184, 321);
            this.Controls.Add(this.receiver_TB);
            this.Controls.Add(this.chain_TB);
            this.Controls.Add(this.receiver);
            this.Controls.Add(this.chain);
            this.Controls.Add(this.sender);
            this.Controls.Add(this.sender_TB);
            this.Controls.Add(this.send);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Komunikajka";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox sender_TB;
        private System.Windows.Forms.Label sender;
        private System.Windows.Forms.Label chain;
        private System.Windows.Forms.Label receiver;
        private System.Windows.Forms.TextBox chain_TB;
        private System.Windows.Forms.TextBox receiver_TB;
    }
}

