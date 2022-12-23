namespace TermProject.Winform
{
    partial class MainForm
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.GameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PassBut = new System.Windows.Forms.Button();
            this.UndoBut = new System.Windows.Forms.Button();
            this.RestartBut = new System.Windows.Forms.Button();
            this.ResignationBut = new System.Windows.Forms.Button();
            this.Name1 = new System.Windows.Forms.Label();
            this.Count1 = new System.Windows.Forms.Label();
            this.Win1 = new System.Windows.Forms.Label();
            this.Win2 = new System.Windows.Forms.Label();
            this.Count2 = new System.Windows.Forms.Label();
            this.Name2 = new System.Windows.Forms.Label();
            this.ShowWin1 = new System.Windows.Forms.Label();
            this.ShowCount1 = new System.Windows.Forms.Label();
            this.ShowName1 = new System.Windows.Forms.Label();
            this.ShowWin2 = new System.Windows.Forms.Label();
            this.ShowCount2 = new System.Windows.Forms.Label();
            this.ShowName2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenu,
            this.restartToolStripMenuItem,
            this.startToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(626, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // GameMenu
            // 
            this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.startRecordToolStripMenuItem});
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(39, 22);
            this.GameMenu.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // startRecordToolStripMenuItem
            // 
            this.startRecordToolStripMenuItem.Name = "startRecordToolStripMenuItem";
            this.startRecordToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.startRecordToolStripMenuItem.Text = "Start Record";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // PassBut
            // 
            this.PassBut.Location = new System.Drawing.Point(459, 67);
            this.PassBut.Margin = new System.Windows.Forms.Padding(1);
            this.PassBut.Name = "PassBut";
            this.PassBut.Size = new System.Drawing.Size(74, 20);
            this.PassBut.TabIndex = 2;
            this.PassBut.Text = "Pass";
            this.PassBut.UseVisualStyleBackColor = true;
            this.PassBut.Click += new System.EventHandler(this.PassBut_Click);
            // 
            // UndoBut
            // 
            this.UndoBut.Location = new System.Drawing.Point(459, 104);
            this.UndoBut.Margin = new System.Windows.Forms.Padding(1);
            this.UndoBut.Name = "UndoBut";
            this.UndoBut.Size = new System.Drawing.Size(74, 23);
            this.UndoBut.TabIndex = 3;
            this.UndoBut.Text = "Undo";
            this.UndoBut.UseVisualStyleBackColor = true;
            this.UndoBut.Click += new System.EventHandler(this.UndoBut_Click);
            // 
            // RestartBut
            // 
            this.RestartBut.Location = new System.Drawing.Point(459, 191);
            this.RestartBut.Margin = new System.Windows.Forms.Padding(1);
            this.RestartBut.Name = "RestartBut";
            this.RestartBut.Size = new System.Drawing.Size(74, 28);
            this.RestartBut.TabIndex = 4;
            this.RestartBut.Text = "Restart";
            this.RestartBut.UseVisualStyleBackColor = true;
            this.RestartBut.Click += new System.EventHandler(this.RestartBut_Click);
            // 
            // ResignationBut
            // 
            this.ResignationBut.Location = new System.Drawing.Point(459, 146);
            this.ResignationBut.Margin = new System.Windows.Forms.Padding(1);
            this.ResignationBut.Name = "ResignationBut";
            this.ResignationBut.Size = new System.Drawing.Size(74, 27);
            this.ResignationBut.TabIndex = 5;
            this.ResignationBut.Text = "Resignation";
            this.ResignationBut.UseVisualStyleBackColor = true;
            this.ResignationBut.Click += new System.EventHandler(this.ResignationBut_Click);
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Location = new System.Drawing.Point(504, 265);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(29, 12);
            this.Name1.TabIndex = 6;
            this.Name1.Text = "Name";
            // 
            // Count1
            // 
            this.Count1.AutoSize = true;
            this.Count1.Location = new System.Drawing.Point(504, 281);
            this.Count1.Name = "Count1";
            this.Count1.Size = new System.Drawing.Size(35, 12);
            this.Count1.TabIndex = 7;
            this.Count1.Text = "Total";
            // 
            // Win1
            // 
            this.Win1.AutoSize = true;
            this.Win1.Location = new System.Drawing.Point(504, 297);
            this.Win1.Name = "Win1";
            this.Win1.Size = new System.Drawing.Size(23, 12);
            this.Win1.TabIndex = 8;
            this.Win1.Text = "Win";
            // 
            // Win2
            // 
            this.Win2.AutoSize = true;
            this.Win2.Location = new System.Drawing.Point(504, 357);
            this.Win2.Name = "Win2";
            this.Win2.Size = new System.Drawing.Size(23, 12);
            this.Win2.TabIndex = 11;
            this.Win2.Text = "Win";
            // 
            // Count2
            // 
            this.Count2.AutoSize = true;
            this.Count2.Location = new System.Drawing.Point(504, 341);
            this.Count2.Name = "Count2";
            this.Count2.Size = new System.Drawing.Size(35, 12);
            this.Count2.TabIndex = 10;
            this.Count2.Text = "Total";
            // 
            // Name2
            // 
            this.Name2.AutoSize = true;
            this.Name2.Location = new System.Drawing.Point(504, 325);
            this.Name2.Name = "Name2";
            this.Name2.Size = new System.Drawing.Size(29, 12);
            this.Name2.TabIndex = 9;
            this.Name2.Text = "Name";
            // 
            // ShowWin1
            // 
            this.ShowWin1.AutoSize = true;
            this.ShowWin1.Location = new System.Drawing.Point(547, 297);
            this.ShowWin1.Name = "ShowWin1";
            this.ShowWin1.Size = new System.Drawing.Size(17, 12);
            this.ShowWin1.TabIndex = 14;
            this.ShowWin1.Text = "--";
            // 
            // ShowCount1
            // 
            this.ShowCount1.AutoSize = true;
            this.ShowCount1.Location = new System.Drawing.Point(547, 281);
            this.ShowCount1.Name = "ShowCount1";
            this.ShowCount1.Size = new System.Drawing.Size(17, 12);
            this.ShowCount1.TabIndex = 13;
            this.ShowCount1.Text = "--";
            // 
            // ShowName1
            // 
            this.ShowName1.AutoSize = true;
            this.ShowName1.Location = new System.Drawing.Point(547, 265);
            this.ShowName1.Name = "ShowName1";
            this.ShowName1.Size = new System.Drawing.Size(17, 12);
            this.ShowName1.TabIndex = 12;
            this.ShowName1.Text = "--";
            // 
            // ShowWin2
            // 
            this.ShowWin2.AutoSize = true;
            this.ShowWin2.Location = new System.Drawing.Point(547, 357);
            this.ShowWin2.Name = "ShowWin2";
            this.ShowWin2.Size = new System.Drawing.Size(17, 12);
            this.ShowWin2.TabIndex = 17;
            this.ShowWin2.Text = "--";
            // 
            // ShowCount2
            // 
            this.ShowCount2.AutoSize = true;
            this.ShowCount2.Location = new System.Drawing.Point(547, 341);
            this.ShowCount2.Name = "ShowCount2";
            this.ShowCount2.Size = new System.Drawing.Size(17, 12);
            this.ShowCount2.TabIndex = 16;
            this.ShowCount2.Text = "--";
            // 
            // ShowName2
            // 
            this.ShowName2.AutoSize = true;
            this.ShowName2.Location = new System.Drawing.Point(547, 325);
            this.ShowName2.Name = "ShowName2";
            this.ShowName2.Size = new System.Drawing.Size(17, 12);
            this.ShowName2.TabIndex = 15;
            this.ShowName2.Text = "--";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(434, 265);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(434, 325);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 496);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = ".";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(626, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ShowWin2);
            this.Controls.Add(this.ShowCount2);
            this.Controls.Add(this.ShowName2);
            this.Controls.Add(this.ShowWin1);
            this.Controls.Add(this.ShowCount1);
            this.Controls.Add(this.ShowName1);
            this.Controls.Add(this.Win2);
            this.Controls.Add(this.Count2);
            this.Controls.Add(this.Name2);
            this.Controls.Add(this.Win1);
            this.Controls.Add(this.Count1);
            this.Controls.Add(this.Name1);
            this.Controls.Add(this.ResignationBut);
            this.Controls.Add(this.RestartBut);
            this.Controls.Add(this.UndoBut);
            this.Controls.Add(this.PassBut);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(944, 959);
            this.MinimumSize = new System.Drawing.Size(44, 60);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem GameMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button PassBut;
        private System.Windows.Forms.Button UndoBut;
        private System.Windows.Forms.Button RestartBut;
        private System.Windows.Forms.Button ResignationBut;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.Label Name1;
        private System.Windows.Forms.Label Count1;
        private System.Windows.Forms.Label Win1;
        private System.Windows.Forms.Label Win2;
        private System.Windows.Forms.Label Count2;
        private System.Windows.Forms.Label Name2;
        private System.Windows.Forms.Label ShowWin1;
        private System.Windows.Forms.Label ShowCount1;
        private System.Windows.Forms.Label ShowName1;
        private System.Windows.Forms.Label ShowWin2;
        private System.Windows.Forms.Label ShowCount2;
        private System.Windows.Forms.Label ShowName2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem startRecordToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}