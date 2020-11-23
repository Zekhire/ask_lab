namespace Kalkulator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.seven = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.pt = new System.Windows.Forms.Button();
            this.ans = new System.Windows.Forms.Button();
            this.ADD = new System.Windows.Forms.Button();
            this.SUB = new System.Windows.Forms.Button();
            this.MUL = new System.Windows.Forms.Button();
            this.DIV = new System.Windows.Forms.Button();
            this.Answ_box = new System.Windows.Forms.TextBox();
            this.equation = new System.Windows.Forms.Label();
            this.clear_all = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Theme_selector = new System.Windows.Forms.ToolStripDropDownButton();
            this.Normal_threme = new System.Windows.Forms.ToolStripMenuItem();
            this.dark_theme = new System.Windows.Forms.ToolStripMenuItem();
            this.shrek_theme = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // seven
            // 
            this.seven.Location = new System.Drawing.Point(28, 98);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(41, 24);
            this.seven.TabIndex = 0;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = true;
            this.seven.Click += new System.EventHandler(this.seven_Click);
            // 
            // eight
            // 
            this.eight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.eight.Location = new System.Drawing.Point(75, 98);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(41, 24);
            this.eight.TabIndex = 1;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = true;
            this.eight.Click += new System.EventHandler(this.eight_Click);
            // 
            // nine
            // 
            this.nine.Location = new System.Drawing.Point(122, 98);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(41, 24);
            this.nine.TabIndex = 2;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = true;
            this.nine.Click += new System.EventHandler(this.nine_Click);
            // 
            // four
            // 
            this.four.Location = new System.Drawing.Point(28, 128);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(41, 24);
            this.four.TabIndex = 3;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            this.four.Click += new System.EventHandler(this.four_Click);
            // 
            // five
            // 
            this.five.Location = new System.Drawing.Point(75, 128);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(41, 24);
            this.five.TabIndex = 4;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = true;
            this.five.Click += new System.EventHandler(this.five_Click);
            // 
            // six
            // 
            this.six.Location = new System.Drawing.Point(122, 128);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(41, 24);
            this.six.TabIndex = 5;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = true;
            this.six.Click += new System.EventHandler(this.six_Click);
            // 
            // one
            // 
            this.one.Location = new System.Drawing.Point(28, 158);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(41, 24);
            this.one.TabIndex = 6;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            this.one.Click += new System.EventHandler(this.one_Click);
            // 
            // two
            // 
            this.two.Location = new System.Drawing.Point(75, 158);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(41, 24);
            this.two.TabIndex = 7;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            this.two.Click += new System.EventHandler(this.two_Click);
            // 
            // three
            // 
            this.three.Location = new System.Drawing.Point(122, 158);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(41, 24);
            this.three.TabIndex = 8;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            this.three.Click += new System.EventHandler(this.three_Click);
            // 
            // zero
            // 
            this.zero.Location = new System.Drawing.Point(28, 188);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(41, 24);
            this.zero.TabIndex = 9;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = true;
            this.zero.Click += new System.EventHandler(this.zero_Click);
            // 
            // pt
            // 
            this.pt.Location = new System.Drawing.Point(75, 188);
            this.pt.Name = "pt";
            this.pt.Size = new System.Drawing.Size(41, 24);
            this.pt.TabIndex = 10;
            this.pt.Text = ",";
            this.pt.UseVisualStyleBackColor = true;
            this.pt.Click += new System.EventHandler(this.pt_Click);
            // 
            // ans
            // 
            this.ans.Location = new System.Drawing.Point(122, 188);
            this.ans.Name = "ans";
            this.ans.Size = new System.Drawing.Size(41, 24);
            this.ans.TabIndex = 11;
            this.ans.Text = "ANS";
            this.ans.UseVisualStyleBackColor = true;
            this.ans.Click += new System.EventHandler(this.ans_Click);
            // 
            // ADD
            // 
            this.ADD.Location = new System.Drawing.Point(169, 98);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(41, 24);
            this.ADD.TabIndex = 13;
            this.ADD.Text = "+";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // SUB
            // 
            this.SUB.Location = new System.Drawing.Point(169, 128);
            this.SUB.Name = "SUB";
            this.SUB.Size = new System.Drawing.Size(41, 24);
            this.SUB.TabIndex = 14;
            this.SUB.Text = "-";
            this.SUB.UseVisualStyleBackColor = true;
            this.SUB.Click += new System.EventHandler(this.SUB_Click);
            // 
            // MUL
            // 
            this.MUL.Location = new System.Drawing.Point(169, 158);
            this.MUL.Name = "MUL";
            this.MUL.Size = new System.Drawing.Size(41, 24);
            this.MUL.TabIndex = 15;
            this.MUL.Text = "*";
            this.MUL.UseVisualStyleBackColor = true;
            this.MUL.Click += new System.EventHandler(this.MUL_Click);
            // 
            // DIV
            // 
            this.DIV.Location = new System.Drawing.Point(169, 188);
            this.DIV.Name = "DIV";
            this.DIV.Size = new System.Drawing.Size(41, 24);
            this.DIV.TabIndex = 16;
            this.DIV.Text = "/";
            this.DIV.UseVisualStyleBackColor = true;
            this.DIV.Click += new System.EventHandler(this.DIV_Click);
            // 
            // Answ_box
            // 
            this.Answ_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Answ_box.Location = new System.Drawing.Point(28, 37);
            this.Answ_box.Name = "Answ_box";
            this.Answ_box.ReadOnly = true;
            this.Answ_box.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Answ_box.Size = new System.Drawing.Size(182, 23);
            this.Answ_box.TabIndex = 17;
            this.Answ_box.TextChanged += new System.EventHandler(this.Answ_box_TextChanged);
            // 
            // equation
            // 
            this.equation.AutoSize = true;
            this.equation.Cursor = System.Windows.Forms.Cursors.Default;
            this.equation.Location = new System.Drawing.Point(25, 9);
            this.equation.Name = "equation";
            this.equation.Size = new System.Drawing.Size(0, 13);
            this.equation.TabIndex = 18;
            // 
            // clear_all
            // 
            this.clear_all.Location = new System.Drawing.Point(28, 66);
            this.clear_all.Name = "clear_all";
            this.clear_all.Size = new System.Drawing.Size(88, 26);
            this.clear_all.TabIndex = 19;
            this.clear_all.Text = "clear all";
            this.clear_all.UseVisualStyleBackColor = true;
            this.clear_all.Click += new System.EventHandler(this.clear_all_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(122, 66);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(88, 26);
            this.clear.TabIndex = 20;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Theme_selector});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(239, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Theme_selector
            // 
            this.Theme_selector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Theme_selector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Normal_threme,
            this.dark_theme,
            this.shrek_theme});
            this.Theme_selector.Image = ((System.Drawing.Image)(resources.GetObject("Theme_selector.Image")));
            this.Theme_selector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Theme_selector.Name = "Theme_selector";
            this.Theme_selector.Size = new System.Drawing.Size(57, 22);
            this.Theme_selector.Text = "Theme";
            // 
            // Normal_threme
            // 
            this.Normal_threme.Name = "Normal_threme";
            this.Normal_threme.Size = new System.Drawing.Size(114, 22);
            this.Normal_threme.Text = "Normal";
            this.Normal_threme.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // dark_theme
            // 
            this.dark_theme.Name = "dark_theme";
            this.dark_theme.Size = new System.Drawing.Size(114, 22);
            this.dark_theme.Text = "Dark";
            this.dark_theme.Click += new System.EventHandler(this.dark_theme_Click);
            // 
            // shrek_theme
            // 
            this.shrek_theme.Name = "shrek_theme";
            this.shrek_theme.Size = new System.Drawing.Size(114, 22);
            this.shrek_theme.Text = "Shrek";
            this.shrek_theme.Click += new System.EventHandler(this.shrek_theme_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(59, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 31);
            this.label1.TabIndex = 22;
            this.label1.Text = "00:00:00";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(239, 260);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.clear_all);
            this.Controls.Add(this.equation);
            this.Controls.Add(this.Answ_box);
            this.Controls.Add(this.DIV);
            this.Controls.Add(this.MUL);
            this.Controls.Add(this.SUB);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.ans);
            this.Controls.Add(this.pt);
            this.Controls.Add(this.zero);
            this.Controls.Add(this.three);
            this.Controls.Add(this.two);
            this.Controls.Add(this.one);
            this.Controls.Add(this.six);
            this.Controls.Add(this.five);
            this.Controls.Add(this.four);
            this.Controls.Add(this.nine);
            this.Controls.Add(this.eight);
            this.Controls.Add(this.seven);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button pt;
        private System.Windows.Forms.Button ans;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.Button SUB;
        private System.Windows.Forms.Button MUL;
        private System.Windows.Forms.Button DIV;
        private System.Windows.Forms.TextBox Answ_box;
        private System.Windows.Forms.Label equation;
        private System.Windows.Forms.Button clear_all;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Theme_selector;
        private System.Windows.Forms.ToolStripMenuItem Normal_threme;
        private System.Windows.Forms.ToolStripMenuItem dark_theme;
        private System.Windows.Forms.ToolStripMenuItem shrek_theme;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label label1;
    }
}

