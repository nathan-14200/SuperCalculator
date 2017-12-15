using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SuperComputer
{
    class SquareRoot : Function<double>, IFunction
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
                return "Square Root a, (ErrMargin)\nCalcule la racine carré du flotant a avec une marge ErrMargin (optionel)";
            }
        }

        public string[] ParametersName
        {
            get
            {
                return new string[2] { "a", "ErrMargin" };                
            }
        }

        public double Evaluate(string[] args)
        {
            try
            {
                double a = Convert.ToDouble(args[0]);
                double b = 1.0;
                double c = a;

                double errMargin = 0.001;

                if (args[1] != null)
                {
                    errMargin = Convert.ToDouble(args[1]);
                }
                
                if (a < 0) { throw new EvaluationException("Le nombre a doit être positif"); }
                double diff;

                if (a - b > 0) { diff = a - b; }
                else { diff = b - a; }

                while ( diff > errMargin)
                {
                    b = (double) (b + c) / 2.0;
                    c = (double)  a / b;
                }

                return a;
                
            }
            catch (FormatException ex)
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
        public void TestName()
        {
            Assert.AreEqual(squareRoot.Name, "Square Root");
        }
    }
}
