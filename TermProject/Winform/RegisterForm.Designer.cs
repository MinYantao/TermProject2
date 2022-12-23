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
            this.pictureBox1.Location = new System.Drawing.Point(92, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Rbutton1
            // 
            this.Rbutton1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbutton1.Location = new System.Drawing.Point(68, 200);
            this.Rbutton1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Rbutton1.Name = "Rbutton1";
            this.Rbutton1.Size = new System.Drawing.Size(130, 25);
            this.Rbutton1.TabIndex = 14;
            this.Rbutton1.Text = "Register";
            this.Rbutton1.UseVisualStyleBackColor = true;
            this.Rbutton1.Click += new System.EventHandler(this.Rbutton1_Click);
            // 
            // Passtext1
            // 
            this.Passtext1.Location = new System.Drawing.Point(132, 144);
            this.Passtext1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Passtext1.Name = "Passtext1";
            this.Passtext1.PasswordChar = '*';
            this.Passtext1.Size = new System.Drawing.Size(104, 21);
            this.Passtext1.TabIndex = 13;
            // 
            // Nametext1
            // 
            this.Nametext1.Location = new System.Drawing.Point(132, 122);
            this.Nametext1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Nametext1.Name = "Nametext1";
            this.Nametext1.Size = new System.Drawing.Size(104, 21);
            this.Nametext1.TabIndex = 12;
            // 
            // Passlabel1
            // 
            this.Passlabel1.AutoSize = true;
            this.Passlabel1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passlabel1.Location = new System.Drawing.Point(10, 147);
            this.Passlabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Passlabel1.Name = "Passlabel1";
            this.Passlabel1.Size = new System.Drawing.Size(50, 16);
            this.Passlabel1.TabIndex = 11;
            this.Passlabel1.Text = "Password";
            // 
            // Namelabel1
            // 
            this.Namelabel1.AutoSize = true;
            this.Namelabel1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelabel1.Location = new System.Drawing.Point(12, 125);
            this.Namelabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Namelabel1.Name = "Namelabel1";
            this.Namelabel1.Size = new System.Drawing.Size(35, 16);
            this.Namelabel1.TabIndex = 10;
            this.Namelabel1.Text = "Name";
            // 
            // Passtext2
            // 
            this.Passtext2.Location = new System.Drawing.Point(132, 167);
            this.Passtext2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Passtext2.Name = "Passtext2";
            this.Passtext2.PasswordChar = '*';
            this.Passtext2.Size = new System.Drawing.Size(104, 21);
            this.Passtext2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 170);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm Password";
            // 
            // UpLoadbtn
            // 
            this.UpLoadbtn.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpLoadbtn.Location = new System.Drawing.Point(184, 76);
            this.UpLoadbtn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.UpLoadbtn.Name = "UpLoadbtn";
            this.UpLoadbtn.Size = new System.Drawing.Size(61, 27);
            this.UpLoadbtn.TabIndex = 17;
            this.UpLoadbtn.Text = "Up Load";
            this.UpLoadbtn.UseVisualStyleBackColor = true;
            this.UpLoadbtn.Click += new System.EventHandler(this.UpLoadbtn_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(282, 234);
            this.Controls.Add(this.UpLoadbtn);
            this.Controls.Add(this.Passtext2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rbutton1);
            this.Controls.Add(this.Passtext1);
            this.Controls.Add(this.Nametext1);
            this.Controls.Add(this.Passlabel1);
            this.Controls.Add(this.Namelabel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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