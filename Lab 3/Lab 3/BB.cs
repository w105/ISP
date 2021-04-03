using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    class BB
    {
        int[] a;
        public int leng;
        public BB(int size)
        {
            a = new int [size];
            leng = size;
        }
        public int this[int index]
        {
            set
            {
                a[index] = value; 
            }

            get
            { 
                return a[index];
            }
        }
    }
}
