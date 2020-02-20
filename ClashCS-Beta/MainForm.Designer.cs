namespace ClashCS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.status1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.mode1 = new System.Windows.Forms.Label();
            this.rule_radioButton = new System.Windows.Forms.RadioButton();
            this.global_radioButton = new System.Windows.Forms.RadioButton();
            this.direct_radioButton = new System.Windows.Forms.RadioButton();
            this.subscription1 = new System.Windows.Forms.Label();
            this.sub_textBox = new System.Windows.Forms.TextBox();
            this.download_button = new System.Windows.Forms.Button();
            this.local_config1 = new System.Windows.Forms.Label();
            this.local_config_path_textBox = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.http_port_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.socks_port_textBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.redir_port_textBox = new System.Windows.Forms.TextBox();
            this.apply_button = new System.Windows.Forms.Button();
            this.allow_lan_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.restPort_textBox = new System.Windows.Forms.TextBox();
            this.restart_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.log_button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sub_radioButton2 = new System.Windows.Forms.RadioButton();
            this.local_radioButton1 = new System.Windows.Forms.RadioButton();
            this.logobox = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayRightClickContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxiesButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logobox)).BeginInit();
            this.trayRightClickContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // status1
            // 
            this.status1.AutoSize = true;
            this.status1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.status1.Location = new System.Drawing.Point(150, 25);
            this.status1.Name = "status1";
            this.status1.Size = new System.Drawing.Size(60, 19);
            this.status1.TabIndex = 1;
            this.status1.Text = "Status:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.status.ForeColor = System.Drawing.Color.Gray;
            this.status.Location = new System.Drawing.Point(216, 25);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(128, 19);
            this.status.TabIndex = 2;
            this.status.Text = "Getting Status...";
            // 
            // mode1
            // 
            this.mode1.AutoSize = true;
            this.mode1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mode1.Location = new System.Drawing.Point(72, 181);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(57, 19);
            this.mode1.TabIndex = 3;
            this.mode1.Text = "Mode:";
            // 
            // rule_radioButton
            // 
            this.rule_radioButton.AutoSize = true;
            this.rule_radioButton.Checked = true;
            this.rule_radioButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rule_radioButton.Location = new System.Drawing.Point(135, 153);
            this.rule_radioButton.Name = "rule_radioButton";
            this.rule_radioButton.Size = new System.Drawing.Size(62, 24);
            this.rule_radioButton.TabIndex = 4;
            this.rule_radioButton.TabStop = true;
            this.rule_radioButton.Text = "Rule";
            this.rule_radioButton.UseVisualStyleBackColor = true;
            this.rule_radioButton.CheckedChanged += new System.EventHandler(this.rule_radioButton_CheckedChanged);
            // 
            // global_radioButton
            // 
            this.global_radioButton.AutoSize = true;
            this.global_radioButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.global_radioButton.Location = new System.Drawing.Point(135, 178);
            this.global_radioButton.Name = "global_radioButton";
            this.global_radioButton.Size = new System.Drawing.Size(77, 24);
            this.global_radioButton.TabIndex = 5;
            this.global_radioButton.Text = "Global";
            this.global_radioButton.UseVisualStyleBackColor = true;
            this.global_radioButton.CheckedChanged += new System.EventHandler(this.global_radioButton_CheckedChanged);
            // 
            // direct_radioButton
            // 
            this.direct_radioButton.AutoSize = true;
            this.direct_radioButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.direct_radioButton.Location = new System.Drawing.Point(135, 204);
            this.direct_radioButton.Name = "direct_radioButton";
            this.direct_radioButton.Size = new System.Drawing.Size(74, 24);
            this.direct_radioButton.TabIndex = 6;
            this.direct_radioButton.Text = "Direct";
            this.direct_radioButton.UseVisualStyleBackColor = true;
            // 
            // subscription1
            // 
            this.subscription1.AutoSize = true;
            this.subscription1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.subscription1.Location = new System.Drawing.Point(39, 81);
            this.subscription1.Name = "subscription1";
            this.subscription1.Size = new System.Drawing.Size(194, 19);
            this.subscription1.TabIndex = 7;
            this.subscription1.Text = "Subs conf:    —————>";
            // 
            // sub_textBox
            // 
            this.sub_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sub_textBox.Location = new System.Drawing.Point(131, 113);
            this.sub_textBox.Name = "sub_textBox";
            this.sub_textBox.Size = new System.Drawing.Size(286, 27);
            this.sub_textBox.TabIndex = 8;
            this.sub_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sub_textBox_MouseClick);
            // 
            // download_button
            // 
            this.download_button.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.download_button.Location = new System.Drawing.Point(236, 76);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(180, 30);
            this.download_button.TabIndex = 9;
            this.download_button.Text = "Download";
            this.download_button.UseVisualStyleBackColor = true;
            this.download_button.Click += new System.EventHandler(this.download_button_Click);
            // 
            // local_config1
            // 
            this.local_config1.AutoSize = true;
            this.local_config1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.local_config1.Location = new System.Drawing.Point(48, 11);
            this.local_config1.Name = "local_config1";
            this.local_config1.Size = new System.Drawing.Size(185, 19);
            this.local_config1.TabIndex = 11;
            this.local_config1.Text = "Local Dir:    —————>";
            // 
            // local_config_path_textBox
            // 
            this.local_config_path_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.local_config_path_textBox.Location = new System.Drawing.Point(131, 43);
            this.local_config_path_textBox.Name = "local_config_path_textBox";
            this.local_config_path_textBox.Size = new System.Drawing.Size(285, 27);
            this.local_config_path_textBox.TabIndex = 12;
            // 
            // browse_button
            // 
            this.browse_button.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.browse_button.Location = new System.Drawing.Point(236, 6);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(180, 30);
            this.browse_button.TabIndex = 13;
            this.browse_button.Text = "Browse...";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start_button.Location = new System.Drawing.Point(135, 55);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 75);
            this.start_button.TabIndex = 15;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(46, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 19);
            this.label9.TabIndex = 23;
            this.label9.Text = "Http Port:";
            // 
            // http_port_textBox
            // 
            this.http_port_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.http_port_textBox.Location = new System.Drawing.Point(135, 408);
            this.http_port_textBox.Name = "http_port_textBox";
            this.http_port_textBox.Size = new System.Drawing.Size(65, 27);
            this.http_port_textBox.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(248, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 19);
            this.label10.TabIndex = 25;
            this.label10.Text = "Socks5 Port:";
            // 
            // socks_port_textBox
            // 
            this.socks_port_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.socks_port_textBox.Location = new System.Drawing.Point(355, 410);
            this.socks_port_textBox.Name = "socks_port_textBox";
            this.socks_port_textBox.Size = new System.Drawing.Size(65, 27);
            this.socks_port_textBox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(41, 449);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "Redir Port:";
            // 
            // redir_port_textBox
            // 
            this.redir_port_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.redir_port_textBox.Location = new System.Drawing.Point(135, 442);
            this.redir_port_textBox.Name = "redir_port_textBox";
            this.redir_port_textBox.Size = new System.Drawing.Size(65, 27);
            this.redir_port_textBox.TabIndex = 28;
            // 
            // apply_button
            // 
            this.apply_button.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.apply_button.Location = new System.Drawing.Point(240, 491);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(180, 30);
            this.apply_button.TabIndex = 29;
            this.apply_button.Text = "Apply";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.apply_button_Click);
            this.apply_button.MouseHover += new System.EventHandler(this.apply_button_MouseHover);
            // 
            // allow_lan_checkBox
            // 
            this.allow_lan_checkBox.AutoSize = true;
            this.allow_lan_checkBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.allow_lan_checkBox.Location = new System.Drawing.Point(55, 498);
            this.allow_lan_checkBox.Name = "allow_lan_checkBox";
            this.allow_lan_checkBox.Size = new System.Drawing.Size(104, 23);
            this.allow_lan_checkBox.TabIndex = 31;
            this.allow_lan_checkBox.Text = "Allow Lan";
            this.allow_lan_checkBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(216, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "RESTful api Port:";
            // 
            // restPort_textBox
            // 
            this.restPort_textBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restPort_textBox.Location = new System.Drawing.Point(355, 444);
            this.restPort_textBox.Name = "restPort_textBox";
            this.restPort_textBox.Size = new System.Drawing.Size(65, 27);
            this.restPort_textBox.TabIndex = 34;
            this.restPort_textBox.Text = "9090";
            // 
            // restart_button
            // 
            this.restart_button.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restart_button.Location = new System.Drawing.Point(240, 55);
            this.restart_button.Name = "restart_button";
            this.restart_button.Size = new System.Drawing.Size(75, 75);
            this.restart_button.TabIndex = 38;
            this.restart_button.Text = "Restart";
            this.restart_button.UseVisualStyleBackColor = true;
            this.restart_button.Click += new System.EventHandler(this.restart_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stop_button.Location = new System.Drawing.Point(345, 55);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(75, 75);
            this.stop_button.TabIndex = 39;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // log_button1
            // 
            this.log_button1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.log_button1.Location = new System.Drawing.Point(240, 153);
            this.log_button1.Name = "log_button1";
            this.log_button1.Size = new System.Drawing.Size(75, 75);
            this.log_button1.TabIndex = 42;
            this.log_button1.Text = "Logs";
            this.log_button1.UseVisualStyleBackColor = true;
            this.log_button1.Click += new System.EventHandler(this.log_button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sub_radioButton2);
            this.panel1.Controls.Add(this.local_radioButton1);
            this.panel1.Controls.Add(this.local_config1);
            this.panel1.Controls.Add(this.subscription1);
            this.panel1.Controls.Add(this.sub_textBox);
            this.panel1.Controls.Add(this.download_button);
            this.panel1.Controls.Add(this.local_config_path_textBox);
            this.panel1.Controls.Add(this.browse_button);
            this.panel1.Location = new System.Drawing.Point(4, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 142);
            this.panel1.TabIndex = 43;
            // 
            // sub_radioButton2
            // 
            this.sub_radioButton2.AutoSize = true;
            this.sub_radioButton2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sub_radioButton2.Location = new System.Drawing.Point(66, 116);
            this.sub_radioButton2.Name = "sub_radioButton2";
            this.sub_radioButton2.Size = new System.Drawing.Size(59, 24);
            this.sub_radioButton2.TabIndex = 15;
            this.sub_radioButton2.Text = "use:";
            this.sub_radioButton2.UseVisualStyleBackColor = true;
            // 
            // local_radioButton1
            // 
            this.local_radioButton1.AutoSize = true;
            this.local_radioButton1.Checked = true;
            this.local_radioButton1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.local_radioButton1.Location = new System.Drawing.Point(67, 43);
            this.local_radioButton1.Name = "local_radioButton1";
            this.local_radioButton1.Size = new System.Drawing.Size(59, 24);
            this.local_radioButton1.TabIndex = 14;
            this.local_radioButton1.TabStop = true;
            this.local_radioButton1.Text = "use:";
            this.local_radioButton1.UseVisualStyleBackColor = true;
            this.local_radioButton1.CheckedChanged += new System.EventHandler(this.local_radioButton1_CheckedChanged);
            // 
            // logobox
            // 
            this.logobox.Image = global::ClashCS.Properties.Resources.logo;
            this.logobox.Location = new System.Drawing.Point(1, 12);
            this.logobox.Name = "logobox";
            this.logobox.Size = new System.Drawing.Size(128, 128);
            this.logobox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logobox.TabIndex = 0;
            this.logobox.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.trayRightClickContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ClashCS-Beta";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // trayRightClickContextMenu
            // 
            this.trayRightClickContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.trayRightClickContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开窗口ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.trayRightClickContextMenu.Name = "trayRightClickContextMenu";
            this.trayRightClickContextMenu.Size = new System.Drawing.Size(139, 52);
            // 
            // 打开窗口ToolStripMenuItem
            // 
            this.打开窗口ToolStripMenuItem.Name = "打开窗口ToolStripMenuItem";
            this.打开窗口ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.打开窗口ToolStripMenuItem.Text = "打开窗口";
            this.打开窗口ToolStripMenuItem.Click += new System.EventHandler(this.打开窗口ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // proxiesButton
            // 
            this.proxiesButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.proxiesButton.Location = new System.Drawing.Point(345, 153);
            this.proxiesButton.Name = "proxiesButton";
            this.proxiesButton.Size = new System.Drawing.Size(75, 75);
            this.proxiesButton.TabIndex = 45;
            this.proxiesButton.Text = "Proxies";
            this.proxiesButton.UseVisualStyleBackColor = true;
            this.proxiesButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 566);
            this.Controls.Add(this.proxiesButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.log_button1);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.restart_button);
            this.Controls.Add(this.restPort_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allow_lan_checkBox);
            this.Controls.Add(this.apply_button);
            this.Controls.Add(this.redir_port_textBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.socks_port_textBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.http_port_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.direct_radioButton);
            this.Controls.Add(this.global_radioButton);
            this.Controls.Add(this.rule_radioButton);
            this.Controls.Add(this.mode1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.status1);
            this.Controls.Add(this.logobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClashCS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logobox)).EndInit();
            this.trayRightClickContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logobox;
        private System.Windows.Forms.Label status1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label mode1;
        private System.Windows.Forms.RadioButton rule_radioButton;
        private System.Windows.Forms.RadioButton global_radioButton;
        private System.Windows.Forms.RadioButton direct_radioButton;
        private System.Windows.Forms.Label subscription1;
        private System.Windows.Forms.TextBox sub_textBox;
        private System.Windows.Forms.Button download_button;
        private System.Windows.Forms.Label local_config1;
        private System.Windows.Forms.TextBox local_config_path_textBox;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox http_port_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox socks_port_textBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox redir_port_textBox;
        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.CheckBox allow_lan_checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox restPort_textBox;
        private System.Windows.Forms.Button restart_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button log_button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sub_radioButton2;
        private System.Windows.Forms.RadioButton local_radioButton1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip trayRightClickContextMenu;
        private System.Windows.Forms.ToolStripMenuItem 打开窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button proxiesButton;
    }
}

