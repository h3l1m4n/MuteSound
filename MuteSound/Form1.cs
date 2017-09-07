using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MuteSound
{
    public partial class FrmMain : Form
    {
    
        private const int MOD_CONTROL = 0x0002;

        private const int MOD_SHIFT = 0x0004;
        private const int WM_HOTKEY = 0x0312;
        public const int MOD_ALT = 0x0001;
        private bool _decreased;
        private const string Filename = "binds.xml";
        private List<Keybinding> _keyMap;

        public FrmMain()
        {
            InitializeComponent();
           
            ShowInTaskbar = false;
            Readconfig();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        private void button1_Click(object sender, EventArgs e)
        {
            //MuteGame();
        }

        private void MuteGame(string name)
        {
            if (VolumeMixer.IsGameMuted(name))
                VolumeMixer.MuteGame(false, name);
            else
                VolumeMixer.MuteGame(true, name);
        }

        private void Readconfig()
        {
            _keyMap = new List<Keybinding>();


            if (File.Exists(Filename))
            {
                HelperClass.Deserialize(_keyMap, Filename);
                SetHotKeys();
            }
        }



        private void SetHotKeys()
        {
            foreach (var bind in _keyMap)
                RegisterHotKey(Handle, bind.Id, bind.Modifier, bind.Key);
        }

        private void unregisterHotKeys()
        {
            foreach (var bind in _keyMap)
                UnregisterHotKey(Handle, bind.Id);
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)

                foreach (var bind in _keyMap)
                    if ((int) m.WParam == bind.Id)
                        try
                        {
                            
                            if (bind.Min == -1 && bind.Max == -1)
                                MuteGame(bind.ProcessName);

                            else
                            {
                         
                                if ((int)VolumeMixer.GetGameVolume(bind.ProcessName) == bind.Min)
                                {
                                      VolumeMixer.SetGameVolume(bind.Max, bind.ProcessName);
                                }
                                else
                                {
                                    VolumeMixer.SetGameVolume(bind.Min, bind.ProcessName);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }


            base.WndProc(ref m);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(Handle, 1);
            Application.Exit();
        }

        private void kluwertseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.kluwert.se");
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frmConfig = new config())
            {
                var result = frmConfig.ShowDialog();
                if (result == DialogResult.OK)
                    if (File.Exists(Filename))
                    {
                        HelperClass.Deserialize(_keyMap, Filename);
                        unregisterHotKeys();
                        SetHotKeys();
                    }
            }
        }
    }
}