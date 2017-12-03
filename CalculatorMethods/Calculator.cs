using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorMethods
{
    public class Calculator
    {
        string BigNumberTotal = "";
        List<decimal> AllNumbers = new List<decimal>();
        List<char> ListofOperators = new List<char>();
        bool decimalpressed = false;
        bool NegativeNumberPressed = false;
        char lastOperator;
        decimal LastNumber;
        bool AlreadyPressedEquals = false;

        //public void ChristmasPress()
        //{

        //}


        public string NumberPress(string ButtonNum)
        {
            AlreadyPressedEquals = false;

            if (ButtonNum == "." && decimalpressed) //Stops repeats of "."
            {
                return BigNumberTotal;
            }

            if(ButtonNum== "±" && NegativeNumberPressed) //Stops repeats of "-"
            {
                BigNumberTotal = BigNumberTotal.TrimStart('-');
                NegativeNumberPressed = false;

                if (BigNumberTotal=="")
                {
                    return "0";
                }
                return BigNumberTotal;
            }

            if (ButtonNum == "±")
            {
                NegativeNumberPressed = true;
                BigNumberTotal = "-" + BigNumberTotal;

                if (BigNumberTotal == "-")
                {
                    return "-0";
                }
                return BigNumberTotal;
            }

            if (ButtonNum == ".") //if "." is pressed before any numbers add 0 to the string
            {
                if (BigNumberTotal.Length == 0||(BigNumberTotal.Length==1 &&NegativeNumberPressed))
                {
                    BigNumberTotal += "0";
                }
                decimalpressed = true;
            }

            int BigNumbersLength = BigNumberTotal.Length;
            if (NegativeNumberPressed)
            {
                BigNumbersLength--;
            }

            //This if statment enforces the maximum and minimum size rules
            if (BigNumbersLength < 10 || 
                (decimalpressed && BigNumberTotal.IndexOf('.') + 9 >= BigNumberTotal.Length)||
                (decimalpressed && BigNumberTotal.IndexOf('.') + 10 >= BigNumberTotal.Length && ButtonNum!="0")||
                ButtonNum ==".")
            {
                BigNumberTotal += ButtonNum;
            }

            return BigNumberTotal;
        }


        public void ClearBigNumber()
        {
            BigNumberTotal = "";
            decimalpressed = false;
            NegativeNumberPressed = false;
            AlreadyPressedEquals = false;
        }

        public string OperatorPress(string OperatorText)
        {
            AlreadyPressedEquals = false;
            decimalpressed = false;
            NegativeNumberPressed = false;

            if (BigNumberTotal=="-")
            {
                BigNumberTotal = "-0";
            }

            //if operator is pressed first before any numbers
            if (BigNumberTotal.Length==0 && AllNumbers.Count==0) 
            {
                AllNumbers.Add(0);
                ListofOperators.Add(char.Parse(OperatorText));
            }
            //changes operator
            else if (AllNumbers.Count() == ListofOperators.Count() && BigNumberTotal.Length==0)
            {
                ListofOperators[ListofOperators.Count - 1] = char.Parse(OperatorText);
            }
            else
            {
                AllNumbers.Add(decimal.Parse(BigNumberTotal));
                ListofOperators.Add(char.Parse(OperatorText));
                ClearBigNumber();
            }


            //Combins the full list and returns as a string
            var FullListOfNumbersAndOperators = new List<string>();
            for (int i = 0; i < AllNumbers.Count(); i++)
            {
                FullListOfNumbersAndOperators.Add($"{AllNumbers[i]}");
                FullListOfNumbersAndOperators.Add($" {ListofOperators[i]} ");
            }

            return FullListOfNumbersAndOperators.Aggregate((i, j) => i + j);
            
        }

        public string EqualsPress()
        {
            if (BigNumberTotal=="-")
            {
                BigNumberTotal = "0";
            }


            decimalpressed = false;
            NegativeNumberPressed = false;
            BigNumberTotal = BigNumberTotal == "" ? "0" : BigNumberTotal;
            AllNumbers.Add(decimal.Parse(BigNumberTotal));



 
            //If you press equals again it keeps doing the last operation
            if (AlreadyPressedEquals)
            {
                AllNumbers.Add(LastNumber);
                ListofOperators.Add(lastOperator);
            }

            //If you press no operators before pressing equals
            if (ListofOperators.Count == 0)
            {
                AllNumbers.RemoveAt(0);
                return BigNumberTotal;
            }

            lastOperator = ListofOperators.Last();
            LastNumber = AllNumbers.Last();
            
            AlreadyPressedEquals = true;
            string result = Calculate_Equals();

            return result;

        }

        public void Clear_All()
        {
            AlreadyPressedEquals = false;
            decimalpressed = false;
            NegativeNumberPressed = false;
            BigNumberTotal = "";
            AllNumbers.Clear();
            ListofOperators.Clear();
        }

        public string Back_Arrow()
        {
            AlreadyPressedEquals = false;
            if (BigNumberTotal.Length>1)
            {
                if (BigNumberTotal[BigNumberTotal.Length-1]=='.')
                {
                    decimalpressed = false;
                }
                BigNumberTotal = BigNumberTotal.Remove(BigNumberTotal.Length-1);
            }
            else if (BigNumberTotal == "-")
            {
                NegativeNumberPressed = false;
                BigNumberTotal = "";
            }
            else
            {
                BigNumberTotal = "";
            }

            return BigNumberTotal;

        }



        private string Calculate_Equals()
        {
            
            List<char> OperatorList = new List<char>() { '÷', '×', '+', '-' };

            foreach (char operatorchar in OperatorList)
            {
                while (ListofOperators.Contains(operatorchar))
                {
                    decimal TemporaryTotal = 0;
                    int Index = ListofOperators.FindIndex(x => x == operatorchar);


                    switch (ListofOperators[Index])
                    {
                        case '+':
                            TemporaryTotal += AllNumbers[Index] + AllNumbers[Index + 1];
                            break;
                        case '-':
                            TemporaryTotal += AllNumbers[Index] - AllNumbers[Index + 1];
                            break;
                        case '÷':
                            if (AllNumbers[Index + 1]==0)
                            {
                                Clear_All();
                                return "Cannot ÷ by 0";
                            }
                            TemporaryTotal += AllNumbers[Index] / AllNumbers[Index + 1];
                            break;
                        case '×':
                            TemporaryTotal += AllNumbers[Index] * AllNumbers[Index + 1];
                            break;
                    }

                    if (Math.Abs(TemporaryTotal) >= 10000000000)
                    {
                        Clear_All();
                        return "Num too large";
                    }

                    if (Math.Abs(TemporaryTotal) < (decimal)0.0000000001 && TemporaryTotal!=0)
                    {
                        Clear_All();
                        return "Num too small";
                    }

                    AllNumbers.RemoveAt(Index + 1);
                    ListofOperators.RemoveAt(Index);
                    AllNumbers[Index] = TemporaryTotal;
                    
                }
            }

            AllNumbers[0] = Math.Round(AllNumbers[0], 10);
            BigNumberTotal = AllNumbers[0].ToString();
            AllNumbers.RemoveAt(0);


            if (BigNumberTotal.Contains("."))
            {
                BigNumberTotal = BigNumberTotal.TrimEnd('0');
            }

            if (BigNumberTotal.ElementAt(BigNumberTotal.Length - 1) == '.')
            {
                BigNumberTotal = BigNumberTotal.Remove(BigNumberTotal.Length - 1);
            }


            return BigNumberTotal;

        }
        




    }
}
