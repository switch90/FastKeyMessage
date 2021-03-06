using System.Runtime.InteropServices;

namespace FastKeyMessage
{
    public partial class Form1 : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook();
        Pathes pathes = new Pathes();
        Form2 form2 = new Form2();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            form2.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gkh.HookedKeys.Add(Keys.NumPad1);
            gkh.HookedKeys.Add(Keys.NumPad2);
            gkh.HookedKeys.Add(Keys.NumPad3);
            gkh.HookedKeys.Add(Keys.NumPad4);
            gkh.HookedKeys.Add(Keys.NumPad5);
            gkh.HookedKeys.Add(Keys.NumPad6);
            gkh.HookedKeys.Add(Keys.NumPad7);
            gkh.HookedKeys.Add(Keys.NumPad8);
            gkh.HookedKeys.Add(Keys.NumPad9);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
        }
        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
                SendMessage(pathes.MessagePath1);

            if (e.KeyCode == Keys.NumPad2)
               SendMessage(pathes.MessagePath2);  
            
            if (e.KeyCode == Keys.NumPad3)
                SendMessage(pathes.MessagePath3);

            if (e.KeyCode == Keys.NumPad4)
                SendMessage(pathes.MessagePath4);

            if (e.KeyCode == Keys.NumPad5)
                SendMessage(pathes.MessagePath5);

            if (e.KeyCode == Keys.NumPad6)
                SendMessage(pathes.MessagePath6);

            if (e.KeyCode == Keys.NumPad7)
                SendMessage(pathes.MessagePath7);

            if (e.KeyCode == Keys.NumPad8)
                SendMessage(pathes.MessagePath8);

            if (e.KeyCode == Keys.NumPad9)
                SendMessage(pathes.MessagePath9);

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // ????????? ???? ????, ? ???? ??? ???? ????????, ?????? ???????        
            if (WindowState == FormWindowState.Minimized)
            {
                // ?????? ???? ???? ?? ??????
                this.ShowInTaskbar = false;
                // ?????? ???? ?????? ? ???? ????????
                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // ?????? ???? ?????? ???????
            notifyIcon1.Visible = false;
            // ?????????? ??????????? ???? ? ??????
            this.ShowInTaskbar = true;
            //????????????? ????
            WindowState = FormWindowState.Normal;
        }
        private static void SendCtrlhotKey(char key)
        {
            keybd_event(0x11, 0, 0, 0);
            keybd_event((byte)key, 0, 0, 0);
            keybd_event((byte)key, 0, 0x2, 0);
            keybd_event(0x11, 0, 0x2, 0);
        }

        void SendMessage(string path) //???????? ?????????
        {           
            SendKeys.Send("{BS}");
            string text = File.ReadAllText(path);
            Clipboard.SetText(text);
            SendCtrlhotKey('V');
        }
    }
}