namespace LockTimer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Locker = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PassedTime = new System.Windows.Forms.Label();
            this.LeftTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.ReSetTime = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Locker
            // 
            this.Locker.Location = new System.Drawing.Point(170, 23);
            this.Locker.Name = "Locker";
            this.Locker.Size = new System.Drawing.Size(75, 23);
            this.Locker.TabIndex = 0;
            this.Locker.Text = "Lock";
            this.Locker.UseVisualStyleBackColor = true;
            this.Locker.Click += new System.EventHandler(this.Locker_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "設定時間";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(38, 25);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "已過時間";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "剩餘時間";
            // 
            // PassedTime
            // 
            this.PassedTime.AutoSize = true;
            this.PassedTime.Location = new System.Drawing.Point(95, 128);
            this.PassedTime.Name = "PassedTime";
            this.PassedTime.Size = new System.Drawing.Size(69, 15);
            this.PassedTime.TabIndex = 6;
            this.PassedTime.Text = "Passedtime";
            // 
            // LeftTime
            // 
            this.LeftTime.AutoSize = true;
            this.LeftTime.Location = new System.Drawing.Point(95, 155);
            this.LeftTime.Name = "LeftTime";
            this.LeftTime.Size = new System.Drawing.Size(61, 15);
            this.LeftTime.TabIndex = 7;
            this.LeftTime.Text = "LeftTime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(95, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "縮小";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.結束ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 26);
            this.contextMenuStrip1.Text = "選項";
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.結束ToolStripMenuItem.Text = "結束";
            this.結束ToolStripMenuItem.Click += new System.EventHandler(this.結束ToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "說明";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(61, 88);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 12;
            this.btnStartStop.Text = "暫停";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // ReSetTime
            // 
            this.ReSetTime.Location = new System.Drawing.Point(123, 59);
            this.ReSetTime.Name = "ReSetTime";
            this.ReSetTime.Size = new System.Drawing.Size(75, 23);
            this.ReSetTime.TabIndex = 13;
            this.ReSetTime.Text = "重設";
            this.ReSetTime.UseVisualStyleBackColor = true;
            this.ReSetTime.Click += new System.EventHandler(this.ReSetTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 176);
            this.Controls.Add(this.ReSetTime);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LeftTime);
            this.Controls.Add(this.PassedTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Locker);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "AutoLocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Locker;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PassedTime;
        private System.Windows.Forms.Label LeftTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 結束ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button ReSetTime;
    }
}

