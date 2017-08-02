using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace MuteSound
{
    internal static class HelperClass
    {
        //Convers object of Keybinding to XML
        public static void SerializeObject(List<Keybinding> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Keybinding>));
            using (var stream = File.Open(fileName,FileMode.Create))
            {
                
                serializer.Serialize(stream, list);
            }
        }

        // Converts Keybinding from Xml to Objectlist
        public static void Deserialize(List<Keybinding> list, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Keybinding>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (List<Keybinding>) serializer.Deserialize(stream);
                list.Clear();
                list.AddRange(other);
            }
        }

        //Gets all processes on the current user
        public static Process[] GetCurrentProcess()
        {
            var runningProcesses = Process.GetProcesses();
            var currentSessionId = Process.GetCurrentProcess().SessionId;

            var sameAsThisSession = runningProcesses.Where(p => p.SessionId == currentSessionId).ToArray();
            return sameAsThisSession;
        }
    }
}