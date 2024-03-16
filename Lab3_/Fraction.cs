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

        //Создание нового объекта-дроби с числителем и знаменателем
        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");
            numerator = num;
            denominator = den;
        }

        //Метод возвращает строковое представление дроби в формате числитель/знаменатель
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        //Реализация сложения дробей
        public Fraction Add(Fraction other)
        {
            int num = numerator * other.denominator + other.numerator * denominator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        //Реализация вычитания
        public Fraction Subtract(Fraction other)
        {
            int num = numerator * other.denominator - other.numerator * denominator;
            int den = denominator * other.denominator;
            return new Fraction(num, den).Simplify(); 
        }

        //Реализация умножения
        public Fraction Multiply(Fraction other)
        {
            int num = numerator * other.numerator;
            int den = denominator * other.denominator;
            return new Fraction(num, den);
        }

        //Реализация деления
        public Fraction Divide(Fraction other)
        {
            if (other.numerator == 0)
                throw new DivideByZeroException("На ноль делить нельзя");
            int num = numerator * other.denominator;
            int den = denominator * other.numerator;
            return new Fraction(num, den);
        }

        //Сокращение дроби
        public Fraction Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator)); //вычисление НОД для двух чисел
            int sign = Math.Sign(numerator) * Math.Sign(denominator); //определение знака результирующей дроби
            return new Fraction(sign * numerator / gcd, denominator / gcd);
        }

        //Сравнение дробей
        public int CompareTo(Fraction other)
        {
            int num1 = numerator * other.denominator;
            int num2 = other.numerator * denominator;
            return num1.CompareTo(num2);
        }

        //Вычисление наибольшего общего делителя с помощью алгоритма Евклида
        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        //Переопределяют базовые методы для корректного сравнения и хеширования объектов дробей
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Fraction other = (Fraction)obj;
            return this.numerator == other.numerator && this.denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }
    }
}

