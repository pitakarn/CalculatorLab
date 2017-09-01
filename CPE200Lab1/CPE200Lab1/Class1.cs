using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {            
            switch (operate)
            {
                
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result1;
                        string[] parts1;
                        int remainLength1;

                        result1 = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts1 = result1.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts1[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength1 = maxOutputSize - parts1[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result1.ToString("N" + remainLength1);
                    }
                    break;
               
                    // your code here
                   
                    

               
            }
            return "E";
        }

    }
}
