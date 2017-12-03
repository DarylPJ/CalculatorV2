using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorMethods;

namespace Calculator_V2.Test
{
    [TestClass]
    public class Calculator_Test
    {
        [TestMethod]
        public void Input_5_return_5()
        {
            var calc = new Calculator();

            string Result = calc.NumberPress("5");
            Assert.AreEqual("5", Result);

        }

        [TestMethod]
        public void Input_12345_return_12345()
        {
            var calc = new Calculator();

            calc.NumberPress("1");
            calc.NumberPress("2");
            calc.NumberPress("3");
            calc.NumberPress("4");
            string Result = calc.NumberPress("5");

            Assert.AreEqual("12345", Result);
        }

        [TestMethod]
        public void Input_67_CE_89_return_89()
        {
            var calc = new Calculator();

            calc.NumberPress("6");
            calc.NumberPress("7");
            calc.ClearBigNumber();
            calc.NumberPress("8");
            string Result = calc.NumberPress("9");

            Assert.AreEqual("89", Result);
        }

        [TestMethod]
        public void Input_23_pluse_9_NumberPress_returns_9()
        {
            var calc = new Calculator();

            calc.NumberPress("2");
            calc.NumberPress("3");
            calc.OperatorPress("+");
            string Result = calc.NumberPress("9");

            Assert.AreEqual("9", Result);
        }

        [TestMethod]
        public void Input_29_pluse_5_Equals_returns_34()
        {
            var calc = new Calculator();
            calc.NumberPress("2");
            calc.NumberPress("9");
            calc.OperatorPress("+");
            calc.NumberPress("5");
            string result = calc.EqualsPress();

            Assert.AreEqual("34", result);
        }

