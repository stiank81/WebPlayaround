
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalc
{
    public class StringCalc
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var numberList = PrepareNumberList(numbers);
 
            var sum = 0;
            var negativeNumbers = new List<int>(); 
            
            foreach (var number in numberList)
            {
                var numAsInt = int.Parse(number);
                if (numAsInt > 1000)
                    continue;

                if (numAsInt < 0)
                    negativeNumbers.Add(numAsInt);
                sum += numAsInt; 
            }

            if (negativeNumbers.Count > 0)
                ThrowNegativeNumbersException(negativeNumbers); 

            return sum; 
        }

        private string[] PrepareNumberList(string numbers)
        {
            var delimiters = GetDelimiters(numbers);

            if (delimiters.Length > 2)
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);

            return numbers.Split(delimiters);
        }         

        private char[] GetDelimiters(string numbers)
        {
            if ((numbers.Length >= 3) && numbers.StartsWith("\\") && (numbers[2] == '\n'))
                return new char[3] {',', '\n', numbers[1]};

            return new char[2] {',', '\n'};
        }

        private void ThrowNegativeNumbersException(List<int> negativeNumbers)
        {
            var msg = "Negative numbers not allowed: ";
            foreach (var num in negativeNumbers)
            {
                msg = msg + ", " + num; 
            }
            throw new ArgumentException(msg); 
        }

    }
}
