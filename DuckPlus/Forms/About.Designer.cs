namespace DuckPlus.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pb_Duck = new System.Windows.Forms.PictureBox();
            this.l_titleVer = new System.Windows.Forms.Label();
            this.l_JavaVersion = new System.Windows.Forms.Label();
            this.Btn_OpenFolder = new System.Windows.Forms.Button();
            this.ll_GitHubLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Gb_GitHub = new System.Windows.Forms.GroupBox();
            this.Gb_Donate = new System.Windows.Forms.GroupBox();
            this.ll_BtcAddress = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Gb_Java = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ll_JavaControlPanel = new System.Windows.Forms.LinkLabel();
            this.l_ApplicationVersion = new System.Windows.Forms.Label();
            this.LL_Credits = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Duck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Gb_GitHub.SuspendLayout();
            this.Gb_Donate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Gb_Java.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Duck
            // 
            this.pb_Duck.Image = ((System.Drawing.Image)(resources.GetObject("pb_Duck.Image")));
            this.pb_Duck.Location = new System.Drawing.Point(12, 12);
            this.pb_Duck.Name = "pb_Duck";
            this.pb_Duck.Size = new System.Drawing.Size(64, 64);
            this.pb_Duck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Duck.TabIndex = 1;
            this.pb_Duck.TabStop = false;
            // 
            // l_titleVer
            // 
            this.l_titleVer.AutoSize = true;
            this.l_titleVer.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_titleVer.Location = new System.Drawing.Point(82, 12);
            this.l_titleVer.Name = "l_titleVer";
            this.l_titleVer.Size = new System.Drawing.Size(62, 25);
            this.l_titleVer.TabIndex = 2;
            this.l_titleVer.Text = "Duck";
            // 
            // l_JavaVersion
            // 
            this.l_JavaVersion.AutoSize = true;
            this.l_JavaVersion.Location = new System.Drawing.Point(28, 24);
            this.l_JavaVersion.Name = "l_JavaVersion";
            this.l_JavaVersion.Size = new System.Drawing.Size(94, 13);
            this.l_JavaVersion.TabIndex = 5;
            this.l_JavaVersion.Text = "Version: ####";
            // 
            // Btn_OpenFolder
            // 
            this.Btn_OpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("Btn_OpenFolder.Image")));
            this.Btn_OpenFolder.Location = new System.Drawing.Point(267, 58);
            this.Btn_OpenFolder.Name = "Btn_OpenFolder";
            this.Btn_OpenFolder.Size = new System.Drawing.Size(23, 23);
            this.Btn_OpenFolder.TabIndex = 8;
            this.toolTip.SetToolTip(this.Btn_OpenFolder, "Open Directory...");
            this.Btn_OpenFolder.UseVisualStyleBackColor = true;
            this.Btn_OpenFolder.Click += new System.EventHandler(this.Btn_openFolder_Click);
            // 
            // ll_GitHubLink
            // 
            this.ll_GitHubLink.AutoSize = true;
            this.ll_GitHubLink.Location = new System.Drawing.Point(28, 21);
            this.ll_GitHubLink.Name = "ll_GitHubLink";
            this.ll_GitHubLink.Size = new System.Drawing.Size(236, 13);
            this.ll_GitHubLink.TabIndex = 12;
            this.ll_GitHubLink.TabStop = true;
            this.ll_GitHubLink.Text = "https://github.com/DarkByte7/DuckPlus";
            this.toolTip.SetToolTip(this.ll_GitHubLink, "Visit GitHub Repo...");
            this.ll_GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_GitHubLink_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Gb_GitHub
            // 
            this.Gb_GitHub.Controls.Add(this.ll_GitHubLink);
            this.Gb_GitHub.Controls.Add(this.pictureBox1);
            this.Gb_GitHub.Location = new System.Drawing.Point(12, 143);
            this.Gb_GitHub.Name = "Gb_GitHub";
            this.Gb_GitHub.Size = new System.Drawing.Size(278, 50);
            this.Gb_GitHub.TabIndex = 13;
            this.Gb_GitHub.TabStop = false;
            this.Gb_GitHub.Text = "GitHub";
            // 
            // Gb_Donate
            // 
            this.Gb_Donate.Controls.Add(this.ll_BtcAddress);
            this.Gb_Donate.Controls.Add(this.pictureBox2);
            this.Gb_Donate.Location = new System.Drawing.Point(12, 87);
            this.Gb_Donate.Name = "Gb_Donate";
            this.Gb_Donate.Size = new System.Drawing.Size(278, 50);
            this.Gb_Donate.TabIndex = 14;
            this.Gb_Donate.TabStop = false;
            this.Gb_Donate.Text = "Donate BTC";
            // 
            // ll_BtcAddress
            // 
            this.ll_BtcAddress.AutoSize = true;
            this.ll_BtcAddress.Location = new System.Drawing.Point(28, 21);
            this.ll_BtcAddress.Name = "ll_BtcAddress";
            this.ll_BtcAddress.Size = new System.Drawing.Size(242, 13);
            this.ll_BtcAddress.TabIndex = 12;
            this.ll_BtcAddress.TabStop = true;
            this.ll_BtcAddress.Text = "1KKghRonJu6orcu7rf4r1wSnsnAPbnC8B7";
            this.toolTip.SetToolTip(this.ll_BtcAddress, "Copy address to clipboard...");
            this.ll_BtcAddress.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_BtcAddress_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // Gb_Java
            // 
            this.Gb_Java.Controls.Add(this.pictureBox3);
            this.Gb_Java.Controls.Add(this.ll_JavaControlPanel);
            this.Gb_Java.Controls.Add(this.l_JavaVersion);
            this.Gb_Java.Location = new System.Drawing.Point(12, 199);
            this.Gb_Java.Name = "Gb_Java";
            this.Gb_Java.Size = new System.Drawing.Size(278, 51);
            this.Gb_Java.TabIndex = 15;
            this.Gb_Java.TabStop = false;
            this.Gb_Java.Text = "Java";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // ll_JavaControlPanel
            // 
            this.ll_JavaControlPanel.AutoSize = true;
            this.ll_JavaControlPanel.Location = new System.Drawing.Point(188, 24);
            this.ll_JavaControlPanel.Name = "ll_JavaControlPanel";
            this.ll_JavaControlPanel.Size = new System.Drawing.Size(84, 13);
            this.ll_JavaControlPanel.TabIndex = 18;
            this.ll_JavaControlPanel.TabStop = true;
            this.ll_JavaControlPanel.Text = "Control Panel";
            this.toolTip.SetToolTip(this.ll_JavaControlPanel, "Open Java Control Panel...");
            this.ll_JavaControlPanel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_JavaControlPanel_LinkClicked);
            // 
            // l_ApplicationVersion
            // 
            this.l_ApplicationVersion.AutoSize = true;
            this.l_ApplicationVersion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ApplicationVersion.Location = new System.Drawing.Point(87, 37);
            this.l_ApplicationVersion.Name = "l_ApplicationVersion";
            this.l_ApplicationVersion.Size = new System.Drawing.Size(73, 13);
            this.l_ApplicationVersion.TabIndex = 16;
            this.l_ApplicationVersion.Text = "%version%";
            // 
            // LL_Credits
            // 
            this.LL_Credits.AutoSize = true;
            this.LL_Credits.Location = new System.Drawing.Point(87, 63);
            this.LL_Credits.Name = "LL_Credits";
            this.LL_Credits.Size = new System.Drawing.Size(48, 13);
            this.LL_Credits.TabIndex = 12;
            this.LL_Credits.TabStop = true;
            this.LL_Credits.Text = "Credits";
            this.toolTip.SetToolTip(this.LL_Credits, "Visit Credits...");
            this.LL_Credits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Ll_GitHubLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(137, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "+";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(298, 257);
            this.Controls.Add(this.LL_Credits);
            this.Controls.Add(this.Btn_OpenFolder);
            this.Controls.Add(this.l_ApplicationVersion);
            this.Controls.Add(this.Gb_Java);
            this.Controls.Add(this.Gb_Donate);
            this.Controls.Add(this.Gb_GitHub);
            this.Controls.Add(this.l_titleVer);
            this.Controls.Add(this.pb_Duck);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Duck+";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Duck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Gb_GitHub.ResumeLayout(false);
            this.Gb_GitHub.PerformLayout();
            this.Gb_Donate.ResumeLayout(false);
            this.Gb_Donate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Gb_Java.ResumeLayout(false);
            this.Gb_Java.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_Duck;
        private System.Windows.Forms.Label l_JavaVersion;
        public System.Windows.Forms.Label l_titleVer;
        private System.Windows.Forms.Button Btn_OpenFolder;
        private System.Windows.Forms.LinkLabel ll_GitHubLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Gb_GitHub;
        private System.Windows.Forms.GroupBox Gb_Donate;
        private System.Windows.Forms.LinkLabel ll_BtcAddress;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox Gb_Java;
        public System.Windows.Forms.Label l_ApplicationVersion;
        private System.Windows.Forms.LinkLabel LL_Credits;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.LinkLabel ll_JavaControlPanel;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label label1;
    }
}