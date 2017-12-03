using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorMethods;

namespace Calculator_UI
{
    public partial class CalculatorForm : Form
    {
        Calculator Calc = new Calculator();
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void number_Button_Click(object sender, EventArgs e)
        {
            string Number = (sender as Button).Text;
            TextBoxBig.Text = Calc.NumberPress(Number);
        }

        private void buttonClearNumber_Click(object sender, EventArgs e)
        {
            Calc.ClearBigNumber();
            TextBoxBig.Text = "0";
        }

        private void Operator_Button_Click(object sender, EventArgs e)
        {
            string OperatorText = (sender as Button).Text;
            string FullTextSoFar = Calc.OperatorPress(OperatorText);
            TextBoxFull.Text = FullTextSoFar;
            TextBoxBig.Text = "0";
        }

        private void equals_Button_Click(object sender, EventArgs e)
        {
            string result = Calc.EqualsPress();
            TextBoxBig.Text = result;
            TextBoxFull.Text = "";
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            Calc.Clear_All();
            TextBoxBig.Text = "0";
            TextBoxFull.Text = "";
        }

        private void buttonBackArrow_Click(object sender, EventArgs e)
        {
            string BigText = Calc.Back_Arrow();
            TextBoxBig.Text = BigText.Length > 0 ? BigText : "0";
        }

        private void buttonChristmas_Click(object sender, EventArgs e)
        {
            //Calc.ChristmasPress();
        }
    }
}
