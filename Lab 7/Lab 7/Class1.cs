using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class RationalNumber : IComparable, IEquatable<RationalNumber>
    {
        private int _n;
        private int _m;

        public RationalNumber(int n, int m)
        {
            if (n % 1 == 0 && m % 1 == 0)
            {
                _n = n;
                _m = m;
            }
            else
                throw new Exception("Numbers are not integer!");
        }
        public int Name { get; set; }
        public int CompareTo(object obj)
        {
            if (obj is RationalNumber p)
            {
                if (this > p)
                    return 1;
                else if (this < p)
                    return -1;
                else return 0;
            }
            else
                throw new Exception("Unable to compare these two objects!");
        }
        public bool Equals(RationalNumber other)
        {
            if (other == null)
                return false;
            if (this._n == other._n)
                return true;
            else
                return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            RationalNumber exObj = obj as RationalNumber;
            if (exObj == null)
                return false;
            else
                return Equals(exObj);
        }
        public override int GetHashCode()
        {
            if (this.Name == 0)
            {
                return 0;
            }
            else
            {
                return this.Name.GetHashCode();
            }
        }

        public static bool operator ==(RationalNumber security1, RationalNumber security2)
        {
            if (security1 is null || (security2) is null)
            {
                return Object.Equals(security1, security2);
            }

            return security1.Equals(security2);
        }
        public static bool operator !=(RationalNumber security1, RationalNumber security2) => !(security1 == security2);

        public static RationalNumber operator +(RationalNumber o1, RationalNumber o2)
        {
            RationalNumber result;

            if (o1._m == o2._m)
                result = new RationalNumber(o1._n + o2._n, o1._m);
            else
                result = new RationalNumber((o1._n * o2._m) + (o2._n * o1._m), o1._m * o2._m);

            return result;
        }
        public static RationalNumber operator -(RationalNumber o1, RationalNumber o2)
        {
            RationalNumber result;

            if (o1._m == o2._m)
                result = new RationalNumber(o1._n - o2._n, o1._m);
            else
                result = new RationalNumber((o1._n * o2._m) - (o1._m * o2._n), o1._m * o2._m);
            return result;
        }

        public static RationalNumber operator *(RationalNumber o1, RationalNumber o2)
        {
            RationalNumber result = new RationalNumber(o1._n * o2._n, o1._m * o2._m);
            return result;
        }

        public static RationalNumber operator /(RationalNumber o1, RationalNumber o2)
        {
            RationalNumber result = new RationalNumber(o1._n * o2._m, o1._m * o2._n);
            return result;
        }

        public static bool operator >(RationalNumber o1, RationalNumber o2)
        {
            if (o1._n == o2._n && o1._m == o2._m)
                return false;
            else if (o1._m == o2._m & o1._n > o2._n)
                return true;
            else if (o1._n == o2._n & o1._m < o2._m)
                return true;
            else if (o1._n != o2._n & o1._m != o2._m)
            {
                RationalNumber resultOne = new RationalNumber(o1._n * o2._m, o1._m * o2._m);
                RationalNumber resultTwo = new RationalNumber(o2._n * o1._m, o1._m * o2._m);

                if (resultOne._n > resultTwo._n)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool operator <(RationalNumber o1, RationalNumber o2)
        {
            if (o1._n == o2._n & o1._m == o2._m)
                return false;
            else if (o1._m == o2._m && o1._n < o2._n)
                return true;
            else if (o1._n == o2._n & o1._n > o2._m)
                return true;
            else if (o1._n != o2._n & o1._m != o2._m)
            {
                RationalNumber resultOne = new RationalNumber(o1._n * o2._m, o1._m * o2._m);
                RationalNumber resultTwo = new RationalNumber(o2._n * o1._m, o1._m * o2._m);

                if (resultOne._n < resultTwo._n)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator >=(RationalNumber o1, RationalNumber o2)
        {
            if (o1._n == o2._n && o1._m == o2._m)
                return true;
            else if (o1._m == o2._m & o1._n > o2._n)
                return true;
            else if (o1._n == o2._n & o1._m < o2._m)
                return true;
            else if (o1._n != o2._n & o1._n != o2._n)
            {
                RationalNumber resultOne = new RationalNumber(o1._n * o2._m, o1._m * o2._m);
                RationalNumber resultTwo = new RationalNumber(o2._m * o1._m, o1._m * o2._m);

                if (resultOne._n > resultTwo._n)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static bool operator <=(RationalNumber o1, RationalNumber o2)
        {
            if (o1._n == o2._n & o1._m == o2._m)
                return true;
            else if (o1._m == o2._m && o1._n < o2._n)
                return true;
            else if (o1._n == o2._n & o1._m > o2._m)
                return true;
            else if (o1._n != o2._n & o1._m != o2._m)
            {
                RationalNumber resultOne = new RationalNumber(o1._n * o2._m, o1._m * o2._m);
                RationalNumber resultTwo = new RationalNumber(o2._n * o1._m, o1._m * o2._m);

                if (resultOne._n < resultTwo._n)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return $"{_n} / {_m}";
        }

        public static implicit operator int(RationalNumber fraction)
        {
            return (fraction._n / fraction._m);
        }

        public static explicit operator double(RationalNumber fraction)
        {
            return (double)fraction._n / fraction._m;
        }

    }
}