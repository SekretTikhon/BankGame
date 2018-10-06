using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public struct Date : IComparable
    {
        private int months;
        public int Months
        {
            get { return months; }
            private set { months = value; }
        }
        public int Year
        {
            get { return months / 12; }
        }
        public int Month
        {
            get {  return months % 12; }
        }
        
        public Date(int months)
        {
            this.months = months;
        }

        public Date(int year, int month)
        {
            this.months = year * 12 + month;
        }

        public void increment()
        {
            months++;
        }

        public int CompareTo(object obj)
        {
            return Months.CompareTo(((Date)obj).Months);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Date)) return false;
            return Months.Equals(((Date)obj).Months);
        }

        public override int GetHashCode()
        {
            return Months;
        }

        public override string ToString()
        {
            return Year + " Yaer, " + Month + " Month";
        }

        public string ToShortString()
        {
            return Year + "Y " + Month + "M";
        }

        public string ToMonthString()
        {
            return Months + "M";
        }

        public static bool operator ==(Date a, Date b)
        {
            return a.Months == b.Months;
        }

        public static bool operator ==(Date a, int b)
        {
            return a.Months == b;
        }

        public static bool operator !=(Date a, Date b)
        {
            return a.Months != b.Months;
        }

        public static bool operator !=(Date a, int b)
        {
            return a.Months != b;
        }

        public static bool operator <(Date a, Date b)
        {
            return a.Months < b.Months;
        }

        public static bool operator >(Date a, Date b)
        {
            return a.Months > b.Months;
        }

        public static bool operator <=(Date a, Date b)
        {
            return a.Months <= b.Months;
        }

        public static bool operator >=(Date a, Date b)
        {
            return a.Months >= b.Months;
        }

        public static Date operator +(Date a, Date b)
        {
            return new Date(a.Months + b.Months);
        }

        public static Date operator +(Date a, int b)
        {
            return new Date(a.Months + b);
        }

        public static Date operator -(Date a, Date b)
        {
            if (a < b) throw new Exception("sub date < 0");
            return new Date(a.Months - b.Months);
        }

        public static Date operator -(Date a, int b)
        {
            return new Date(a.Months - b);
        }

        public static implicit operator Date(int i)
        {
            return new Date(i);
        }

        public static implicit operator int(Date a)
        {
            return a.Months;
        }

    }
}
