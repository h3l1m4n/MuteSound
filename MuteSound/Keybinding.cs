using System;

namespace MuteSound
{
    [Serializable]
    public class Keybinding
    {
        public Keybinding(int id, int key, int modifier, string processName)
        {
            Id = id;
            Key = key;
            Modifier = modifier;
            ProcessName = processName;
        }

        public Keybinding()
        {
        }

        public string ProcessName { get; set; }
        public int Key { get; set; }
        public int Modifier { get; set; }
        public int Id { get; set; }
    }
}