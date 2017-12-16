using SuperComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SuperComputer
{
    public class Minus : SuperComputer.Function<double>
    {
        public string HelpMessage
        {
            get
            {
                return "Does the difference between a and b (a-b)";
            }
        }

        public string Name
        {
            get
            {
                return "Minus";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[2] { "double a", "double b" };

                return param;
            }
        }


        public double Evaluate(params string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                double result = a - b;
                return result;
            }
            catch 
            {
                throw new EvaluationException("Could not compute Minus function");
            }
        }
    }

    [TestFixture()]
    class TestMinus
    {
        Minus minus = new Minus();

        [Test()]
        public void TestNameMinus()
        {
            Assert.AreEqual(minus.Name, "Minus");
        }
        [Test()]
        public void TestEvaluateMinus()
        {

            Assert.That(minus.Evaluate(new string[] { "0", "5" }), Is.EqualTo(-5));
            Assert.That(minus.Evaluate(new string[] { "1", "-1" }), Is.EqualTo(2));
            Assert.That(minus.Evaluate(new string[] { "2", "2,5" }), Is.EqualTo(-0.5));
            Assert.That(minus.Evaluate(new string[] { "3,5", "-1,5" }), Is.EqualTo(5));
        }


        [Test()]
        public void EvaluateFailureMinus()
        {
            Assert.That(delegate { minus.Evaluate(new string[] { "3,5" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { minus.Evaluate(new string[] { "huit" }); }, Throws.TypeOf<EvaluationException>());
        }

    }
}
