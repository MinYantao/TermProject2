namespace TermProject.Winform
{
    partial class RegisterForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Rbutton1 = new System.Windows.Forms.Button();
            this.Passtext1 = new System.Windows.Forms.TextBox();
            this.Nametext1 = new System.Windows.Forms.TextBox();
            this.Passlabel1 = new System.Windows.Forms.Label();
            this.Namelabel1 = new System.Windows.Forms.Label();
            this.Passtext2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UpLoadbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(383, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 241);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Rbutton1
            // 
            this.Rbutton1.Location = new System.Drawing.Point(308, 687);
            this.Rbutton1.Name = "Rbutton1";
            this.Rbutton1.Size = new System.Drawing.Size(390, 75);
            this.Rbutton1.TabIndex = 14;
            this.Rbutton1.Text = "Register";
            this.Rbutton1.UseVisualStyleBackColor = true;
            this.Rbutton1.Click += new System.EventHandler(this.Rbutton1_Click);
            // 
            // Passtext1
            // 
            this.Passtext1.Location = new System.Drawing.Point(521, 501);
            this.Passtext1.Name = "Passtext1";
            this.Passtext1.Size = new System.Drawing.Size(305, 49);
            this.Passtext1.TabIndex = 13;
            // 
            // Nametext1
            // 
            this.Nametext1.Location = new System.Drawing.Point(521, 435);
            this.Nametext1.Name = "Nametext1";
            this.Nametext1.Size = new System.Drawing.Size(305, 49);
            this.Nametext1.TabIndex = 12;
            // 
            // Passlabel1
            // 
            this.Passlabel1.AutoSize = true;
            this.Passlabel1.Location = new System.Drawing.Point(166, 514);
            this.Passlabel1.Name = "Passlabel1";
            this.Passlabel1.Size = new System.Drawing.Size(159, 36);
            this.Passlabel1.TabIndex = 11;
            this.Passlabel1.Text = "Password";
            // 
            // Namelabel1
            // 
            this.Namelabel1.AutoSize = true;
            this.Namelabel1.Location = new System.Drawing.Point(166, 448);
            this.Namelabel1.Name = "Namelabel1";
            this.Namelabel1.Size = new System.Drawing.Size(87, 36);
            this.Namelabel1.TabIndex = 10;
            this.Namelabel1.Text = "Name";
            // 
            // Passtext2
            // 
            this.Passtext2.Location = new System.Drawing.Point(521, 570);
            this.Passtext2.Name = "Passtext2";
            this.Passtext2.Size = new System.Drawing.Size(305, 49);
            this.Passtext2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 570);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 36);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm Password";
            // 
            // UpLoadbtn
            // 
            this.UpLoadbtn.Location = new System.Drawing.Point(681, 302);
            this.UpLoadbtn.Name = "UpLoadbtn";
            this.UpLoadbtn.Size = new System.Drawing.Size(155, 60);
            this.UpLoadbtn.TabIndex = 17;
            this.UpLoadbtn.Text = "Up Load";
            this.UpLoadbtn.UseVisualStyleBackColor = true;
            this.UpLoadbtn.Click += new System.EventHandler(this.UpLoadbtn_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 880);
            this.Controls.Add(this.UpLoadbtn);
            this.Controls.Add(this.Passtext2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rbutton1);
            this.Controls.Add(this.Passtext1);
            this.Controls.Add(this.Nametext1);
            this.Controls.Add(this.Passlabel1);
            this.Controls.Add(this.Namelabel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Rbutton1;
        private System.Windows.Forms.TextBox Passtext1;
        private System.Windows.Forms.TextBox Nametext1;
        private System.Windows.Forms.Label Passlabel1;
        private System.Windows.Forms.Label Namelabel1;
        private System.Windows.Forms.TextBox Passtext2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpLoadbtn;
    }
}