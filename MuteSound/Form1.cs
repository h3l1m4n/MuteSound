using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MuteSound
{
    public partial class FrmMain : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);
        //All modifier buttons, incase of Configfile in the future.
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int WM_HOTKEY = 0x0312;
        public const int MOD_ALT = 0x0001;
        private bool decreased = false;
        public FrmMain()
        {
            InitializeComponent();
           
            this.ShowInTaskbar = false;
            SetHotKeys();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            MuteGame();
        }
        private void MuteGame()
        {
            if (VolumeMixer.IsGameMuted())
            {
                VolumeMixer.MuteGame(false);
            }
            else
            {
                VolumeMixer.MuteGame(true);
            }
        }

        private void readconfig()
        {
            //Read out config
            //Game name, incase it was to be used for another proccess
            //Such as Hotkeys, Prefferd volumelevels etc.
        }
        private void DecreaseGame()
        {
            if (decreased) { VolumeMixer.SetGameVolume(50);
                decreased = true;
            }
         
            else
            { 
                VolumeMixer.SetGameVolume(100);
                decreased = false;
            }
        }
        private void SetHotKeys()
        {
            RegisterHotKey(Handle, 1, MOD_ALT,78);
            RegisterHotKey(Handle, 2, MOD_ALT, 77);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && (int)m.WParam == 1)
                try
                {
                   MuteGame();
                }
                catch (Exception)
                {
                    MessageBox.Show("WHAT THE FUCK JUST HAPPEND? \n I CANT MUTE THE FUCKING AIRPLANE", @"Error", MessageBoxButtons.OK);
                }
            if (m.Msg == WM_HOTKEY && (int)m.WParam == 2)
                try
                {

                    DecreaseGame();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant decrease sound", @"Error", MessageBoxButtons.OK);
                }
            base.WndProc(ref m);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(Handle, 1);
            System.Windows.Forms.Application.Exit();
        }

        private void kluwertseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.kluwert.se");
        }
    }


}
