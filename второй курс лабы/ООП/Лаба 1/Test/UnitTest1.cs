using VitalikTeamLibrary;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReadValueTest()
        {
            var textReader = new StringReader("f");
            Console.SetIn(textReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeamLibrary.VitalikTeam.ReadValue();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Неверное значение.", lines[1]);

        }

        [TestMethod]
        public void ReadValueTest1()
        {

            var textReader = new StringReader("25");
            Console.SetIn(textReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            int value = VitalikTeamLibrary.VitalikTeam.ReadValue();

            Assert.AreEqual(25, value);
        }

        [TestMethod]
        public void ReadDoubleTest()
        {
            var textReader = new StringReader("1,0\n1");
            Console.SetIn(textReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeamLibrary.VitalikTeam.ReadDouble();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Неверное значение.", lines[1]);
        }

        [TestMethod]
        public void ReadDoubleTest1()
        {
            var textReader = new StringReader("1.0");
            Console.SetIn(textReader);

            double value = VitalikTeamLibrary.VitalikTeam.ReadDouble();

            Assert.AreEqual(1.0, value);
        }

        [TestMethod]
        public void ReadCharTest()
        {
            var textReader = new StringReader("srg\ns");
            Console.SetIn(textReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            char value = VitalikTeamLibrary.VitalikTeam.ReadChar();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Неверное значение.", lines[1]);
        }

        [TestMethod]
        public void ReadCharTest1()
        {
            var textReader = new StringReader("s");
            Console.SetIn(textReader);

            char value = VitalikTeamLibrary.VitalikTeam.ReadChar();

            Assert.AreEqual('s', value);
        }

        [TestMethod]
        public void ReadStringTest1()
        {
            var textReader = new StringReader("sdlfbjkasbf");
            Console.SetIn(textReader);

            var value = VitalikTeamLibrary.VitalikTeam.ReadString();

            Assert.AreEqual("sdlfbjkasbf", value);
        }

        [TestMethod]
        public void ReadStringTest()
        {
            var textReader = new StringReader("\n  \nfsdasf\n");
            Console.SetIn(textReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            string value = VitalikTeamLibrary.VitalikTeam.ReadString();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Неверное значение.", lines[1]);
            Assert.AreEqual("Неверное значение.", lines[3]);
        }

        [TestMethod]
        public void PrintArrayTest()
        {
            var array = new int[5];

            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;

            string answer = "Одномерный массив: 1 2 3 4 5";

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeam.PrintArray(array);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual(answer, lines[0]);
        }

        [TestMethod]
        public void PrintArrayTest1()
        {
            var array = new string[5];

            array[0] = "sdjfb";
            array[1] = "sdjfb";
            array[2] = "sdjfb";
            array[3] = "sdjfb";
            array[4] = "sdjfb";

            string answer = "Одномерный массив: sdjfb sdjfb sdjfb sdjfb sdjfb";

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeam.PrintArray(array);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual(answer, lines[0]);
        }

        [TestMethod]
        public void PrintArrayTest2()
        {
            var array = new int[2, 2];

            array[0, 0] = 1;
            array[0, 1] = 2;
            array[1, 0] = 3;
            array[1, 1] = 4;

            string[] answer = new string[3];
            answer[0] = "Двумерный массив:";
            answer[1] = "1 2";
            answer[2] = "3 4";

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeam.PrintArray(array);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual(answer[0], lines[0]);
            Assert.AreEqual(answer[1], lines[1]);
            Assert.AreEqual(answer[2], lines[2]);
        }

        [TestMethod]
        public void PrintArrayTest3()
        {
            var array = new int[2][];
            array[0] = new int[2];
            array[1] = new int[2];

            array[0][0] = 1;
            array[0][1] = 2;
            array[1][0] = 3;
            array[1][1] = 4;

            string[] answer = new string[3];
            answer[0] = "Рваный массив:";
            answer[1] = "1 2";
            answer[2] = "3 4";

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeam.PrintArray(array);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual(answer[0], lines[0]);
            Assert.AreEqual(answer[1], lines[1]);
            Assert.AreEqual(answer[2], lines[2]);
        }

        [TestMethod]
        public void PrintArrayTest4()
        {
            var array = new char[2, 2];

            array[0, 0] = 'a';
            array[0, 1] = 'b';
            array[1, 0] = 'c';
            array[1, 1] = 'd';

            string[] answer = new string[3];
            answer[0] = "Двумерный массив:";
            answer[1] = "a b";
            answer[2] = "c d";

            var writer = new StringWriter();
            Console.SetOut(writer);

            VitalikTeam.PrintArray(array);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual(answer[0], lines[0]);
            Assert.AreEqual(answer[1], lines[1]);
            Assert.AreEqual(answer[2], lines[2]);
        }

        [TestMethod]
        public void TestWriteOneDimArray()
        {
            int[] array;

            string input = "7\n9\n5\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            array = VitalikTeam.WriteOneDimArray(5);

            Assert.AreEqual(5, array.Length);
        }

        [TestMethod]
        public void TestWriteTwoDimArray()
        {
            int[,] array;

            string input = "7\n9\n5\n6\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            array = VitalikTeam.WriteTwoDimArray(2, 2);

            bool answer = (array.GetLength(0) == 2) && (array.GetLength(1) == 2);

            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void TestWriteJagArray()
        {
            int[][] array;

            string input = "0\n1\n9\n2\n6\n3\n1\n1\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            array = VitalikTeam.WriteJagArray(2, false);
            array = VitalikTeam.WriteJagArray(2);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверно введены размеры массива.", lines[1]);
        }

        [TestMethod]
        public void TestFactorial()
        {
            double factorial = 1;

            VitalikTeam.Factorial(3, ref factorial);
            Assert.AreEqual(6, factorial);

            factorial = 1;

            VitalikTeam.Factorial(0, ref factorial);
            Assert.AreEqual(1, factorial);
        }

        [TestMethod]
        public void TestPow()
        {
            double pow = 1;

            VitalikTeam.Pow(3, 5, ref pow);
            Assert.AreEqual(25, pow);

            pow = 1;

            VitalikTeam.Pow(0, 2, ref pow);
            Assert.AreEqual(1, pow);
        }

        [TestMethod]
        public void TestSign()
        {
            Assert.AreEqual(1, VitalikTeam.Sign(2));

            Assert.AreEqual(-1, VitalikTeam.Sign(3));
        }

        [TestMethod]
        public void TestWriteRandomArray()
        {
            int[] array = new int[2];
            VitalikTeam.WriteRandomArray(array);

            int[,] array1 = new int[2, 2];
            VitalikTeam.WriteRandomArray(array1);

            char[,] array2 = new char[2, 2];
            VitalikTeam.WriteRandomArray(array2);
        }
    }
}