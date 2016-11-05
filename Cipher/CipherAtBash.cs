using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    class CipherAtBash : CipherAlgorithm
    {
        char[] _shift = new char[char.MaxValue];

        public CipherAtBash()
        {
            for (int i = 0; i < char.MaxValue; i++)
            {
                _shift[i] = (char)i;
            }
         
           for (char c = 'A'; c <= 'Z'; c++)
            {
                _shift[(int)c] = (char)('Z' + 'A' - c);
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                _shift[(int)c] = (char)('z' + 'a' - c);
            }
        }

        public string from(string input)
        {
            return rotate(input);
        }

        public string to(string input)
        {
            return rotate(input);
        }

        string rotate(string value)
        {
            char[] a = value.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (LetterUtils.isLetter(a[i]))
                {
                    int t = (int)a[i];
                    a[i] = _shift[t];
                }
            }

            return new string(a);
        }
    }
}