        [TestMethod]
        public void Input_15_minus_10_return_5()
        {
            var calc = new Calculator();
            calc.NumberPress("1");
            calc.NumberPress("5");
            calc.OperatorPress("-");
            calc.NumberPress("1");
            calc.NumberPress("0");
            string result = calc.EqualsPress();

            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void Input_2_pluse_3_pluse_5_equals_returns_10()
        {
            var calc = new Calculator();
            calc.NumberPress("2");
            calc.OperatorPress("+");
            calc.NumberPress("3");
            calc.OperatorPress("+");
            calc.NumberPress("5");
            string result = calc.EqualsPress();

            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void BODMAS_Check_Input_5_add_3_times_4_returns_17()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.OperatorPress("+");
            calc.NumberPress("3");
            calc.OperatorPress("×");
            calc.NumberPress("4");
            string result = calc.EqualsPress();

            Assert.AreEqual("17", result);
        }

        [TestMethod]
        public void Operator_Button_Outputs_equation()
        {
            var calc = new Calculator();

            calc.NumberPress("2");
            string result = calc.OperatorPress("+");

            Assert.AreEqual("2 + ",result);
        }

        [TestMethod]
        public void Complex_Operator_Button_Outputs_equation()
        {
            var calc = new Calculator();

            calc.NumberPress("2");
            calc.OperatorPress("+");
            calc.NumberPress("5");
            string result = calc.OperatorPress("-");

            Assert.AreEqual("2 + 5 - ", result);
        }

        [TestMethod]
        public void Clear_All_Button()
        {
            var calc = new Calculator();

            calc.NumberPress("2");
            calc.OperatorPress("+");
            calc.NumberPress("5");
            calc.Clear_All();
            calc.NumberPress("9");
            string result = calc.OperatorPress("-");

            Assert.AreEqual("9 - ", result);
        }

        [TestMethod]
        public void Back_Arrow_Pressed()
        {
            var calc = new Calculator();

            calc.NumberPress("1");
            calc.NumberPress("5");
            string result = calc.Back_Arrow();

            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void Decimals()
        {
            var calc = new Calculator();

            calc.NumberPress("6");
            calc.NumberPress(".");
            calc.NumberPress("9");
            calc.NumberPress(".");
            calc.NumberPress("3");
            string result = calc.OperatorPress("+");

            Assert.AreEqual("6.93 + ", result);
        }

        [TestMethod]
        public void repeat_operators()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.OperatorPress("+");
            string result = calc.OperatorPress("-");

            Assert.AreEqual("5 - ", result);
        }

        [TestMethod]
        public void Negative_First()
        {
            var calc = new Calculator();

            calc.OperatorPress("-");
            calc.NumberPress("5");
            string result = calc.OperatorPress("÷");
            Assert.AreEqual("0 - 5 ÷ ", result);
        }

        [TestMethod]
        public void Divide_First()
        {
            var calc = new Calculator();

            calc.OperatorPress("÷");
            calc.NumberPress("5");
            string result = calc.OperatorPress("÷");
            Assert.AreEqual("0 ÷ 5 ÷ ", result);
        }

        [TestMethod]
        public void Press_equals_No_number()
        {
            var calc = new Calculator();
            calc.NumberPress("2");
            calc.OperatorPress("+");
            string result = calc.EqualsPress();

            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void Press_equals_twice()
        {
            var calc = new Calculator();
            calc.NumberPress("2");
            calc.OperatorPress("+");
            calc.EqualsPress();
            string result = calc.EqualsPress();

            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void Press_equals_twice_after_calculation()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.OperatorPress("+");
            calc.NumberPress("2");
            calc.EqualsPress();
            calc.EqualsPress();
            string result = calc.EqualsPress();

            Assert.AreEqual("11", result);


        }

        [TestMethod]
        public void TooBigANumber()
        {
            var calc = new Calculator();
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.OperatorPress("+");
            calc.NumberPress("1");
            var result = calc.EqualsPress();

            Assert.AreEqual("Num too large",result);
        }

        [TestMethod]
        public void TooBigANumberBoundary()
        {
            var calc = new Calculator();
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("8");
            calc.OperatorPress("+");
            calc.NumberPress("1");
            var result = calc.EqualsPress();

            Assert.AreEqual("9999999999", result);
        }

        [TestMethod]
        public void TooSmallNumber()
        {
            var calc = new Calculator();

            calc.NumberPress("0");
            calc.NumberPress(".");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("0");
            calc.NumberPress("1");
            calc.OperatorPress("÷");
            calc.NumberPress("2");
            var result = calc.EqualsPress();

            Assert.AreEqual("Num too small", result);
        }

        [TestMethod]
        public void Divide_by_zero()
        {
            var calc = new Calculator();

            calc.NumberPress("1");
            calc.OperatorPress("÷");
            calc.NumberPress("0");
            var result = calc.EqualsPress();

            Assert.AreEqual("Cannot ÷ by 0",result);
        }

        [TestMethod]
        public void BackArrow_after_Equals()
        {
            var calc = new Calculator();

            calc.NumberPress("9");
            calc.OperatorPress("+");
            calc.NumberPress("9");
            calc.EqualsPress();
            calc.Back_Arrow();
            calc.NumberPress("5");
            calc.OperatorPress("-");
            calc.NumberPress("5");
            string result = calc.EqualsPress();

            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void Same_Number_of_numbers_and_operators_when_Equals_pressed()
        {
            var calc = new Calculator();

            calc.NumberPress("1");
            calc.OperatorPress("+");
            calc.NumberPress("6");
            calc.OperatorPress("-");
            var result = calc.EqualsPress();

            Assert.AreEqual("7", result);


        }

        [TestMethod]
        public void Number_Equals_Operator_Equals()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.EqualsPress();
            calc.OperatorPress("+");
            string result = calc.EqualsPress();

            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void Multiply_By_a_Negative_Number()
        {
            var calc = new Calculator();

            calc.NumberPress("2");
            calc.OperatorPress("×");
            calc.NumberPress("±");
            calc.NumberPress("2");
            string result = calc.EqualsPress();

            Assert.AreEqual("-4", result);
        }

        [TestMethod]
        public void Multiple_Negatives()
        {
            var calc = new Calculator();

            calc.NumberPress("±");
            calc.NumberPress("±");
            calc.NumberPress("±");
            string result = calc.NumberPress("5");

            Assert.AreEqual("-5", result);
        }

        [TestMethod]
        public void NegtiveTooBigANumberBoundary()
        {
            var calc = new Calculator();
            calc.NumberPress("±");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("9");
            calc.NumberPress("8");
            calc.OperatorPress("-");
            calc.NumberPress("1");
            var result = calc.EqualsPress();

            Assert.AreEqual("-9999999999", result);
        }

        [TestMethod]
        public void Negative_after_numbers()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            string result = calc.NumberPress("±");

            Assert.AreEqual("-5", result);
        }

        [TestMethod]
        public void Number_Negative_BackArrow()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.NumberPress("±");
            calc.Back_Arrow();
            string result = calc.EqualsPress();

            Assert.AreEqual("0", result);            
        }

        [TestMethod]
        public void Negative_Number_clearAll_number_equals()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.NumberPress("±");
            calc.Clear_All();
            string result = calc.NumberPress("3");

            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void Negative_Number_clear_number_equals()
        {
            var calc = new Calculator();

            calc.NumberPress("5");
            calc.NumberPress("±");
            calc.ClearBigNumber();
            string result = calc.NumberPress("3");

            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void BigNumber_Negative_backarrow_negative_7()
        {
            var calc = new Calculator();

            calc.NumberPress("±");
            calc.Back_Arrow();
            calc.NumberPress("±");
            string result = calc.NumberPress("7");

            Assert.AreEqual("-7", result);
        }

        [TestMethod]
        public void Equals_Negative_backarrow_negative_7()
        {
            var calc = new Calculator();

            calc.NumberPress("±");
            calc.Back_Arrow();
            calc.NumberPress("±");
            calc.NumberPress("7");
            string result = calc.EqualsPress();

            Assert.AreEqual("-7", result);
        }

        [TestMethod]
        public void Dot_9_returns_0dot9()
        {
            var calc = new Calculator();

            calc.NumberPress(".");
            string result = calc.NumberPress("9");

            Assert.AreEqual("0.9", result);
        }

        [TestMethod]
        public void Negative_Dot_9_returns_negative_0dot9()
        {
            var calc = new Calculator();

            calc.NumberPress("±");
            calc.NumberPress(".");
            string result = calc.NumberPress("9");

            Assert.AreEqual("-0.9", result);
        }

        [TestMethod]
        public void Back_to_positve()
        {
            var calc = new Calculator();

            calc.NumberPress("8");
            calc.NumberPress("3");
            calc.NumberPress("±");
            string result = calc.NumberPress("±");

            Assert.AreEqual("83", result);
        }

        [TestMethod]
        public void Negative_Times()
        {
            var calc = new Calculator();

            calc.NumberPress("±");
            string result = calc.OperatorPress("+");

            Assert.AreEqual("0 + ",result);
        }

    }
}
