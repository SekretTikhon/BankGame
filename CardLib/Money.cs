using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLib
{
    public struct Money : IComparable, IComparable<int>, IEquatable<int>
    {
        public int Value { get; private set; }
        public Money(int value)
        {
            Value = value;
        }
        
        public int CompareTo(object obj)
        {
            Money money = (Money)obj;
            return Value.CompareTo(money.Value);
        }

        public int CompareTo(int other)
        {
            return Value.CompareTo(other);
        }

        public bool Equals(int other)
        {
            return Value.Equals(other);
        }

        override public string ToString()
        {
            if (Value < 1000)
            {
                return Value + "K";
            }
            else if (Value % 1000 == 0)
            {
                return (Value / 1000) + "M";
            }
            else if (Value % 100 == 0)
            {
                return (Value / 1000) + "." + (Value % 1000 / 100) + "M";
            }
            else
            {
                return (Value / 1000) + "M " + (Value % 1000) + "K";
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Money)) return false;
            return Value.Equals(((Money)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(Money a, Money b)
        {
            return a.Value != b.Value;
        }

        public static bool operator <(Money a, Money b)
        {
            return a.Value < b.Value;
        }

        public static bool operator >(Money a, Money b)
        {
            return a.Value > b.Value;
        }

        public static bool operator <=(Money a, Money b)
        {
            return a.Value <= b.Value;
        }

        public static bool operator >=(Money a, Money b)
        {
            return a.Value >= b.Value;
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Value + b.Value);
        }

        public static Money operator +(Money a, int b)
        {
            return new Money(a.Value + b);
        }

        public static Money operator -(Money a, Money b)
        {
            //if (b > a) throw new ArithmeticException("Money, разница меньше нуля");
            return new Money(a.Value - b.Value);
        }

        public static Money operator *(Money a, int b)
        {
            return new Money(a.Value * b);
        }

        public static Money operator /(Money a, int b)
        {
            return new Money(a.Value / b);
        }

        public static implicit operator Money(int i)
        {
            return new Money(i);
        }

    }
}
