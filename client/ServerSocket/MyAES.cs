using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSocket
{
    [Serializable]
    public class MyAES
    {
        public byte[] key;
        public byte[] IV;

        public MyAES(byte[] key, byte[] IV)
        {
            this.key = key;
            this.IV = IV;
        }
    }
}
