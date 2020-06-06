using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ConsoleApp71
{
    public class Engine
    {
        public string last;
        public string first;
        public Engine()
        {
            last = null;
            first = null;
        }
        public void format()
        {
            if (last != null)
            {
                last = last.ToLower();
                string name = (char)(last[0] - 32) + last.Substring(1);
                last = name;
            }
            if (first != null)
            {
                first = first.ToLower();
                string name = (char)(first[0] - 32) + first.Substring(1);
                first = name;
            }
        }
    }
}