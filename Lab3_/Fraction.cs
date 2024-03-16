using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_
{
    public class Fraction
    {
        public int numerator;
        public int denominator;

        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");
            numerator = num;
            denominator = den;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public Fraction Add(Fraction other)
        {
            int num = numerator * other.denominator + other.numerator * denominator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        public Fraction Subtract(Fraction other)
        {
            int num = numerator * other.denominator - other.numerator * denominator;
            int den = denominator * other.denominator;
            return new Fraction(num, den).Simplify();
        }


        public Fraction Multiply(Fraction other)
        {
            int num = numerator * other.numerator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        public Fraction Divide(Fraction other)
        {
            if (other.numerator == 0)
                throw new DivideByZeroException("На ноль делить нельзя");
            int num = numerator * other.denominator;
            int den = denominator * other.numerator;
            return new Fraction(num, den);
        }

        public Fraction Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            int sign = Math.Sign(numerator) * Math.Sign(denominator); // Preserve the sign of the fraction
            return new Fraction(sign * numerator / gcd, denominator / gcd);
        }


        public int CompareTo(Fraction other)
        {
            int num1 = numerator * other.denominator;
            int num2 = other.numerator * denominator;
            return num1.CompareTo(num2);
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public override bool Equals(object obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            Fraction other = (Fraction)obj;
            return this.numerator == other.numerator && this.denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(numerator, denominator).GetHashCode();
        }



    }
}

