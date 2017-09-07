using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MuteSound
{
    public partial class config : Form
    {
        private int charkey = -1;
        private List<Keybinding> loadedKeyMap;
        private int modkey;

        public config()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            loadProcesses();
            LoadXML();
        }

        private void loadProcesses()
        {
            foreach (var p in HelperClass.GetCurrentProcess())
                lbProcc.Items.Add(p.ProcessName);
        }

        private void LoadXML()
        {
            loadedKeyMap = new List<Keybinding>();
            if (File.Exists("binds.xml"))
            {
                HelperClass.Deserialize(loadedKeyMap, "binds.xml");
                foreach (var keymap in loadedKeyMap)
                {
                    var lvitem = new ListViewItem();
                    lvitem.Text = keymap.ProcessName;
                    lvitem.SubItems.Add(ModifierConverter(keymap.Modifier) + " + " + (char) keymap.Key);
                    lvBinds.Items.Add(lvitem);
                }
            }
        }


        private string ModifierConverter(int i)
        {
            switch (i)
            {
                case 0:
                    return "None";
                    break;
                case 1:
                    return "ALT";
                    break;
                case 2:
                    return "CTRL";
                    break;
                case 3:
                    return "";
                    break;
                case 4:
                    return "SHFT";
                    break;
            }
            return "error";
        }


        private void lbProcc_Click(object sender, EventArgs e)
        {
            tbProcc.Text = lbProcc.SelectedItem.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbProcc.Text) || charkey < 32)
            {
                MessageBox.Show("Missing Procces or Keybind");
            }
            else
            {
                var lvitem = new ListViewItem();
                lvitem.Text = tbProcc.Text;
                lvitem.SubItems.Add(ModifierConverter(modkey) + " + " + (char) charkey);
                lvBinds.Items.Add(lvitem);

                if (rbDecrease.Checked)
                {
                    loadedKeyMap.Add(new Keybinding(loadedKeyMap.Count + 1, charkey, modkey, tbProcc.Text, (int)numMin.Value, (int)numMax.Value));

                }
                else
                    loadedKeyMap.Add(new Keybinding(loadedKeyMap.Count + 1, charkey, modkey, tbProcc.Text));


                HelperClass.SerializeObject(loadedKeyMap, "binds.xml");
                modkey = 0;
                tbProcc.Text = "";
                btRegister.Text = "Register HotKey";
                charkey = -1;
            }
        }

        private void btRegister_KeyDown(object sender, KeyEventArgs e)
        {
            var S_HOTKEY = 0;
            var mod = 0;


            if (e.KeyCode == Keys.Escape)
            {
                btRegister.Text = new KeysConverter().ConvertToString(S_HOTKEY);
            }
            else
            {
                S_HOTKEY = (int) e.KeyCode;
                if (e.Alt) mod |= 1;
                if (e.Control) mod |= 2;
                if (e.Shift) mod |= 4;

                var modString = new KeysConverter().ConvertToString(e.Modifiers);

                btRegister.Text = modString.Substring(0, modString.Length - 4) +
                                  new KeysConverter().ConvertToString(S_HOTKEY);

                
            }

            charkey = S_HOTKEY;
            modkey = mod;
            Cursor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (lvBinds.SelectedItems.Count > 0)
            { 

        loadedKeyMap.RemoveAt(lvBinds.FocusedItem.Index);
                lvBinds.SelectedItems[0].Remove();
                HelperClass.SerializeObject(loadedKeyMap, "binds.xml");
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            lbProcc.Items.Clear();
            loadProcesses();
        }

        private void rbDecrease_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDecrease.Checked)
            {
                numMax.Enabled = true;
                numMin.Enabled = true;
            }
            else
            {
                numMax.Enabled = false;
                numMin.Enabled = false;
            }
        }
    }
}