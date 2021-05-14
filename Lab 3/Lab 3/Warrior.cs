using System;
using System.Runtime.InteropServices;

namespace Lab_3
{       
     class Warrior
       {
        int[] a;
        public int leng;
        public Warrior(int size)
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
