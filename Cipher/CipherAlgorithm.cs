using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    interface CipherAlgorithm
    {
        string to(string input);
        string from(string input);
    }
}
