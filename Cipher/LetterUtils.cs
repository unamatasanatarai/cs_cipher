using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    class LetterUtils
    {
        public static bool isLetter(char letter)
        {
            return isSmallCase(letter) || isUpperCase(letter);
        }

        public static bool isSmallCase(char letter)
        {
            return letter >= 'a' && letter <= 'z';
        }

        public static bool isUpperCase(char letter)
        {
            return letter >= 'A' && letter <= 'Z';
        }
    }
}
