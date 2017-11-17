using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class resultArray
    {
        private List<string> input;
        int count;
        public resultArray()
        {
            count = 0;
            input = new List<string>();
        }

        public string this[int index]
        {
            get
            {
                if(index < 0 || index > input.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return input[index];
                }
            }
            set
            {
                if (!(index < 0 || index > input.Count))
                {
                    input[index] = value;
                }

            }
        }
        
    }
}
