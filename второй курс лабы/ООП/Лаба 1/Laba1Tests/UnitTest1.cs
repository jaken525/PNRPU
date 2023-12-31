using Laba1;
using Laba1_2;

namespace Laba1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestXInputTrue()
        {
            string input = "7\n9\n5\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            Laba1.Program.Main();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Введите x:", lines[8]);
        }

        [TestMethod]
        public void TestXInputFalse()
        {
            string input = "7\n9\n0\n5\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            Laba1.Program.Main();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверно задан x.", lines[9]);
        }

        [TestMethod]
        public void TestCalculatedValues()
        {
            string input = "7\n9\n5\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            Laba1.Program.Main();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("--m - n++: 1", lines[2]);
            Assert.AreEqual("m, n: 8, 8", lines[3]);
            Assert.AreEqual("m * m < n++: False", lines[4]);
            Assert.AreEqual("m, n: 8, 9", lines[5]);
            Assert.AreEqual("n-- > ++m: False", lines[6]);
            Assert.AreEqual("m, n: 9, 8", lines[7]);
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestPointConstructor()
        {
            Laba1_2.Point point = new Laba1_2.Point();

            Laba1_2.Point result = new Laba1_2.Point();
            result.valueX = 0;
            result.valueY = 0;

            bool answer = result.valueX == point.valueX && result.valueY == point.valueY;

            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void TestPointConstructor1()
        {
            Laba1_2.Point point = new Laba1_2.Point(15, 20);

            Laba1_2.Point result = new Laba1_2.Point();
            result.valueX = 15;
            result.valueY = 20;

            bool answer = result.valueX == point.valueX && result.valueY == point.valueY;

            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void TestInputs()
        {
            string input = "1.2\n3.2";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            Laba1_2.Program.Main();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("True", lines[2]);
        }
    }
}