using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperComputer;

namespace SuperComputer
{
    public class Factorial : Function<uint>, IFunction
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

        public uint Evaluate(string[] args)
        {
            try
            {
                uint a = Convert.ToUInt32(args[0]);
                uint fact = 1;

                if (a < 0){ throw new FormatException(); }

                if (a == 0) { return 1; }

                else if (a == 1)
                {
                    return 1;
                }
                else
                {
                    for (uint i = 2; i <= a; i++)
                    {
                        fact *= i;
                    }

                return fact;                                     
                }
            }
            catch (FormatException)
            {
                throw new EvaluationException("Le paramètre doit être un nombre entier.");
            }
            catch (OverflowException)
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
        public void TestNameFactorial()
        {
            Assert.AreEqual(factorial.Name, "Factorial");
        }
        [Test()]
        public void TestEvaluateFactorial()
        {
            
            Assert.That(factorial.Evaluate(new string[] { "0" }), Is.EqualTo(1));
            Assert.That(factorial.Evaluate(new string[] { "1" }), Is.EqualTo(1));
            Assert.That(factorial.Evaluate(new string[] { "2" }), Is.EqualTo(2));
            Assert.That(factorial.Evaluate(new string[] { "3" }), Is.EqualTo(6));
        }

        
        [Test()]
        public void EvaluateFailureFactorial()
        {
            Assert.That(delegate { factorial.Evaluate(new string[] { "3.5" }); },Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { factorial.Evaluate(new string[] { "huit" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { factorial.Evaluate(new string[] { "-2" }); }, Throws.TypeOf<EvaluationException>());
        }

    }
}
