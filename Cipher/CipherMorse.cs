using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cipher
{
    class CipherMorse : CipherAlgorithm
    {
        Dictionary<string, string> cipher = new Dictionary<string, string>()
        {
            {"a", ".-"},
            {"b", "-..."},
            {"c", "-.-."},
            {"d", "-.."},
            {"e", "."},
            {"f", "..-."},
            {"g", "--."},
            {"h", "...."},
            {"i", ".."},
            {"j", ".---"},
            {"k", "-.-"},
            {"l", ".-.."},
            {"m", "--"},
            {"n", "-."},
            {"o", "---"},
            {"p", ".--."},
            {"q", "--.-"},
            {"r", ".-."},
            {"s", "..."},
            {"t", "-"},
            {"u", "..-"},
            {"v", "...-"},
            {"w", ".--"},
            {"x", "-..-"},
            {"y", "-.--"},
            {"z", "--.."},
            {"1", ".----"},
            {"2", "..---"},
            {"3", "...--"},
            {"4", "....-"},
            {"5", "....."},
            {"6", "-...."},
            {"7", "--..."},
            {"8", "---.."},
            {"9", "----."},
            {"0", "-----"},
            {".", ".-.-.-"},
            {",", "--..--"},
            {"'", ".----."},
            {"_", "..--.-"},
            {":", "---..."},
            {"?", "..--.."},
            {"-", "-....-"},
            {"/", "-..-."},
            {"(", "-.--."},
            {")", "-.--.-"},
            {"=", "-...-"},
            {"@", ".--.-."},
            {"ą", ".-.-"},
            {"ć", "-.-.."},
            {"ę", "..-.."},
            {"ł", ".-..-"},
            {"ń", "--.--"},
            {"ó", "---."},
            {"ś", "...-..."},
            {"ż", "--..-."},
            {"ź", "--..-"}
        };
        Dictionary<string, string> cipherReversed = new Dictionary<string, string>();

        public CipherMorse()
        {
            foreach (KeyValuePair<string, string> entry in cipher)
            {
                cipherReversed.Add(entry.Value, entry.Key);
            }
        }

        public string from(string input)
        {
            string[] a = input.Split(' ');
            List<string> resArray = new List<string>();

            for (int i = 0; i < a.Length; i++)
            {
                string v;
                if (cipherReversed.TryGetValue(a[i].ToString(), out v))
                {
                    resArray.Add(v);
                }
                else
                {
                    if (a[i] == "")
                    {
                        resArray.Add(" ");
                    }
                    else
                    {
                        resArray.Add(a[i]);
                    }
                }
            }
            return Regex.Replace(String.Join("", resArray.ToArray()), "[ ]{2,}", " ");
        }

        public string to(string input)
        {
            char[] a = input.ToLower().ToCharArray();
            List<string> resArray = new List<string>();
            for (int i = 0; i < a.Length; i++)
            {
                string v;
                if (cipher.TryGetValue(a[i].ToString(), out v))
                {
                    resArray.Add(v);
                }
                else
                {
                    resArray.Add(a[i].ToString());
                }
            }
            return String.Join(" ", resArray.ToArray());
        }
    }
}
