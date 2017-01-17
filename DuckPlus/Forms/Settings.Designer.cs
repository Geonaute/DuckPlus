namespace DuckPlus.Forms
{
    partial class Settings
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
            this.Nud_Update = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Cb_Keyboard = new System.Windows.Forms.ComboBox();
            this.Btn_UpdateEncoder = new System.Windows.Forms.Button();
            this.Rb_Preset = new System.Windows.Forms.RadioButton();
            this.Rb_Custom = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Tb_KeyboardPropertiesPath = new System.Windows.Forms.TextBox();
            this.Btn_Browse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Nud_MaxProjects = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_Register = new System.Windows.Forms.Button();
            this.Btn_Unregister = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Cb_TopMost = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Cb_WordWrap = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Btn_Background = new System.Windows.Forms.Button();
            this.Btn_Foreground = new System.Windows.Forms.Button();
            this.L_ColorExample = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Update)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_MaxProjects)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nud_Update
            // 
            this.Nud_Update.Location = new System.Drawing.Point(127, 9);
            this.Nud_Update.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Nud_Update.Name = "Nud_Update";
            this.Nud_Update.Size = new System.Drawing.Size(71, 20);
            this.Nud_Update.TabIndex = 0;
            this.Nud_Update.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nud_Update.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.Nud_Update.ValueChanged += new System.EventHandler(this.Nud_Update_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Update Check (Days):";
            // 
            // Cb_Keyboard
            // 
            this.Cb_Keyboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_Keyboard.FormattingEnabled = true;
            this.Cb_Keyboard.Items.AddRange(new object[] {
            "be (French-Belgian)",
            "br (Portuguese-Brazil)",
            "ca (Candian)",
            "ch (Swiss-German)",
            "de (German)",
            "dk (Danish)",
            "es (Espanol)",
            "fi (Finlad)",
            "fr (French)",
            "gb (United Kingdom)",
            "hr (Croation)",
            "it (Italian)",
            "pt (Portuguese)",
            "ru (Russian)",
            "si (Slovenian)",
            "sv (Swedish)",
            "tr (Turkish)",
            "us (United States)"});
            this.Cb_Keyboard.Location = new System.Drawing.Point(72, 19);
            this.Cb_Keyboard.Name = "Cb_Keyboard";
            this.Cb_Keyboard.Size = new System.Drawing.Size(204, 21);
            this.Cb_Keyboard.TabIndex = 3;
            this.Cb_Keyboard.SelectedIndexChanged += new System.EventHandler(this.Cb_Keyboard_SelectedIndexChanged);
            // 
            // Btn_UpdateEncoder
            // 
            this.Btn_UpdateEncoder.Location = new System.Drawing.Point(207, 6);
            this.Btn_UpdateEncoder.Name = "Btn_UpdateEncoder";
            this.Btn_UpdateEncoder.Size = new System.Drawing.Size(75, 23);
            this.Btn_UpdateEncoder.TabIndex = 5;
            this.Btn_UpdateEncoder.Text = "Update";
            this.Btn_UpdateEncoder.UseVisualStyleBackColor = true;
            this.Btn_UpdateEncoder.Click += new System.EventHandler(this.Btn_UpdateEncoder_Click);
            // 
            // Rb_Preset
            // 
            this.Rb_Preset.AutoSize = true;
            this.Rb_Preset.Checked = true;
            this.Rb_Preset.Location = new System.Drawing.Point(6, 19);
            this.Rb_Preset.Name = "Rb_Preset";
            this.Rb_Preset.Size = new System.Drawing.Size(55, 17);
            this.Rb_Preset.TabIndex = 7;
            this.Rb_Preset.TabStop = true;
            this.Rb_Preset.Text = "Preset";
            this.Rb_Preset.UseVisualStyleBackColor = true;
            this.Rb_Preset.CheckedChanged += new System.EventHandler(this.Rb_Custom_CheckedChanged);
            // 
            // Rb_Custom
            // 
            this.Rb_Custom.AutoSize = true;
            this.Rb_Custom.Location = new System.Drawing.Point(6, 45);
            this.Rb_Custom.Name = "Rb_Custom";
            this.Rb_Custom.Size = new System.Drawing.Size(60, 17);
            this.Rb_Custom.TabIndex = 8;
            this.Rb_Custom.Text = "Custom";
            this.Rb_Custom.UseVisualStyleBackColor = true;
            this.Rb_Custom.CheckedChanged += new System.EventHandler(this.Rb_Custom_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tb_KeyboardPropertiesPath);
            this.groupBox2.Controls.Add(this.Btn_Browse);
            this.groupBox2.Controls.Add(this.Rb_Preset);
            this.groupBox2.Controls.Add(this.Rb_Custom);
            this.groupBox2.Controls.Add(this.Cb_Keyboard);
            this.groupBox2.Location = new System.Drawing.Point(6, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 76);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keyboard Properties";
            // 
            // Tb_KeyboardPropertiesPath
            // 
            this.Tb_KeyboardPropertiesPath.Location = new System.Drawing.Point(72, 47);
            this.Tb_KeyboardPropertiesPath.Name = "Tb_KeyboardPropertiesPath";
            this.Tb_KeyboardPropertiesPath.ReadOnly = true;
            this.Tb_KeyboardPropertiesPath.Size = new System.Drawing.Size(123, 20);
            this.Tb_KeyboardPropertiesPath.TabIndex = 11;
            // 
            // Btn_Browse
            // 
            this.Btn_Browse.Enabled = false;
            this.Btn_Browse.Location = new System.Drawing.Point(201, 45);
            this.Btn_Browse.Name = "Btn_Browse";
            this.Btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.Btn_Browse.TabIndex = 10;
            this.Btn_Browse.Text = "Browse...";
            this.Btn_Browse.UseVisualStyleBackColor = true;
            this.Btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Maximum History:";
            // 
            // Nud_MaxProjects
            // 
            this.Nud_MaxProjects.Location = new System.Drawing.Point(101, 14);
            this.Nud_MaxProjects.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_MaxProjects.Name = "Nud_MaxProjects";
            this.Nud_MaxProjects.Size = new System.Drawing.Size(71, 20);
            this.Nud_MaxProjects.TabIndex = 11;
            this.Nud_MaxProjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nud_MaxProjects.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Nud_MaxProjects.ValueChanged += new System.EventHandler(this.Nud_MaxProjects_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Nud_MaxProjects);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 42);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recent Projects";
            // 
            // Btn_Register
            // 
            this.Btn_Register.Location = new System.Drawing.Point(6, 19);
            this.Btn_Register.Name = "Btn_Register";
            this.Btn_Register.Size = new System.Drawing.Size(75, 23);
            this.Btn_Register.TabIndex = 15;
            this.Btn_Register.Text = "Register";
            this.Btn_Register.UseVisualStyleBackColor = true;
            this.Btn_Register.Click += new System.EventHandler(this.Btn_Register_Click);
            // 
            // Btn_Unregister
            // 
            this.Btn_Unregister.Location = new System.Drawing.Point(87, 19);
            this.Btn_Unregister.Name = "Btn_Unregister";
            this.Btn_Unregister.Size = new System.Drawing.Size(75, 23);
            this.Btn_Unregister.TabIndex = 16;
            this.Btn_Unregister.Text = "UnRegister";
            this.Btn_Unregister.UseVisualStyleBackColor = true;
            this.Btn_Unregister.Click += new System.EventHandler(this.Btn_Unregister_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Btn_Register);
            this.groupBox4.Controls.Add(this.Btn_Unregister);
            this.groupBox4.Location = new System.Drawing.Point(6, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 51);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Association";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 162);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Cb_TopMost);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(297, 136);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Cb_TopMost
            // 
            this.Cb_TopMost.AutoSize = true;
            this.Cb_TopMost.Location = new System.Drawing.Point(12, 111);
            this.Cb_TopMost.Name = "Cb_TopMost";
            this.Cb_TopMost.Size = new System.Drawing.Size(96, 17);
            this.Cb_TopMost.TabIndex = 1;
            this.Cb_TopMost.Text = "Always on Top";
            this.Cb_TopMost.UseVisualStyleBackColor = true;
            this.Cb_TopMost.CheckedChanged += new System.EventHandler(this.Cb_TopMost_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.Cb_WordWrap);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(297, 136);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Code Editor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Cb_WordWrap
            // 
            this.Cb_WordWrap.AutoSize = true;
            this.Cb_WordWrap.Location = new System.Drawing.Point(9, 6);
            this.Cb_WordWrap.Name = "Cb_WordWrap";
            this.Cb_WordWrap.Size = new System.Drawing.Size(81, 17);
            this.Cb_WordWrap.TabIndex = 0;
            this.Cb_WordWrap.Text = "Word Wrap";
            this.Cb_WordWrap.UseVisualStyleBackColor = true;
            this.Cb_WordWrap.CheckedChanged += new System.EventHandler(this.Cb_WordWrap_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Btn_UpdateEncoder);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.Nud_Update);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(297, 136);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encoder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Btn_Background
            // 
            this.Btn_Background.Location = new System.Drawing.Point(6, 19);
            this.Btn_Background.Name = "Btn_Background";
            this.Btn_Background.Size = new System.Drawing.Size(75, 23);
            this.Btn_Background.TabIndex = 1;
            this.Btn_Background.Text = "Background";
            this.Btn_Background.UseVisualStyleBackColor = true;
            this.Btn_Background.Click += new System.EventHandler(this.Btn_Background_Click);
            // 
            // Btn_Foreground
            // 
            this.Btn_Foreground.Location = new System.Drawing.Point(6, 48);
            this.Btn_Foreground.Name = "Btn_Foreground";
            this.Btn_Foreground.Size = new System.Drawing.Size(75, 23);
            this.Btn_Foreground.TabIndex = 2;
            this.Btn_Foreground.Text = "Foreground";
            this.Btn_Foreground.UseVisualStyleBackColor = true;
            this.Btn_Foreground.Click += new System.EventHandler(this.Btn_Foreground_Click);
            // 
            // L_ColorExample
            // 
            this.L_ColorExample.Location = new System.Drawing.Point(87, 19);
            this.L_ColorExample.Name = "L_ColorExample";
            this.L_ColorExample.Size = new System.Drawing.Size(189, 52);
            this.L_ColorExample.TabIndex = 3;
            this.L_ColorExample.Text = "DuckPlus";
            this.L_ColorExample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Btn_Background);
            this.groupBox5.Controls.Add(this.L_ColorExample);
            this.groupBox5.Controls.Add(this.Btn_Foreground);
            this.groupBox5.Location = new System.Drawing.Point(9, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(282, 81);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Color";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 182);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Update)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_MaxProjects)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Nud_Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cb_Keyboard;
        private System.Windows.Forms.Button Btn_UpdateEncoder;
        private System.Windows.Forms.RadioButton Rb_Preset;
        private System.Windows.Forms.RadioButton Rb_Custom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Tb_KeyboardPropertiesPath;
        private System.Windows.Forms.Button Btn_Browse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Nud_MaxProjects;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_Register;
        private System.Windows.Forms.Button Btn_Unregister;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox Cb_TopMost;
        private System.Windows.Forms.CheckBox Cb_WordWrap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label L_ColorExample;
        private System.Windows.Forms.Button Btn_Foreground;
        private System.Windows.Forms.Button Btn_Background;
    }
}