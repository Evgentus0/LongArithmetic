using System;
using System.Collections.Generic;
using Long_Arithmetic_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Long_Arithmetic_Tests
{
    [TestClass]
    public class NumberTests
    {
        #region Number

        [TestMethod]
        public void ToString_25_return_25()
        {
            var number = new Number(25);

            string result = number.ToString();

            Assert.AreEqual("25", result);
        }

        [TestMethod]
        public void Greater_5_great_3_return_true()
        {
            var a = new Number(5);
            var b = new Number(3);

            bool result = a > b;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotEqual_5_great_3_return_true()
        {
            var a = new Number(5);
            var b = new Number(3);

            bool result = a != b;

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void GreaterOrEqual_7_great_7_return_true()
        {
            var a = new Number(7);
            var b = new Number(7);

            bool result = a >= b;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equal_7_great_7_return_true()
        {
            var a = new Number(7);
            var b = new Number(7);

            bool result = a == b;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ToString_11234567896_return_11234567896_String()
        {
            Number a = new Number("11234567896");

            string result = a.ToString();

            Assert.AreEqual("11234567896", result);
        }

        [TestMethod]
        public void ToString_1000000045_return_1000000045_String()
        {
            Number a = new Number("1000000045");

            string result = a.ToString();

            Assert.AreEqual("1000000045", result);
        }
        #endregion

        #region Calculator

        [TestMethod]
        public void Add_5_plus_7_return_12()
        {
            var a = new Number(5);
            var b = new Number(7);

            var result = Number.Add(a, b).ToString();

            Assert.AreEqual("12", result);
        }

        [TestMethod]
        public void Add_80_plus_85_return_165()
        {
            var a = new Number(80);
            var b = new Number(85);

            var result = Number.Add(a, b).ToString();

            Assert.AreEqual("165", result);
        }

        [TestMethod]
        public void Subtract_45_minus_20_return_25()
        {
            var a = new Number(45);
            var b = new Number(20);

            var result = Number.Subtract(a, b).ToString();

            Assert.AreEqual("25", result);
        }

        [TestMethod]
        public void Subtract_198_minus_37_return_161()
        {
            var a = new Number(198);
            var b = new Number(37);

            var result = Number.Subtract(a, b).ToString();

            Assert.AreEqual("161", result);
        }

        [TestMethod]
        public void Subtract_10_minus_15_return_minus_5()
        {
            var a = new Number(10);
            var b = new Number(15);

            var result = Number.Subtract(a, b).ToString();

            Assert.AreEqual("-5", result);
        }

        [TestMethod]
        public void Multiply_5_multiply_3_return_15()
        {
            var a = new Number(5);
            var b = new Number(3);

            string result = Number.Multiply(a, b).ToString();

            Assert.AreEqual("15", result);
        }

        [TestMethod]
        public void Multiply_15_multiply_14_return_210()
        {
            var a = new Number(15);
            var b = new Number(14);

            string result = Number.Multiply(a, b).ToString();

            Assert.AreEqual("210", result);
        }

        [TestMethod]
        public void Exponent_5_exp_3_return_125()
        {
            var a = new Number(5);
            var b = new Number(3);

            string result = Number.Exponent(a, b).ToString();

            Assert.AreEqual("125", result);
        }

        [TestMethod]
        public void Divide_180_div_33_return_5_carry_15()
        {
            var a = new Number(180);
            var b = new Number(33);


            var result = Number.Divide(a, b);


            Assert.AreEqual("5", result.result.ToString());
            Assert.AreEqual("15", result.rest.ToString());
        }

        [TestMethod]
        public void Divide_12536_div_5665_return_2_carry_1206()
        {
            var a = new Number(12536);
            var b = new Number(5665);


            var result = Number.Divide(a, b);

            Assert.AreEqual("2", result.result.ToString());
            Assert.AreEqual("1206", result.rest.ToString());
        }

        [TestMethod]
        public void Divide_10000_div_10_return_1000_carry_0()
        {
            var a = new Number(10000);
            var b = new Number(10);


            var result = Number.Divide(a, b);

            Assert.AreEqual("1000", result.result.ToString());
            Assert.AreEqual("0", result.rest.ToString());
        }

        [TestMethod]
        public void Module_124124_div_5614_return_616()
        {
            var a = new Number(124124);
            var b = new Number(5614);


            string result = Number.Module(a, b).ToString();

            Assert.AreEqual("616", result);
        }

        [TestMethod]
        public void ExponentWithModule_4132_pow_3_mod_1524_return_1504()
        {
            var a = new Number(4132);
            var b = new Number(3);
            var module = new Number(1524);

            string result = Number.ExponentWithModule(a, b, module).ToString();

            Assert.AreEqual("1504", result);
        }

        [TestMethod]
        public void Sqrt_4312_return_65()
        {
            var a = new Number(4312);

            string result = Number.Sqrt(a).ToString();

            Assert.AreEqual("65", result);
        }
        #endregion
    }
}
