namespace TermProject.Winform
{
    partial class LogForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AIbutton1 = new System.Windows.Forms.Button();
            this.Logbutton1 = new System.Windows.Forms.Button();
            this.Notbutton1 = new System.Windows.Forms.Button();
            this.Passtext1 = new System.Windows.Forms.TextBox();
            this.Nametext1 = new System.Windows.Forms.TextBox();
            this.Passlabel1 = new System.Windows.Forms.Label();
            this.Namelabel1 = new System.Windows.Forms.Label();
            this.User1 = new System.Windows.Forms.PictureBox();
            this.AIbutton2 = new System.Windows.Forms.Button();
            this.Logbutton2 = new System.Windows.Forms.Button();
            this.Notbutton2 = new System.Windows.Forms.Button();
            this.Passtext2 = new System.Windows.Forms.TextBox();
            this.Nametext2 = new System.Windows.Forms.TextBox();
            this.Passlabel2 = new System.Windows.Forms.Label();
            this.Namelabel2 = new System.Windows.Forms.Label();
            this.User2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AIbutton1);
            this.splitContainer1.Panel1.Controls.Add(this.Logbutton1);
            this.splitContainer1.Panel1.Controls.Add(this.Notbutton1);
            this.splitContainer1.Panel1.Controls.Add(this.Passtext1);
            this.splitContainer1.Panel1.Controls.Add(this.Nametext1);
            this.splitContainer1.Panel1.Controls.Add(this.Passlabel1);
            this.splitContainer1.Panel1.Controls.Add(this.Namelabel1);
            this.splitContainer1.Panel1.Controls.Add(this.User1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AIbutton2);
            this.splitContainer1.Panel2.Controls.Add(this.Logbutton2);
            this.splitContainer1.Panel2.Controls.Add(this.Notbutton2);
            this.splitContainer1.Panel2.Controls.Add(this.Passtext2);
            this.splitContainer1.Panel2.Controls.Add(this.Nametext2);
            this.splitContainer1.Panel2.Controls.Add(this.Passlabel2);
            this.splitContainer1.Panel2.Controls.Add(this.Namelabel2);
            this.splitContainer1.Panel2.Controls.Add(this.User2);
            this.splitContainer1.Size = new System.Drawing.Size(428, 234);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // AIbutton1
            // 
            this.AIbutton1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AIbutton1.Location = new System.Drawing.Point(11, 10);
            this.AIbutton1.Margin = new System.Windows.Forms.Padding(1);
            this.AIbutton1.Name = "AIbutton1";
            this.AIbutton1.Size = new System.Drawing.Size(54, 27);
            this.AIbutton1.TabIndex = 10;
            this.AIbutton1.Text = "AI";
            this.AIbutton1.UseVisualStyleBackColor = true;
            this.AIbutton1.Click += new System.EventHandler(this.AIbutton1_Click);
            // 
            // Logbutton1
            // 
            this.Logbutton1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logbutton1.Location = new System.Drawing.Point(122, 194);
            this.Logbutton1.Margin = new System.Windows.Forms.Padding(1);
            this.Logbutton1.Name = "Logbutton1";
            this.Logbutton1.Size = new System.Drawing.Size(45, 22);
            this.Logbutton1.TabIndex = 8;
            this.Logbutton1.Text = "Log";
            this.Logbutton1.UseVisualStyleBackColor = true;
            this.Logbutton1.Click += new System.EventHandler(this.Logbutton1_Click);
            // 
            // Notbutton1
            // 
            this.Notbutton1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notbutton1.Location = new System.Drawing.Point(24, 194);
            this.Notbutton1.Margin = new System.Windows.Forms.Padding(1);
            this.Notbutton1.Name = "Notbutton1";
            this.Notbutton1.Size = new System.Drawing.Size(64, 22);
            this.Notbutton1.TabIndex = 7;
            this.Notbutton1.Text = "Not Log";
            this.Notbutton1.UseVisualStyleBackColor = true;
            this.Notbutton1.Click += new System.EventHandler(this.Notbutton1_Click);
            // 
            // Passtext1
            // 
            this.Passtext1.Location = new System.Drawing.Point(106, 166);
            this.Passtext1.Margin = new System.Windows.Forms.Padding(1);
            this.Passtext1.Name = "Passtext1";
            this.Passtext1.PasswordChar = '*';
            this.Passtext1.Size = new System.Drawing.Size(64, 21);
            this.Passtext1.TabIndex = 6;
            // 
            // Nametext1
            // 
            this.Nametext1.Location = new System.Drawing.Point(106, 144);
            this.Nametext1.Margin = new System.Windows.Forms.Padding(1);
            this.Nametext1.Name = "Nametext1";
            this.Nametext1.Size = new System.Drawing.Size(64, 21);
            this.Nametext1.TabIndex = 5;
            // 
            // Passlabel1
            // 
            this.Passlabel1.AutoSize = true;
            this.Passlabel1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passlabel1.Location = new System.Drawing.Point(35, 166);
            this.Passlabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Passlabel1.Name = "Passlabel1";
            this.Passlabel1.Size = new System.Drawing.Size(50, 16);
            this.Passlabel1.TabIndex = 4;
            this.Passlabel1.Text = "Password";
            // 
            // Namelabel1
            // 
            this.Namelabel1.AutoSize = true;
            this.Namelabel1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelabel1.Location = new System.Drawing.Point(35, 144);
            this.Namelabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Namelabel1.Name = "Namelabel1";
            this.Namelabel1.Size = new System.Drawing.Size(35, 16);
            this.Namelabel1.TabIndex = 3;
            this.Namelabel1.Text = "Name";
            // 
            // User1
            // 
            this.User1.Location = new System.Drawing.Point(71, 52);
            this.User1.Margin = new System.Windows.Forms.Padding(1);
            this.User1.Name = "User1";
            this.User1.Size = new System.Drawing.Size(73, 73);
            this.User1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.User1.TabIndex = 0;
            this.User1.TabStop = false;
            // 
            // AIbutton2
            // 
            this.AIbutton2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AIbutton2.Location = new System.Drawing.Point(20, 10);
            this.AIbutton2.Margin = new System.Windows.Forms.Padding(1);
            this.AIbutton2.Name = "AIbutton2";
            this.AIbutton2.Size = new System.Drawing.Size(54, 27);
            this.AIbutton2.TabIndex = 11;
            this.AIbutton2.Text = "AI";
            this.AIbutton2.UseVisualStyleBackColor = true;
            this.AIbutton2.Click += new System.EventHandler(this.AIbutton2_Click);
            // 
            // Logbutton2
            // 
            this.Logbutton2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logbutton2.Location = new System.Drawing.Point(135, 194);
            this.Logbutton2.Margin = new System.Windows.Forms.Padding(1);
            this.Logbutton2.Name = "Logbutton2";
            this.Logbutton2.Size = new System.Drawing.Size(45, 22);
            this.Logbutton2.TabIndex = 9;
            this.Logbutton2.Text = "Log";
            this.Logbutton2.UseVisualStyleBackColor = true;
            this.Logbutton2.Click += new System.EventHandler(this.Logbutton2_Click);
            // 
            // Notbutton2
            // 
            this.Notbutton2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notbutton2.Location = new System.Drawing.Point(40, 194);
            this.Notbutton2.Margin = new System.Windows.Forms.Padding(1);
            this.Notbutton2.Name = "Notbutton2";
            this.Notbutton2.Size = new System.Drawing.Size(66, 22);
            this.Notbutton2.TabIndex = 8;
            this.Notbutton2.Text = "Not Log";
            this.Notbutton2.UseVisualStyleBackColor = true;
            this.Notbutton2.Click += new System.EventHandler(this.Notbutton2_Click);
            // 
            // Passtext2
            // 
            this.Passtext2.Location = new System.Drawing.Point(119, 166);
            this.Passtext2.Margin = new System.Windows.Forms.Padding(1);
            this.Passtext2.Name = "Passtext2";
            this.Passtext2.PasswordChar = '*';
            this.Passtext2.Size = new System.Drawing.Size(64, 21);
            this.Passtext2.TabIndex = 7;
            // 
            // Nametext2
            // 
            this.Nametext2.Location = new System.Drawing.Point(119, 144);
            this.Nametext2.Margin = new System.Windows.Forms.Padding(1);
            this.Nametext2.Name = "Nametext2";
            this.Nametext2.Size = new System.Drawing.Size(64, 21);
            this.Nametext2.TabIndex = 6;
            // 
            // Passlabel2
            // 
            this.Passlabel2.AutoSize = true;
            this.Passlabel2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passlabel2.Location = new System.Drawing.Point(53, 166);
            this.Passlabel2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Passlabel2.Name = "Passlabel2";
            this.Passlabel2.Size = new System.Drawing.Size(50, 16);
            this.Passlabel2.TabIndex = 4;
            this.Passlabel2.Text = "Password";
            // 
            // Namelabel2
            // 
            this.Namelabel2.AutoSize = true;
            this.Namelabel2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelabel2.Location = new System.Drawing.Point(53, 144);
            this.Namelabel2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Namelabel2.Name = "Namelabel2";
            this.Namelabel2.Size = new System.Drawing.Size(35, 16);
            this.Namelabel2.TabIndex = 3;
            this.Namelabel2.Text = "Name";
            // 
            // User2
            // 
            this.User2.Location = new System.Drawing.Point(79, 52);
            this.User2.Margin = new System.Windows.Forms.Padding(1);
            this.User2.Name = "User2";
            this.User2.Size = new System.Drawing.Size(73, 73);
            this.User2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.User2.TabIndex = 0;
            this.User2.TabStop = false;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(428, 234);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.User1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button AIbutton1;
        private System.Windows.Forms.Button Logbutton1;
        private System.Windows.Forms.Button Notbutton1;
        private System.Windows.Forms.TextBox Passtext1;
        private System.Windows.Forms.TextBox Nametext1;
        private System.Windows.Forms.Label Passlabel1;
        private System.Windows.Forms.Label Namelabel1;
        private System.Windows.Forms.PictureBox User1;
        private System.Windows.Forms.Button AIbutton2;
        private System.Windows.Forms.Button Logbutton2;
        private System.Windows.Forms.Button Notbutton2;
        private System.Windows.Forms.TextBox Passtext2;
        private System.Windows.Forms.TextBox Nametext2;
        private System.Windows.Forms.Label Passlabel2;
        private System.Windows.Forms.Label Namelabel2;
        private System.Windows.Forms.PictureBox User2;
    }
}