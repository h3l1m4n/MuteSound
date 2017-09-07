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
            Max = -1;
            Min = -1;
        }
        public Keybinding(int id, int key, int modifier, string processName, int min, int max)
        {
            Id = id;
            Key = key;
            Modifier = modifier;
            ProcessName = processName;
            Min = min;
            Max = max;
        }
        public Keybinding()
        {
        }

        public string ProcessName { get; set; }
        public int Key { get; set; }
        public int Modifier { get; set; }
        public int Id { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }
    }
}