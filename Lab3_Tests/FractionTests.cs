using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_.Tests
{
    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        public void Add_TwoFractions_ReturnsCorrectFraction()
        {
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(1, 3);
            Fraction result = fraction1.Add(fraction2);
            Assert.AreEqual(new Fraction(5, 6), result);
        }

        [TestMethod]
        public void Subtract_TwoFractions_ReturnsCorrectFraction()
        {
            Fraction fraction1 = new Fraction(3, 4);
            Fraction fraction2 = new Fraction(1, 4);
            Fraction result = fraction1.Subtract(fraction2);
            Assert.AreEqual(new Fraction(1, 2), result);
        }

        [TestMethod]
        public void Multiply_TwoFractions_ReturnsCorrectFraction()
        {
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(2, 3);
            Fraction result = fraction1.Multiply(fraction2);
            Assert.AreEqual(new Fraction(2, 6), result);
        }

        [TestMethod]
        public void Divide_TwoFractions_ReturnsCorrectFraction()
        {
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(2, 3);
            Fraction result = fraction1.Divide(fraction2);
            Assert.AreEqual(new Fraction(3, 4), result);
        }

        
        [TestMethod]
        public void Simplify_Fraction_ReturnsSimplifiedFraction()
        {
            Fraction fraction = new Fraction(6, 8);
            Fraction result = fraction.Simplify();
            Assert.AreEqual(new Fraction(3, 4), result);
            Assert.IsTrue(result.denominator > 0); // Проверка на положительный знаменатель
        }


        [TestMethod]
        public void CompareTo_TwoFractions_ReturnsCorrectComparison()
        {
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(2, 4);
            int result = fraction1.CompareTo(fraction2);
            Assert.AreEqual(0, result); // Fractions are equal
        }
    }
}
