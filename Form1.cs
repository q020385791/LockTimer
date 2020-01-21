using GlobalKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  static  GlobalKeyHook.KeyboardHook;
namespace LockTimer
{
    public partial class Form1 : Form
    {

      
        public Form1()
        {
            InitializeComponent();
        }
        double TimerSecondCount = 0;
        int TimerMinCount = 0;
        int TargetMin = 0;
        int TargetSecondTotal=0;
        private void Locker_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label5.Text = "請輸入時間";
                
                return;
            }

            try
            {
                TargetMin = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                label5.Text = "請檢查輸入值";
                return;
            }
            Locker.Enabled = false;
            TargetSecondTotal = TargetMin * 60;
            timer1.Start();
            textBox1.Enabled = false;

            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
        }

        public void LockComputer()
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");

        }
        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimerSecondCount += 1;
            TimerMinCount = (int)(TimerSecondCount / 60);
            PassedTime.Text = TimerMinCount.ToString()+"分"+ (TimerSecondCount % 60)+"秒";
            string[] LabelDisPlay= new string[] { "計時中.", "計時中..", "計時中...", "計時中...." };
            label5.Text = LabelDisPlay[(int)TimerSecondCount % 4];
            TargetSecondTotal -= 1;
 
            LeftTime.Text= ((int)(TargetSecondTotal / 60)).ToString() + "分" + (TargetSecondTotal % 60).ToString() + "秒";
            if (TargetSecondTotal<0)
            {
                timer1.Stop();
                LockComputer();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }


        /// <summary>
        /// 顯示出主畫面
        /// </summary>
        private void ShowForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //如果目前是縮小狀態，才要回覆成一般大小的視窗
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            // Activate the form.
            this.Activate();
            this.Focus();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startListen();
         

        }
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyDown
            Console.WriteLine("按下按鍵" + e.KeyValue);
            //如果按下F10
            if (e.KeyValue==121)
            {
                ShowForm();
            }
            //如果按下F9
            if (e.KeyValue == 120)
            {
                IfClose = true;
                Help.ChangeLabel3Text = "關閉程式前請先點一次F9，否則無法關閉";
                Help.HelpLabel3.Visible = true;
            }
        }

        //按鍵鉤子
        private KeyEventHandler myKeyEventHandeler = null;
        private KeyboardHook k_hook = new KeyboardHook();

        //開始全域鍵盤監聽
        public void startListen()
        {
            myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
            k_hook.KeyDownEvent += myKeyEventHandeler;//鉤住鍵按下
            k_hook.Start();//安裝鍵盤鉤子
        }
        //停止全域鍵盤監聽
        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按鍵事件
                myKeyEventHandeler = null;
                k_hook.Stop();//關閉鍵盤鉤子
            }
        }
        bool IfClose = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IfClose)
            {
                stopListen();
            }
            else
            {
                MessageBox.Show("已鎖定，無法關閉，請看說明");
                e.Cancel = true;
                if (this.WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Minimized;
                

            }
        }
        Help Help = new Help();
        private void Button2_Click(object sender, EventArgs e)
        {
            Help = new Help();
            Help.Show();
        }
        bool IfStop = false;
        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (IfStop == false)
            {
                
                timer1.Stop();
                IfStop = true;
                btnStartStop.Text = "繼續";
            }
            else
            {
                timer1.Start();
                IfStop = false;
                btnStartStop.Text = "暫停";
            }
            
        }

        private void ReSetTime_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox1.Text = "";
            textBox1.Enabled = true;
            TimerSecondCount = 0;
            TimerMinCount = 0;
            TargetMin = 0;
            TargetSecondTotal = 0;
            IfStop = false;
            btnStartStop.Text = "暫停";
            PassedTime.Text = "";
            LeftTime.Text = "";
            Locker.Enabled = true;
            //記得要按過F9才可以關閉
            IfClose = false;

        }
    }
}
