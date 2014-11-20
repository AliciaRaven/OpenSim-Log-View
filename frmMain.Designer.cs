namespace OSLogView
{
    partial class frmMain
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
            this.txtRaw = new System.Windows.Forms.RichTextBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRaw
            // 
            this.txtRaw.BackColor = System.Drawing.Color.Black;
            this.txtRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRaw.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRaw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtRaw.Location = new System.Drawing.Point(0, 24);
            this.txtRaw.Name = "txtRaw";
            this.txtRaw.ReadOnly = true;
            this.txtRaw.Size = new System.Drawing.Size(868, 585);
            this.txtRaw.TabIndex = 1;
            this.txtRaw.Text = "";
            this.txtRaw.WordWrap = false;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(868, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_Open});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuFile_Open
            // 
            this.mnuFile_Open.Name = "mnuFile_Open";
            this.mnuFile_Open.Size = new System.Drawing.Size(152, 22);
            this.mnuFile_Open.Text = "Open Log";
            this.mnuFile_Open.Click += new System.EventHandler(this.mnuFile_Open_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout_Info});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // mnuAbout_Info
            // 
            this.mnuAbout_Info.Name = "mnuAbout_Info";
            this.mnuAbout_Info.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout_Info.Text = "Info";
            this.mnuAbout_Info.Click += new System.EventHandler(this.mnuAbout_Info_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "log";
            this.openFileDialog1.FileName = "OpenSim";
            this.openFileDialog1.Filter = "OpenSim Logs|*.log";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 609);
            this.Controls.Add(this.txtRaw);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "OpenSim Log Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtRaw;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Open;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout_Info;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

