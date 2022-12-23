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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.GameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label1 = new System.Windows.Forms.Label();
            this.Player1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.End = new System.Windows.Forms.Button();
            this.StartPlay = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RecordBtn = new System.Windows.Forms.Button();
            this.StopPlay = new System.Windows.Forms.Button();
            this.Modelbl = new System.Windows.Forms.Label();
            this.ModeShow = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenu,
            this.restartToolStripMenuItem,
            this.startToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(1878, 51);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // GameMenu
            // 
            this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.GameMenu.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(98, 45);
            this.GameMenu.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(286, 66);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(286, 66);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(146, 45);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(113, 45);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // PassBut
            // 
            this.PassBut.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassBut.Location = new System.Drawing.Point(1377, 201);
            this.PassBut.Name = "PassBut";
            this.PassBut.Size = new System.Drawing.Size(222, 60);
            this.PassBut.TabIndex = 2;
            this.PassBut.Text = "Pass";
            this.PassBut.UseVisualStyleBackColor = true;
            this.PassBut.Click += new System.EventHandler(this.PassBut_Click);
            // 
            // UndoBut
            // 
            this.UndoBut.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoBut.Location = new System.Drawing.Point(1377, 312);
            this.UndoBut.Name = "UndoBut";
            this.UndoBut.Size = new System.Drawing.Size(222, 69);
            this.UndoBut.TabIndex = 3;
            this.UndoBut.Text = "Undo";
            this.UndoBut.UseVisualStyleBackColor = true;
            this.UndoBut.Click += new System.EventHandler(this.UndoBut_Click);
            // 
            // RestartBut
            // 
            this.RestartBut.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartBut.Location = new System.Drawing.Point(1377, 573);
            this.RestartBut.Name = "RestartBut";
            this.RestartBut.Size = new System.Drawing.Size(222, 84);
            this.RestartBut.TabIndex = 4;
            this.RestartBut.Text = "Restart";
            this.RestartBut.UseVisualStyleBackColor = true;
            this.RestartBut.Click += new System.EventHandler(this.RestartBut_Click);
            // 
            // ResignationBut
            // 
            this.ResignationBut.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResignationBut.Location = new System.Drawing.Point(1377, 438);
            this.ResignationBut.Name = "ResignationBut";
            this.ResignationBut.Size = new System.Drawing.Size(222, 81);
            this.ResignationBut.TabIndex = 5;
            this.ResignationBut.Text = "Resignation";
            this.ResignationBut.UseVisualStyleBackColor = true;
            this.ResignationBut.Click += new System.EventHandler(this.ResignationBut_Click);
            // 
            // Name1
            // 
            this.Name1.AutoSize = true;
            this.Name1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name1.Location = new System.Drawing.Point(1512, 795);
            this.Name1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(103, 41);
            this.Name1.TabIndex = 6;
            this.Name1.Text = "Name";
            // 
            // Count1
            // 
            this.Count1.AutoSize = true;
            this.Count1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count1.Location = new System.Drawing.Point(1512, 843);
            this.Count1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.Count1.Name = "Count1";
            this.Count1.Size = new System.Drawing.Size(93, 41);
            this.Count1.TabIndex = 7;
            this.Count1.Text = "Total";
            // 
            // Win1
            // 
            this.Win1.AutoSize = true;
            this.Win1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Win1.Location = new System.Drawing.Point(1512, 891);
            this.Win1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.Win1.Name = "Win1";
            this.Win1.Size = new System.Drawing.Size(82, 41);
            this.Win1.TabIndex = 8;
            this.Win1.Text = "Win";
            // 
            // Win2
            // 
            this.Win2.AutoSize = true;
            this.Win2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Win2.Location = new System.Drawing.Point(1512, 1071);
            this.Win2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.Win2.Name = "Win2";
            this.Win2.Size = new System.Drawing.Size(82, 41);
            this.Win2.TabIndex = 11;
            this.Win2.Text = "Win";
            // 
            // Count2
            // 
            this.Count2.AutoSize = true;
            this.Count2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count2.Location = new System.Drawing.Point(1512, 1023);
            this.Count2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.Count2.Name = "Count2";
            this.Count2.Size = new System.Drawing.Size(93, 41);
            this.Count2.TabIndex = 10;
            this.Count2.Text = "Total";
            // 
            // Name2
            // 
            this.Name2.AutoSize = true;
            this.Name2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name2.Location = new System.Drawing.Point(1512, 975);
            this.Name2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.Name2.Name = "Name2";
            this.Name2.Size = new System.Drawing.Size(103, 41);
            this.Name2.TabIndex = 9;
            this.Name2.Text = "Name";
            // 
            // ShowWin1
            // 
            this.ShowWin1.AutoSize = true;
            this.ShowWin1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowWin1.Location = new System.Drawing.Point(1641, 891);
            this.ShowWin1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.ShowWin1.Name = "ShowWin1";
            this.ShowWin1.Size = new System.Drawing.Size(32, 41);
            this.ShowWin1.TabIndex = 14;
            this.ShowWin1.Text = "--";
            // 
            // ShowCount1
            // 
            this.ShowCount1.AutoSize = true;
            this.ShowCount1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowCount1.Location = new System.Drawing.Point(1641, 843);
            this.ShowCount1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.ShowCount1.Name = "ShowCount1";
            this.ShowCount1.Size = new System.Drawing.Size(32, 41);
            this.ShowCount1.TabIndex = 13;
            this.ShowCount1.Text = "--";
            // 
            // ShowName1
            // 
            this.ShowName1.AutoSize = true;
            this.ShowName1.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowName1.Location = new System.Drawing.Point(1641, 795);
            this.ShowName1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.ShowName1.Name = "ShowName1";
            this.ShowName1.Size = new System.Drawing.Size(32, 41);
            this.ShowName1.TabIndex = 12;
            this.ShowName1.Text = "--";
            // 
            // ShowWin2
            // 
            this.ShowWin2.AutoSize = true;
            this.ShowWin2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowWin2.Location = new System.Drawing.Point(1641, 1071);
            this.ShowWin2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.ShowWin2.Name = "ShowWin2";
            this.ShowWin2.Size = new System.Drawing.Size(32, 41);
            this.ShowWin2.TabIndex = 17;
            this.ShowWin2.Text = "--";
            // 
            // ShowCount2
            // 
            this.ShowCount2.AutoSize = true;
            this.ShowCount2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowCount2.Location = new System.Drawing.Point(1641, 1023);
            this.ShowCount2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.ShowCount2.Name = "ShowCount2";
            this.ShowCount2.Size = new System.Drawing.Size(32, 41);
            this.ShowCount2.TabIndex = 16;
            this.ShowCount2.Text = "--";
            // 
            // ShowName2
            // 
            this.ShowName2.AutoSize = true;
            this.ShowName2.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowName2.Location = new System.Drawing.Point(1641, 975);
            this.ShowName2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.ShowName2.Name = "ShowName2";
            this.ShowName2.Size = new System.Drawing.Size(32, 41);
            this.ShowName2.TabIndex = 15;
            this.ShowName2.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1347, 1488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 36);
            this.label1.TabIndex = 20;
            this.label1.Text = ".";
            // 
            // Player1
            // 
            this.Player1.Enabled = true;
            this.Player1.Location = new System.Drawing.Point(0, 52);
            this.Player1.Name = "Player1";
            this.Player1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player1.OcxState")));
            this.Player1.Size = new System.Drawing.Size(421, 445);
            this.Player1.TabIndex = 21;
            // 
            // End
            // 
            this.End.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.End.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.End.Location = new System.Drawing.Point(1656, 312);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(154, 69);
            this.End.TabIndex = 23;
            this.End.Text = "Finish";
            this.End.UseVisualStyleBackColor = true;
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // StartPlay
            // 
            this.StartPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartPlay.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPlay.Location = new System.Drawing.Point(1656, 438);
            this.StartPlay.Name = "StartPlay";
            this.StartPlay.Size = new System.Drawing.Size(154, 81);
            this.StartPlay.TabIndex = 22;
            this.StartPlay.Text = "Play";
            this.StartPlay.UseVisualStyleBackColor = true;
            this.StartPlay.Click += new System.EventHandler(this.StartPlay_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1302, 975);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(192, 150);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1302, 795);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // RecordBtn
            // 
            this.RecordBtn.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordBtn.Location = new System.Drawing.Point(1656, 201);
            this.RecordBtn.Name = "RecordBtn";
            this.RecordBtn.Size = new System.Drawing.Size(150, 60);
            this.RecordBtn.TabIndex = 24;
            this.RecordBtn.Text = "Record";
            this.RecordBtn.UseVisualStyleBackColor = true;
            this.RecordBtn.Click += new System.EventHandler(this.RecordBtn_Click);
            // 
            // StopPlay
            // 
            this.StopPlay.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopPlay.Location = new System.Drawing.Point(1656, 573);
            this.StopPlay.Name = "StopPlay";
            this.StopPlay.Size = new System.Drawing.Size(154, 84);
            this.StopPlay.TabIndex = 25;
            this.StopPlay.Text = "Stop";
            this.StopPlay.UseVisualStyleBackColor = true;
            this.StopPlay.Click += new System.EventHandler(this.StopPlay_Click);
            // 
            // Modelbl
            // 
            this.Modelbl.AutoSize = true;
            this.Modelbl.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modelbl.Location = new System.Drawing.Point(1480, 708);
            this.Modelbl.Name = "Modelbl";
            this.Modelbl.Size = new System.Drawing.Size(101, 41);
            this.Modelbl.TabIndex = 26;
            this.Modelbl.Text = "Mode";
            // 
            // ModeShow
            // 
            this.ModeShow.AutoSize = true;
            this.ModeShow.Font = new System.Drawing.Font("Goudy Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeShow.Location = new System.Drawing.Point(1649, 708);
            this.ModeShow.Name = "ModeShow";
            this.ModeShow.Size = new System.Drawing.Size(39, 41);
            this.ModeShow.TabIndex = 27;
            this.ModeShow.Text = "---";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1878, 1504);
            this.Controls.Add(this.ModeShow);
            this.Controls.Add(this.Modelbl);
            this.Controls.Add(this.StopPlay);
            this.Controls.Add(this.RecordBtn);
            this.Controls.Add(this.End);
            this.Controls.Add(this.StartPlay);
            this.Controls.Add(this.Player1);
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
            this.MaximumSize = new System.Drawing.Size(2760, 2671);
            this.MinimumSize = new System.Drawing.Size(60, 103);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private AxWMPLib.AxWindowsMediaPlayer Player1;
        private System.Windows.Forms.Button StartPlay;
        private System.Windows.Forms.Button End;
        private System.Windows.Forms.Button RecordBtn;
        private System.Windows.Forms.Button StopPlay;
        private System.Windows.Forms.Label Modelbl;
        private System.Windows.Forms.Label ModeShow;
    }
}