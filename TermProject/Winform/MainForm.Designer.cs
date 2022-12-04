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
            this.PassBut = new System.Windows.Forms.Button();
            this.UndoBut = new System.Windows.Forms.Button();
            this.RestartBut = new System.Windows.Forms.Button();
            this.ResignationBut = new System.Windows.Forms.Button();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenu,
            this.restartToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(618, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // GameMenu
            // 
            this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(39, 22);
            this.GameMenu.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // PassBut
            // 
            this.PassBut.Location = new System.Drawing.Point(537, 43);
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
            this.UndoBut.Location = new System.Drawing.Point(537, 80);
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
            this.RestartBut.Location = new System.Drawing.Point(537, 167);
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
            this.ResignationBut.Location = new System.Drawing.Point(537, 122);
            this.ResignationBut.Margin = new System.Windows.Forms.Padding(1);
            this.ResignationBut.Name = "ResignationBut";
            this.ResignationBut.Size = new System.Drawing.Size(74, 27);
            this.ResignationBut.TabIndex = 5;
            this.ResignationBut.Text = "Resignation";
            this.ResignationBut.UseVisualStyleBackColor = true;
            this.ResignationBut.Click += new System.EventHandler(this.ResignationBut_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(618, 478);
            this.Controls.Add(this.ResignationBut);
            this.Controls.Add(this.RestartBut);
            this.Controls.Add(this.UndoBut);
            this.Controls.Add(this.PassBut);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(651, 607);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
    }
}