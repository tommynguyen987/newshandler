namespace MyUtility
{
    partial class NewsHandler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewsHandler));
            this.label1 = new System.Windows.Forms.Label();
            this.cbListWebsites = new System.Windows.Forms.ComboBox();
            this.btnHandle = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.myContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateNews = new System.Windows.Forms.Button();
            this.btnDeleteNews = new System.Windows.Forms.Button();
            this.btnUpdateNews = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbListWebsiteTypes = new System.Windows.Forms.ComboBox();
            this.chkHandleEveryNews = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.geckoWebBrowser1 = new Gecko.GeckoWebBrowser();
            this.myContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Trang Web";
            // 
            // cbListWebsites
            // 
            this.cbListWebsites.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListWebsites.FormattingEnabled = true;
            this.cbListWebsites.Location = new System.Drawing.Point(121, 58);
            this.cbListWebsites.Name = "cbListWebsites";
            this.cbListWebsites.Size = new System.Drawing.Size(639, 23);
            this.cbListWebsites.TabIndex = 1;
            this.cbListWebsites.SelectedIndexChanged += new System.EventHandler(this.cbListWebsites_SelectedIndexChanged);
            // 
            // btnHandle
            // 
            this.btnHandle.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandle.Location = new System.Drawing.Point(773, 56);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(133, 28);
            this.btnHandle.TabIndex = 2;
            this.btnHandle.Text = "Xử Lý Trang";
            this.btnHandle.UseVisualStyleBackColor = true;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 135);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 24);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(924, 505);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myNotifyIcon
            // 
            this.myNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.myNotifyIcon.BalloonTipTitle = "News Handler";
            this.myNotifyIcon.ContextMenuStrip = this.myContextMenuStrip;
            this.myNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("myNotifyIcon.Icon")));
            this.myNotifyIcon.Text = "Double click into icon to show application";
            this.myNotifyIcon.Visible = true;
            this.myNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.myNotifyIcon_MouseDoubleClick);
            // 
            // myContextMenuStrip
            // 
            this.myContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeApplicationToolStripMenuItem});
            this.myContextMenuStrip.Name = "myContextMenuStrip";
            this.myContextMenuStrip.Size = new System.Drawing.Size(184, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openToolStripMenuItem.Text = "Open Main Window";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // closeApplicationToolStripMenuItem
            // 
            this.closeApplicationToolStripMenuItem.Name = "closeApplicationToolStripMenuItem";
            this.closeApplicationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.closeApplicationToolStripMenuItem.Text = "Exit";
            this.closeApplicationToolStripMenuItem.Click += new System.EventHandler(this.closeApplicationToolStripMenuItem_Click);
            // 
            // btnCreateNews
            // 
            this.btnCreateNews.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNews.Location = new System.Drawing.Point(245, 94);
            this.btnCreateNews.Name = "btnCreateNews";
            this.btnCreateNews.Size = new System.Drawing.Size(133, 28);
            this.btnCreateNews.TabIndex = 4;
            this.btnCreateNews.Text = "Đăng Tin Mới";
            this.btnCreateNews.UseVisualStyleBackColor = true;
            this.btnCreateNews.Click += new System.EventHandler(this.btnCreateNews_Click);
            // 
            // btnDeleteNews
            // 
            this.btnDeleteNews.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteNews.Location = new System.Drawing.Point(402, 94);
            this.btnDeleteNews.Name = "btnDeleteNews";
            this.btnDeleteNews.Size = new System.Drawing.Size(133, 28);
            this.btnDeleteNews.TabIndex = 4;
            this.btnDeleteNews.Text = "Xóa Tin";
            this.btnDeleteNews.UseVisualStyleBackColor = true;
            this.btnDeleteNews.Click += new System.EventHandler(this.btnDeleteNews_Click);
            // 
            // btnUpdateNews
            // 
            this.btnUpdateNews.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateNews.Location = new System.Drawing.Point(557, 94);
            this.btnUpdateNews.Name = "btnUpdateNews";
            this.btnUpdateNews.Size = new System.Drawing.Size(133, 28);
            this.btnUpdateNews.TabIndex = 4;
            this.btnUpdateNews.Text = "Cập Nhật Tin";
            this.btnUpdateNews.UseVisualStyleBackColor = true;
            this.btnUpdateNews.Click += new System.EventHandler(this.btnUpdateNews_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại Đăng Tin";
            // 
            // cbListWebsiteTypes
            // 
            this.cbListWebsiteTypes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListWebsiteTypes.FormattingEnabled = true;
            this.cbListWebsiteTypes.Location = new System.Drawing.Point(121, 19);
            this.cbListWebsiteTypes.Name = "cbListWebsiteTypes";
            this.cbListWebsiteTypes.Size = new System.Drawing.Size(639, 23);
            this.cbListWebsiteTypes.TabIndex = 1;
            this.cbListWebsiteTypes.SelectedIndexChanged += new System.EventHandler(this.cbListWebsiteTypes_SelectedIndexChanged);
            // 
            // chkHandleEveryNews
            // 
            this.chkHandleEveryNews.AutoSize = true;
            this.chkHandleEveryNews.Location = new System.Drawing.Point(20, 98);
            this.chkHandleEveryNews.Name = "chkHandleEveryNews";
            this.chkHandleEveryNews.Size = new System.Drawing.Size(122, 20);
            this.chkHandleEveryNews.TabIndex = 5;
            this.chkHandleEveryNews.Text = "Xử lý từng trang";
            this.chkHandleEveryNews.UseVisualStyleBackColor = true;
            this.chkHandleEveryNews.CheckedChanged += new System.EventHandler(this.chkHandleEveryNews_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 135);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(925, 505);
            this.geckoWebBrowser1.TabIndex = 6;
            this.geckoWebBrowser1.UseHttpActivityObserver = false;
            // 
            // NewsHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 640);
            this.Controls.Add(this.geckoWebBrowser1);
            this.Controls.Add(this.chkHandleEveryNews);
            this.Controls.Add(this.btnUpdateNews);
            this.Controls.Add(this.btnDeleteNews);
            this.Controls.Add(this.btnCreateNews);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnHandle);
            this.Controls.Add(this.cbListWebsiteTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbListWebsites);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewsHandler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Đăng Tin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewsHandler_FormClosing);
            this.Load += new System.EventHandler(this.NewsHandler_Load);
            this.Resize += new System.EventHandler(this.NewsHandler_Resize);
            this.myContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbListWebsites;
        private System.Windows.Forms.Button btnHandle;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon myNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip myContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnCreateNews;
        private System.Windows.Forms.Button btnDeleteNews;
        private System.Windows.Forms.Button btnUpdateNews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbListWebsiteTypes;
        private System.Windows.Forms.CheckBox chkHandleEveryNews;
        private System.Windows.Forms.Timer timer2;
        private Gecko.GeckoWebBrowser geckoWebBrowser1;


    }
}