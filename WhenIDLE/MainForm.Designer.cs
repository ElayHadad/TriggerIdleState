namespace WhenIDLE
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_trigger = new System.Windows.Forms.TextBox();
            this.btn_setTrigger = new System.Windows.Forms.Button();
            this.chkbx_autoStart = new System.Windows.Forms.CheckBox();
            this.chkbx_runInBackground = new System.Windows.Forms.CheckBox();
            this.timer_checkIDLE = new System.Windows.Forms.Timer(this.components);
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_restartCheck = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "set maximum memory usage to trigger idle state";
            // 
            // tb_trigger
            // 
            this.tb_trigger.Location = new System.Drawing.Point(246, 12);
            this.tb_trigger.Name = "tb_trigger";
            this.tb_trigger.Size = new System.Drawing.Size(100, 20);
            this.tb_trigger.TabIndex = 1;
            // 
            // btn_setTrigger
            // 
            this.btn_setTrigger.Location = new System.Drawing.Point(271, 38);
            this.btn_setTrigger.Name = "btn_setTrigger";
            this.btn_setTrigger.Size = new System.Drawing.Size(75, 23);
            this.btn_setTrigger.TabIndex = 2;
            this.btn_setTrigger.Text = "set";
            this.btn_setTrigger.UseVisualStyleBackColor = true;
            this.btn_setTrigger.Click += new System.EventHandler(this.btn_setTrigger_Click);
            // 
            // chkbx_autoStart
            // 
            this.chkbx_autoStart.AutoSize = true;
            this.chkbx_autoStart.Location = new System.Drawing.Point(16, 86);
            this.chkbx_autoStart.Name = "chkbx_autoStart";
            this.chkbx_autoStart.Size = new System.Drawing.Size(118, 17);
            this.chkbx_autoStart.TabIndex = 3;
            this.chkbx_autoStart.Text = "start when pc starts";
            this.chkbx_autoStart.UseVisualStyleBackColor = true;
            this.chkbx_autoStart.CheckedChanged += new System.EventHandler(this.chkbx_autoStart_CheckedChanged);
            // 
            // chkbx_runInBackground
            // 
            this.chkbx_runInBackground.AutoSize = true;
            this.chkbx_runInBackground.Location = new System.Drawing.Point(211, 86);
            this.chkbx_runInBackground.Name = "chkbx_runInBackground";
            this.chkbx_runInBackground.Size = new System.Drawing.Size(135, 17);
            this.chkbx_runInBackground.TabIndex = 4;
            this.chkbx_runInBackground.Text = "start in the background";
            this.chkbx_runInBackground.UseVisualStyleBackColor = true;
            // 
            // timer_checkIDLE
            // 
            this.timer_checkIDLE.Interval = 1000;
            this.timer_checkIDLE.Tick += new System.EventHandler(this.timer_checkIDLE_Tick);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(274, 124);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(12, 124);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.Text = "stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(102, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.closeToolStripMenuItem.Text = "close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // timer_restartCheck
            // 
            this.timer_restartCheck.Interval = 1000;
            this.timer_restartCheck.Tick += new System.EventHandler(this.timer_restartCheck_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 159);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.chkbx_runInBackground);
            this.Controls.Add(this.chkbx_autoStart);
            this.Controls.Add(this.btn_setTrigger);
            this.Controls.Add(this.tb_trigger);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_trigger;
        private System.Windows.Forms.Button btn_setTrigger;
        private System.Windows.Forms.CheckBox chkbx_autoStart;
        private System.Windows.Forms.CheckBox chkbx_runInBackground;
        private System.Windows.Forms.Timer timer_checkIDLE;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Timer timer_restartCheck;
    }
}

