
using System;
using NUnit.Framework; 

namespace StringCalc.Test
{
    [TestFixture]
    public class TestStringCalc
    {
        private StringCalc _calc;

        [SetUp]
        public void Setup()
        {
            _calc = new StringCalc(); 
        }
     
        [Test]
        public void Add_Empty_Zero()
        {
            Assert.AreEqual(0, _calc.Add(string.Empty));
        }
        
        [Test]
        public void Add_OneNumber_NumberAsInt()
        {
            const int number = 7;
            var numAsString = number.ToString(); 
            Assert.AreEqual(number, _calc.Add(numAsString));
        }

        [Test]
        public void Add_TwoNumbers_Sum()
        {
            const int num1 = 7;
            const int num2 = 11;
            var numString = num1 + "," + num2; 
            Assert.AreEqual(num1 + num2, _calc.Add(numString));
        }
        
        [Test]
        public void Add_ThreeNumbers_Sum()
        {
            const int num1 = 7;
            const int num2 = 11;
            const int num3 = 17;
            var numString = num1 + "," + num2 + "," + num3;  
            Assert.AreEqual(num1 + num2 + num3, _calc.Add(numString));
        }

        [Test]
        public void Add_OnlyNewlineAsSeparator_Sum()
        {
            const int num1 = 1;
            const int num2 = 2;
            const int num3 = 3;
            var numString = num1 + "\n" + num2 + "\n" + num3; 
            Assert.AreEqual(num1 + num2 + num3, _calc.Add(numString));
        }
        
        [Test]
        public void Add_NewlineAndCommaSeparator_Sum()
        {
            const int num1 = 1;
            const int num2 = 2;
            const int num3 = 3;
            var numString = num1 + "\n" + num2 + "," + num3; 
            Assert.AreEqual(num1 + num2 + num3, _calc.Add(numString));
        }

        [Test]
        public void Add_UsingCustomDelimiter_Sum()
        {
            const int num1 = 1;
            const int num2 = 2;
            const int num3 = 3;
            var numString = "\\;\n" + num1 + ";" + num2 + ";" + num3;
            Assert.AreEqual(num1 + num2 + num3, _calc.Add(numString));
        }

        [Test]
        public void Add_OneNegativeNumber_ArgumentExceptionThrown()
        {
            const int num1 = 1;
            const int num2 = -2;
            var numString = num1 + "," + num2;
            Assert.Throws<ArgumentException>(() => _calc.Add(numString)); 
        }

        [Test]
        public void Add_OneNegativeNumber_ExceptionContainsNumber()
        {
            const int num1 = 1;
            const int num2 = -2;
            var numString = num1 + "," + num2;

            try
            {
                _calc.Add(numString);
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message.Contains(num2.ToString()));
            }
        }
        
        [Test]
        public void Add_MultipleNegativeNumbers_ExceptionContainsAllNegativeNumbers()
        {
            const int num1 = -1;
            const int num2 = -2;
            const int num3 = -3;
            var numString = num1 + "," + num2 + "," + num3;

            try
            {
                _calc.Add(numString); 
            }
            catch (ArgumentException e)
            {
                Assert.That(e.Message.Contains(num1.ToString()));
                Assert.That(e.Message.Contains(num2.ToString()));
                Assert.That(e.Message.Contains(num3.ToString()));
            }
        }

        [Test]
        public void Add_IncludingNumber1000_Sum()
        {
            const int num1 = 17;
            const int num2 = 1000;
            var numString = num1 + "," + num2; 
            Assert.AreEqual(num1 + num2, _calc.Add(numString));
        }
        
        [Test]
        public void Add_IncludingNumberGreaterThan1000_SumWithoutTooBigNumber()
        {
            const int num1 = 17;
            const int num2 = 1000;
            const int num3 = 1001;
            var numString = num1 + "," + num2 + "," + num3; 
            Assert.AreEqual(num1 + num2, _calc.Add(numString));
        }            
    }
}
