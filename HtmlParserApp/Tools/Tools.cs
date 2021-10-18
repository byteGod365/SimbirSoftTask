using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HtmlParserApp.Tools
{
    public static class Tools
    {
        public static Dictionary<string, int> TextProcessing(string text)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            char[] specialSymbols = { '©', '—', '«', '»', '&', '+', '=', '@', '№', '#', '*', '%', ' ', ',', '.', '!', '?', '"', '/', '|', '\'', '\\', ';', ':', '[', ']', '(', ')', '<', '>', '{', '}', '\n', '\r', '\t' };
            string[] words = text.Split(specialSymbols);
            foreach (string str in words)
            {
                if (str != "" && !ContainsDigit(str))
                {
                    string word = str.ToUpper();
                    if (result.ContainsKey(word))
                    {
                        result[word] += 1;
                    }
                    else
                    {
                        result.Add(word, 1);
                    }
                }
            }
            return result;
        }
        public static bool ContainsDigit(string s)
        {
            for (int i = 0; i < 10; i++)
            {
                if (s.Contains(Convert.ToString(i)))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsLatin(string s)
        {
            string word = s.ToLower();
            for (int i = 0; i < 26; i++)
            {
                if (word.Contains((char)(97 + i)))
                {
                    return true;
                }
            }
            return false;
        }
        public static byte[] GetData(Dictionary<string, int> stat)
        {
            string[] keys = stat.Keys.ToArray();
            string buffer = "";
            foreach (string key in keys)
            {
                buffer += (key + " " + stat[key] + "\n");
            }
            byte[] data = new UTF8Encoding(true).GetBytes(buffer);
            return data;
        }
        public static Dictionary<string, int> GetStatistic(byte[] data)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            string text = new UTF8Encoding(true).GetString(data);
            List<string> lines = text.Split('\n').ToList<string>();
            lines.RemoveAt(lines.Count - 1);
            foreach(string line in lines)
            {
                result.Add(line.Split(' ')[0], Int32.Parse(line.Split(' ')[1]));
            }
            return result;
        }
    }
}

