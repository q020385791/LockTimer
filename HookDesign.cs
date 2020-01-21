using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace GlobalKeyHook
{
  

    class KeyboardHook
    {
        public event KeyEventHandler KeyDownEvent;
        public event KeyPressEventHandler KeyPressEvent;
        public event KeyEventHandler KeyUpEvent;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        //宣告鍵盤鉤子處理的初始值
        static int hKeyboardHook = 0;
        //值在Microsoft SDK的Winuser.h裡查詢


        //執行緒鍵盤鉤子監聽滑鼠訊息設為2，全域性鍵盤監聽滑鼠訊息設為13
        public const int WH_KEYBOARD_LL = 13;  
        HookProc KeyboardHookProcedure; //宣告KeyboardHookProcedure作為HookProc型別
        //鍵盤結構
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  //定一個虛擬鍵碼。該程式碼必須有一個價值的範圍1至254
            public int scanCode; // 指定的硬體掃描碼的關鍵
            public int flags;  // 鍵標誌
            public int time; // 指定的時間戳記的這個訊息
            public int dwExtraInfo; // 指定額外資訊相關的資訊
        }
        //使用此功能，安裝了一個鉤子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);


        //呼叫此函式解除安裝鉤子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);


        //使用此功能，通過資訊鉤子繼續下一個鉤子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        // 取得當前執行緒編號（執行緒鉤子需要用到）
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId();

        //使用WINDOWS API函式代替獲取當前例項的函式,防止鉤子失效
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public void Start()
        {
            // 安裝鍵盤鉤子
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, GetModuleHandle(System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                //************************************
                //鍵盤執行緒鉤子
                SetWindowsHookEx(13, KeyboardHookProcedure, IntPtr.Zero, GetCurrentThreadId());
                //指定要監聽的執行緒idGetCurrentThreadId(),
                //鍵盤全域性鉤子,需要引用空間(using System.Reflection;)
                //SetWindowsHookEx( 13,MouseHookProcedure,Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),0);
                //
                //關於SetWindowsHookEx (int idHook, HookProc lpfn, IntPtr hInstance, int threadId)函式將鉤子加入到鉤子連結串列中，說明一下四個引數：
                //idHook 鉤子型別，即確定鉤子監聽何種訊息，上面的程式碼中設為2，即監聽鍵盤訊息並且是執行緒鉤子，如果是全域性鉤子監聽鍵盤訊息應設為13，
                //執行緒鉤子監聽滑鼠訊息設為7，全域性鉤子監聽滑鼠訊息設為14。lpfn 鉤子子程的地址指標。如果dwThreadId引數為0 或是一個由別的程序建立的
                //執行緒的標識，lpfn必須指向DLL中的鉤子子程。 除此以外，lpfn可以指向當前程序的一段鉤子子程程式碼。鉤子函式的入口地址，當鉤子鉤到任何
                //訊息後便呼叫這個函式。hInstance應用程式例項的控制代碼。標識包含lpfn所指的子程的DLL。如果threadId 標識當前程序建立的一個執行緒，而且子
                //程程式碼位於當前程序，hInstance必須為NULL。可以很簡單的設定其為本應用程式的例項控制代碼。threaded 與安裝的鉤子子程相關聯的執行緒的識別符號
                //如果為0，鉤子子程與所有的執行緒關聯，即為全域性鉤子
                //************************************
                //如果SetWindowsHookEx失敗
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("安裝鍵盤鉤子失敗");
                }
            }
        }
        public void Stop()
        {
            bool retKeyboard = true;


            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }

            if (!(retKeyboard)) throw new Exception("解除安裝鉤子失敗！");
        }
        //ToAscii職能的轉換指定的虛擬鍵碼和鍵盤狀態的相應字元或字元
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] 指定虛擬關鍵程式碼進行翻譯。
                                         int uScanCode, // [in] 指定的硬體掃描碼的關鍵須翻譯成英文。高階位的這個值設定的關鍵，如果是（不壓）
                                         byte[] lpbKeyState, // [in] 指標，以256位元組陣列，包含當前鍵盤的狀態。每個元素（位元組）的陣列包含狀態的一個關鍵。如果高階位的位元組是一套，關鍵是下跌（按下）。在低位元，如果設定表明，關鍵是對切換。在此功能，只有肘位的CAPS LOCK鍵是相關的。在切換狀態的NUM個鎖和滾動鎖定鍵被忽略。
                                         byte[] lpwTransKey, // [out] 指標的緩衝區收到翻譯字元或字元。
                                         int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.

        //獲取按鍵的狀態
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        private const int WM_KEYDOWN = 0x100;//KEYDOWN
        private const int WM_KEYUP = 0x101;//KEYUP
        private const int WM_SYSKEYDOWN = 0x104;//SYSKEYDOWN
        private const int WM_SYSKEYUP = 0x105;//SYSKEYUP

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // 偵聽鍵盤事件
            if ((nCode >= 0) && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                // raise KeyDown
                if (KeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDownEvent(this, e);
                    Console.WriteLine("KeyDown");
                }

                //鍵盤按下
                if (KeyPressEvent != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);

                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.scanCode, keyState, inBuffer, MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPressEvent(this, e);
                        Console.WriteLine("Keypress");
                    }
                }

                // 鍵盤擡起
                if (KeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUpEvent(this, e);
                    Console.WriteLine("KeyUp");
                }

            }
            //如果返回1，則結束訊息，這個訊息到此為止，不再傳遞。
            //如果返回0或呼叫CallNextHookEx函式則訊息出了這個鉤子繼續往下傳遞，也就是傳給訊息真正的接受者
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
        ~KeyboardHook()
        {
            Stop();
        }
        //使用方式
        //掛勾開啟Button1_Click
        //掛勾關閉Button2_Click

        //private void Button1_Click(object sender, EventArgs e)
        //{

        //    startListen();
        //}

        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    stopListen();
        //}

        //private void hook_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //KeyDown
        //    Console.WriteLine("按下按鍵" + e.KeyValue);
        //}

        ////按鍵鉤子
        //private KeyEventHandler myKeyEventHandeler = null;
        //private KeyboardHook k_hook = new KeyboardHook();

        ////開始全域鍵盤監聽
        //public void startListen()
        //{
        //    myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
        //    k_hook.KeyDownEvent += myKeyEventHandeler;//鉤住鍵按下
        //    k_hook.Start();//安裝鍵盤鉤子
        //}
        ////停止全域鍵盤監聽
        //public void stopListen()
        //{
        //    if (myKeyEventHandeler != null)
        //    {
        //        k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按鍵事件
        //        myKeyEventHandeler = null;
        //        k_hook.Stop();//關閉鍵盤鉤子
        //    }
        //}


    }
}
