namespace FastKeyMessage
{
    public partial class Form1 : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook();
        Pathes pathes = new Pathes();
        Form2 form2 = new Form2();
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
            {
                Clipboard.SetText(File.ReadAllText(pathes.MessagePath8));
                SendKeys.Send("{BS}");
                SendKeys.Send("^V");
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
        void SendMessage(string path) //Отправка сообщения
        {
            Clipboard.SetText(File.ReadAllText(path));
            SendKeys.Send("{BS}");
            SendKeys.Send("^V");
        }
    }
}