using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperComputer;

namespace SuperComputer
{
    public class SquareRoot : Function<double>, IFunction
    {
        public string Name
        {
            get
            {
                return "Square Root";
            }
        }

        public string HelpMessage
        {
            get
            {
                return "Square Root a\nCalcule la racine carré du flottant a";
            }
        }

        public string[] ParametersName
        {
            get
            {
                return new string[1] { "a" };                
            }
        }

        public double Evaluate(string[] args)
        {
            try
            {
                double a = Convert.ToDouble(args[0]);
                /*
                double b = 1.0;
                double c = a;
                */

                if (a < 0) { throw new EvaluationException("Le nombre a doit être positif"); }

                return Math.Sqrt(a);

                /*
                double diff;

                if (a - b > 0) { diff = a - b; }
                else { diff = b - a; }

                for (int i = 1; i<10000;i++)
                {
                    b = (double) (b + c) / 2.0;
                    c = (double)  a / b;
                }

                return a;
                */
               
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les paramètres doivent être des nombres.");
            }
        }
    }

    [TestFixture()]
    class TestSquareRoot
    {
        SquareRoot squareRoot = new SquareRoot();

        [Test()]
        public void TestNameSquareRoot()
        {
            Assert.That(squareRoot.Name, Is.EqualTo("Square Root"));
        }

        [Test()]
        public void TestEvaluateSquareRoot()
        {
            Assert.AreEqual(squareRoot.Evaluate(new string[] { "4" }),Is.EqualTo((double)2));
        }

        [Test()]
        public void EvaluateFailureSquareRoot()
        {
            Assert.That(delegate { squareRoot.Evaluate(new string[] { "-35" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { squareRoot.Evaluate(new string[] { "huit" }); }, Throws.TypeOf<EvaluationException>());

        }
    }
}
