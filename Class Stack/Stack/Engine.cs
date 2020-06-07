using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<stiva>
    {
        public stiva[] items;
        private int index;

        public int Ct
        {
            get { return index >= 0 ? index + 1 : 0; }
            set { index = value; }
        }

        public Stack(int cantity)
        {
            index = -1;
            items = new stiva[cantity];
        }

        public void inn(stiva item)
        {
            if (index + 1 >= items.Length)
            {
                Console.WriteLine("Stack ul este plin");
            }
            else
            {
                index++;
                items[index] = item;
            }
        }

        public stiva ok()
        {
            if (index < 0) { Console.WriteLine("Nu mai avem ce sa scoatem din Stack"); return default; }

            stiva value = items[index];
            items[index] = default;
            index--;
            return value;
        }

        public void Clear()
        {
            index = 0;
            items = new stiva[items.Length];
        }
    }
}