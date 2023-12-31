using Laba5;

namespace TestLaba5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMenu11()
        {
            FirstExercise task = new FirstExercise();

            task.PrintMenu();
        }

        [TestMethod]
        public void TestMenu12()
        {
            int choice = 1;
            string input = "1\n0\n2\n1\n2\n1\n1";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstExercise task = new FirstExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверно введён размер массива.", lines[7]);
            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu13()
        {
            int choice = 1;
            string input = "2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstExercise task = new FirstExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[6]);
        }

        [TestMethod]
        public void TestMenu14()
        {
            int choice = 1;
            string input = "1\n1\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            FirstExercise task = new FirstExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu15()
        {
            int choice = 1;
            string input = "3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstExercise task = new FirstExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[6]);
        }

        [TestMethod]
        public void TestMenu16()
        {
            int choice = 1;
            string input = "1\n5\n3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            FirstExercise task = new FirstExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu17()
        {
            int choice = 1;
            string input = "1\n4\n3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            FirstExercise task = new FirstExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu18()
        {
            int choice = 1;
            string input = "4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            FirstExercise task = new FirstExercise();
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu19()
        {
            int choice = 1;
            string input = "7\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstExercise task = new FirstExercise();
            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Выбрана несуществующая команда.", lines[6]);
        }

        [TestMethod]
        public void TestMenu21()
        {
            SecondExercise task = new SecondExercise();

            task.PrintMenu();
        }

        [TestMethod]
        public void TestMenu22()
        {
            int choice = 1;
            string input = "1\n0\n2\n1\n2\n1\n1\n2\n1\n2\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверно введены размеры массива.", lines[8]);
            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu23()
        {
            int choice = 1;
            string input = "2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[6]);
        }

        [TestMethod]
        public void TestMenu24()
        {
            int choice = 1;
            string input = "1\n1\n2\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu25()
        {
            int choice = 1;
            string input = "3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[6]);
        }

        [TestMethod]
        public void TestMenu26()
        {
            int choice = 1;
            string input = "1\n5\n3\n3\n1\n1\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu27()
        {
            int choice = 1;
            string input = "1\n4\n3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu28()
        {
            int choice = 1;
            string input = "4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            SecondExercise task = new SecondExercise();
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu29()
        {
            int choice = 1;
            string input = "7\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondExercise task = new SecondExercise();
            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Выбрана несуществующая команда.", lines[6]);
        }

        [TestMethod]
        public void TestMenu210()
        {
            int choice = 1;
            string input = "1\n5\n3\n3\n0\n0\n1\n3\n2";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondExercise task = new SecondExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверное значение.", lines[24]);
        }

        [TestMethod]
        public void TestMenu31()
        {
            ThirdExercise task = new ThirdExercise();

            task.PrintMenu();
        }

        [TestMethod]
        public void TestMenu32()
        {
            int choice = 1;
            string input = "1\n0\n2\n1\n2\n2\n1\n1\n2\n1\n2\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверно введены размеры массива.", lines[7]);
            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu33()
        {
            int choice = 1;
            string input = "2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[6]);
        }

        [TestMethod]
        public void TestMenu34()
        {
            int choice = 1;
            string input = "1\n1\n2\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu35()
        {
            int choice = 1;
            string input = "3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[6]);
        }

        [TestMethod]
        public void TestMenu36()
        {
            int choice = 1;
            string input = "1\n3\n3\n3\n2\n3\n1\n1\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu37()
        {
            int choice = 1;
            string input = "1\n4\n3\n2\n4\n4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu38()
        {
            int choice = 1;
            string input = "4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            ThirdExercise task = new ThirdExercise();
            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu39()
        {
            int choice = 1;
            string input = "7\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            ThirdExercise task = new ThirdExercise();
            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Выбрана несуществующая команда.", lines[6]);
        }

        [TestMethod]
        public void TestMenu310()
        {
            int choice = 1;
            string input = "1\n3\n4\n2\n3\n3\n0\n6\n2\n3\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            ThirdExercise task = new ThirdExercise();

            task.CompleteTask(true, ref choice);
            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Неверное значение.", lines[23]);
        }

    }

}
