using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    class CipherCezar : CipherAlgorithm
    {
        int offset = 18;

        public string from(string input)
        {
            return rotate(input, -offset);
        }

        public string to(string input)
        {
            return rotate(input, offset);
        }

        string rotate(string input, int shift)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                buffer[i] = rotateSingleLetter(letter, shift);
            }
            return new string(buffer);
        }

        char rotateSingleLetter(char letter, int shift)
        {

            if (!LetterUtils.isLetter(letter))
            {
                return letter;
            }

            if (LetterUtils.isSmallCase(letter))
            {
                return rotateSingleSmallCase(doShift(letter, shift));
            }

            return rotateSingleUpperCase(doShift(letter, shift));
        }

        char doShift(char letter, int shift)
        {
            return (char)(letter + shift);
        }

        char rotateInBoundries(char letter, char lowerBound, char upperBound)
        {
            if (letter > upperBound)
            {
                return (char)(letter - 26);
            }

            if (letter < lowerBound)
            {
                return (char)(letter + 26);
            }

            return letter;
        }

        char rotateSingleSmallCase(char letter)
        {
            return rotateInBoundries(letter, 'a', 'z');
        }

        char rotateSingleUpperCase(char letter)
        {
            return rotateInBoundries(letter, 'A', 'Z');
        }
    }
}
