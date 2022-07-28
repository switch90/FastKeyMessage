using System.Runtime.InteropServices;
using System.Drawing;
using Microsoft.Toolkit.Uwp.Notifications;

namespace FastKeyMessage
{
    
    public partial class Form1 : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook();
        Pathes pathes = new Pathes();
        PopupForm popupForm = new PopupForm();
        Form2 form2 = new Form2();
        Form form = new Form();
        NotifyIcon NI = new NotifyIcon();
        string runPath = Environment.CurrentDirectory;


        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            DrawGrid(361, 361);
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
            gkh.HookedKeys.Add(Keys.NumPad0);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            SendNotificaton("Программа запущена, для отображения подсказки - Numpad 0", "Fast Message");
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - popupForm.Width,
                       Screen.PrimaryScreen.WorkingArea.Height - popupForm.Height);
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
            {
                popupForm.BackgroundImage = DrawGrid(361, 361);
                popupForm.Show();
                SendKeys.Send("{BS}");
            }
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

            if (e.KeyCode == Keys.NumPad0)
            {
                SendKeys.Send("{BS}");
                popupForm.Visible = false;
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }                
                    
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon1.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
        }
        private static void SendCtrlhotKey(char key)
        {
            keybd_event(0x11, 0, 0, 0);
            keybd_event((byte)key, 0, 0, 0);
            keybd_event((byte)key, 0, 0x2, 0);
            keybd_event(0x11, 0, 0x2, 0);
        }

        void SendMessage(string path) //Отправка сообщения
        {           
            SendKeys.Send("{BS}");
            string text = File.ReadAllText(path);
            Clipboard.SetText(text);
            SendCtrlhotKey('V');
        }

        public void testButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = DrawGrid(361,361);
            popupForm.BackgroundImage = DrawGrid(361, 361);
            popupForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NI_BalloonTipClosed(Object sender, EventArgs e)
        {
            NI.Visible = false;
        }

        private void SendNotificaton(string message, string name)
        {
            NI.BalloonTipText = message;
            NI.BalloonTipTitle = name;
            NI.BalloonTipIcon = ToolTipIcon.Info;
            NI.Icon = Icon;
            NI.Visible = true;
            NI.ShowBalloonTip(1000);
        }

        private Bitmap DrawGrid(int x, int y) //draw grid 3x3
        {
            Bitmap bmp = new Bitmap(x, y);
            Pen pen = new Pen(Color.Black);
            //Создание квадрата для каждого numpad

            RectangleF rectf1 = new RectangleF(20, 290, 100, 360);
            RectangleF rectf2 = new RectangleF(130, 290, 230, 350);
            RectangleF rectf3 = new RectangleF(250, 290, 350, 350);
            RectangleF rectf4 = new RectangleF(20, 170, 100, 220);            
            RectangleF rectf5 = new RectangleF(140, 170, 220, 220);
            RectangleF rectf6 = new RectangleF(240, 170, 220, 340);           
            RectangleF rectf7 = new RectangleF(20, 50, 100, 100);
            RectangleF rectf8 = new RectangleF(120, 50, 220, 20);
            RectangleF rectf9 = new RectangleF(260, 50, 360, 20);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                //Отрисовка решетки
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                graph.DrawLine(pen, 120, 0, 120, 360);
                graph.DrawLine(pen, 240, 0, 240, 360);
                graph.DrawLine(pen, 0, 120, 360, 120);
                graph.DrawLine(pen, 0, 240, 360, 240);
                graph.DrawLine(pen, 0, 0, 360, 0);
                graph.DrawLine(pen, 0, 0, 0, 360);
                graph.DrawLine(pen, 0, 360, 360, 360);
                graph.DrawLine(pen, 360, 0, 360, 360);

                //Отрисовка текста из кнопок в боксы
                graph.DrawString(form2.NumButtonsText[0], new Font("Tahoma", 10), Brushes.Black, rectf1);
                graph.DrawString(form2.NumButtonsText[1], new Font("Tahoma", 10), Brushes.Black, rectf2);
                graph.DrawString(form2.NumButtonsText[2], new Font("Tahoma", 10), Brushes.Black, rectf3);
                graph.DrawString(form2.NumButtonsText[3], new Font("Tahoma", 10), Brushes.Black, rectf4);
                graph.DrawString(form2.NumButtonsText[4], new Font("Tahoma", 10), Brushes.Black, rectf5);
                graph.DrawString(form2.NumButtonsText[5], new Font("Tahoma", 10), Brushes.Black, rectf6);
                graph.DrawString(form2.NumButtonsText[6], new Font("Tahoma", 10), Brushes.Black, rectf7);
                graph.DrawString(form2.NumButtonsText[7], new Font("Tahoma", 10), Brushes.Black, rectf8);
                graph.DrawString(form2.NumButtonsText[8], new Font("Tahoma", 10), Brushes.Black, rectf9);

            }
            return bmp;
        }
    }
}