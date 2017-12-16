using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SuperComputer
{
    public class Add : Function<double>, IFunction
    {

        public string Name
        {
            get
            {
                return "Add";
            }
        }

        public string HelpMessage
        {
            get
            {
                return "Does the sum of 2 numbers";
            }
        }

        public string[] ParametersName
        {
            get
            {
                string[] param = new string[2] { "float a", "flaot b" };

                return param;
            }
        }

        public double Evaluate(params string[] args)
        {
            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);

                double result = a + b;
                
                return result;
            }
            catch
            {
                throw new EvaluationException("Could not compute Add function");
            }
        }
    }

    [TestFixture()]
    class TestAdd
    {
        Add add = new Add();

        [Test()]
        public void TestNameAdd()
        {
            Assert.AreEqual(add.Name, "Add");
        }
        [Test()]
        public void TestEvaluateAdd()
        {

            Assert.That(add.Evaluate(new string[] { "0", "5" }), Is.EqualTo(5));
            Assert.That(add.Evaluate(new string[] { "1", "-1" }), Is.EqualTo(0));
            Assert.That(add.Evaluate(new string[] { "2", "2,5" }), Is.EqualTo(4.5));
            Assert.That(add.Evaluate(new string[] { "3,5", "-1,5" }), Is.EqualTo(2));
        }


        [Test()]
        public void EvaluateFailureAdd()
        {
            Assert.That(delegate { add.Evaluate(new string[] { "3.5" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { add.Evaluate(new string[] { "huit" }); }, Throws.TypeOf<EvaluationException>());

        }

    }
}
