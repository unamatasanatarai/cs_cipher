using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    class CipherBacon : CipherAlgorithm
    {

        Dictionary<char, string> cipher = new Dictionary<char, string>()
        {
            {'a', "AAAAA"},
            {'b', "AAAAB"},
            {'c', "AAABA"},
            {'d', "AAABB"},
            {'e', "AABAA"},
            {'f', "AABAB"},
            {'g', "AABBA"},
            {'h', "AABBB"},
            {'i', "ABAAA"},
            {'k', "ABABA"},
            {'j', "ABAAB"},
            {'l', "ABABB"},
            {'m', "ABBAA"},
            {'n', "ABBAB"},
            {'o', "ABBBA"},
            {'p', "ABBBB"},
            {'q', "BAAAA"},
            {'r', "BAAAB"},
            {'s', "BAABA"},
            {'t', "BAABB"},
            {'u', "BABAA"},
            {'v', "BABAB"},
            {'w', "BABBA"},
            {'x', "BABBB"},
            {'y', "BBAAA"},
            {'z', "BBAAB"}
        };

        Dictionary<string, string> cipherReversed = new Dictionary<string, string>();


        public CipherBacon()
        {
            foreach (KeyValuePair<char, string> entry in cipher)
            {
                cipherReversed.Add(entry.Value, entry.Key.ToString());
            }
        }

        public string from(string input)
        {
            char[] a = input.ToCharArray();
            string result = "";
            List<string> split = splitIntoBacon(a);
            foreach (string element in split)
            {
                string v;
                if (cipherReversed.TryGetValue(element, out v)){
                    result += v;
                }else
                {
                    result += element;
                }
            
            }
            return result;
        }

        public string to(string input)
        {
            char[] a = input.ToLower().ToCharArray();
            string result = "";

            for (int i = 0; i < a.Length; i++)
            {
                string v;
                if (cipher.TryGetValue(a[i], out v))
                {
                    result += v;
                }
                else
                {
                    result += a[i];
                }
            }
            return result;
        }

        List<string> splitIntoBacon(char[] a)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < a.Length; i++)
            {
                if (isitBacon(a, i))
                {
                    result.Add(
                        string.Format(
                            "{0}{1}{2}{3}{4}",
                            a[i].ToString(),
                            a[i + 1].ToString(),
                            a[i + 2].ToString(),
                            a[i + 3].ToString(),
                            a[i + 4].ToString()
                        )
                    );
                    i += 4;
                }
                else
                {
                    result.Add(a[i].ToString());
                }
            }

            return result;
        }

        bool isitBacon(char[] a, int offset = 0)
        {
            try
            {
                for (int i = offset; i < offset + 5; i++)
                {
                    string letter = a[i].ToString().ToLower();
                    if (letter != "a" && letter != "b")
                    {
                        return false;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}


