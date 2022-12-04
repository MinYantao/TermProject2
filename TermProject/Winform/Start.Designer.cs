namespace TermProject.Winform
{
    partial class Start
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
            this.InputSize = new System.Windows.Forms.TextBox();
            this.StartSizelal = new System.Windows.Forms.Label();
            this.StartModelal = new System.Windows.Forms.Label();
            this.ModeChoose = new System.Windows.Forms.ComboBox();
            this.StartBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputSize
            // 
            this.InputSize.Location = new System.Drawing.Point(650, 158);
            this.InputSize.Name = "InputSize";
            this.InputSize.Size = new System.Drawing.Size(100, 49);
            this.InputSize.TabIndex = 0;
            this.InputSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputSize_KeyPress);
            // 
            // StartSizelal
            // 
            this.StartSizelal.AutoSize = true;
            this.StartSizelal.Location = new System.Drawing.Point(543, 161);
            this.StartSizelal.Name = "StartSizelal";
            this.StartSizelal.Size = new System.Drawing.Size(87, 36);
            this.StartSizelal.TabIndex = 1;
            this.StartSizelal.Text = "Size";
            // 
            // StartModelal
            // 
            this.StartModelal.AutoSize = true;
            this.StartModelal.Location = new System.Drawing.Point(90, 161);
            this.StartModelal.Name = "StartModelal";
            this.StartModelal.Size = new System.Drawing.Size(87, 36);
            this.StartModelal.TabIndex = 2;
            this.StartModelal.Text = "Mode";
            // 
            // ModeChoose
            // 
            this.ModeChoose.FormattingEnabled = true;
            this.ModeChoose.Items.AddRange(new object[] {
            "Go",
            "Five"});
            this.ModeChoose.Location = new System.Drawing.Point(198, 158);
            this.ModeChoose.Name = "ModeChoose";
            this.ModeChoose.Size = new System.Drawing.Size(121, 44);
            this.ModeChoose.TabIndex = 3;
            // 
            // StartBut
            // 
            this.StartBut.Location = new System.Drawing.Point(303, 275);
            this.StartBut.Name = "StartBut";
            this.StartBut.Size = new System.Drawing.Size(215, 86);
            this.StartBut.TabIndex = 4;
            this.StartBut.Text = "Start";
            this.StartBut.UseVisualStyleBackColor = true;
            this.StartBut.Click += new System.EventHandler(this.StartBut_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 450);
            this.Controls.Add(this.StartBut);
            this.Controls.Add(this.ModeChoose);
            this.Controls.Add(this.StartModelal);
            this.Controls.Add(this.StartSizelal);
            this.Controls.Add(this.InputSize);
            this.Name = "Start";
            this.Text = "Start";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputSize;
        private System.Windows.Forms.Label StartSizelal;
        private System.Windows.Forms.Label StartModelal;
        private System.Windows.Forms.ComboBox ModeChoose;
        private System.Windows.Forms.Button StartBut;
    }
}