using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SuperComputer
{
    class Factorial : Function<int>, IFunction
    {
        public string Name
        {
            get
            {
                return "Factorial";
            }
        }

        public string HelpMessage
        {
            get
            {
                return "Factorial a\nCalcule la factorielle de l'entier a";
            }
        }

        public string[] ParametersName
        {
            get
            {
                return new string[1] { "a" };
            }
        }

        public int Evaluate(string[] args)
        {
            try
            {
                int a = Convert.ToInt32(args[0]);
                int fact = 1;

                for (int i = a; i<=2; i--)
                {
                    fact *= i;
                }

                return fact;
            }
            catch (FormatException ex)
            {
                throw new EvaluationException("Le paramètre doivent être un entier.");
            }
            catch (OverflowException ex)
            {
                throw new EvaluationException("Le résultat est trop grand");
            }
        }
    }

    [TestFixture()]
    class TestFactorial
    {
        Factorial factorial = new Factorial() ;

        [Test()]
        public void TestName()
        {
            Assert.AreEqual(factorial.Name, "Factorial");
        }
    }
}
