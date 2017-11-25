using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class AsyncObject
    {
        public Byte[] buffer;
        public Socket workingsocket;
        public int bufferSize;
        public AsyncObject(int buffersize)
        {
            this.bufferSize = buffersize;
            this.buffer = new Byte[this.bufferSize];
        }
        public void ClearBuffer()
        {
            Array.Clear(buffer, 0, bufferSize);
        }
    }
}
