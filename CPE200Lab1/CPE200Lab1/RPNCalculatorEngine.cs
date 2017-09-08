using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {

        public string Process(string str)
        {
            
            Stack stack = new Stack();           
            string[] parts = str.Split(' ');
            string result = " ";
            int count = 0;
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    stack.Push(parts[i]);                    
                }
                else if (isOperator(parts[i]))
                {
                    string second = stack.Pop().ToString();
                    string first = stack.Pop().ToString();
                    result = calculate(parts[i], first, second);
                    stack.Push(result);
                }
            }
            return stack.Pop().ToString();
        }
    }
}
