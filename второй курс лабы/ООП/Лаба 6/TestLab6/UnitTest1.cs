using Laba6;
using VitalikTeamLibrary;

namespace TestLab6
{
    [TestClass]
    public class Test2 
    {

        [TestMethod]
        public void Test()
        {
            string input = "asd bsd csd";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            Laba6_2.Program.Main();

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Одномерный массив: csd bsd asd", lines[2]);
            Assert.AreEqual("Отсортированный по убыванию Одномерный массив: csd bsd asd", lines[3]);
        }
    }

    [TestClass]
    public class Test1
    {

        [TestMethod]
        public void TestMenu11()
        {
            int choice = 1;
            string input = "2\n1\n0\n1\n2\n2\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstTask task = new FirstTask();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[3]);

            task.CompleteTask(true, ref choice);
            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu12()
        {
            int choice = 1;
            string input = "1\n2\n2\nc\nc\nc\nc\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            FirstTask task = new FirstTask();

            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu13()
        {
            int choice = 1;
            string input = "3\n3\n3\n3\n4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstTask task = new FirstTask();
            task.CompleteTask(false, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[3]);

            task.array = new char[2, 2];
            task.array[0, 0] = 'a';
            task.array[0, 1] = 'b';
            task.array[1, 0] = 'c';
            task.array[1, 1] = '0';

            task.CompleteTask(false, ref choice);

            task.array = new char[2, 2];
            task.array[0, 0] = 'a';
            task.array[0, 1] = 'b';
            task.array[1, 0] = 'c';
            task.array[1, 1] = 'b';

            task.CompleteTask(false, ref choice);

            task.array = new char[2, 2];
            task.array[0, 0] = '0';
            task.array[0, 1] = 'b';
            task.array[1, 0] = 'c';
            task.array[1, 1] = '0';

            task.CompleteTask(false, ref choice);

            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu14()
        {
            int choice = 1;
            string input = "6\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            FirstTask task = new FirstTask();
            task.CompleteTask(false, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Выбрана несуществующая команда.", lines[3]);
        }

        [TestMethod]
        public void TestMenu21()
        {
            int choice = 1;
            string input = "2\n1\n0\n1\n2\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondTask task = new SecondTask();

            task.CompleteTask(true, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[3]);

            task.CompleteTask(true, ref choice);
        }

        [TestMethod]
        public void TestMenu22()
        {
            int choice = 1;
            string input = "1\njsfjhsad jsdfnkjnksfd kjafsn\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            SecondTask task = new SecondTask();

            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu23()
        {
            int choice = 1;
            string input = "3\n3\n4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondTask task = new SecondTask();
            task.CompleteTask(false, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[3]);

            Console.SetOut(writer);

            task.words = new string[] { "asd", "bsd", "csd" };
            task.CompleteTask(false, ref choice);

            sb = writer.GetStringBuilder();
            lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Перевёрнутый Одномерный массив: csd bsd asd", lines[7]);

            Console.SetOut(writer);

            task.words = new string[] { "asd", "bsd", "csd" };
            task.CompleteTask(false, ref choice);

            sb = writer.GetStringBuilder();
            lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Отсортированный по убыванию Одномерный массив: csd bsd asd", lines[11]);
        }

        [TestMethod]
        public void TestMenu24()
        {
            int choice = 1;
            string input = "6\n5\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondTask task = new SecondTask();
            task.CompleteTask(false, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Выбрана несуществующая команда.", lines[3]);

            task.CompleteTask(false, ref choice);
        }

        [TestMethod]
        public void TestMenu25()
        {
            int choice = 1;
            string input = "2\n4\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var writer = new StringWriter();
            Console.SetOut(writer);

            SecondTask task = new SecondTask();
            task.words = new string[] { "asd", "bsd", "csd" };
            task.CompleteTask(false, ref choice);

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Одномерный массив: asd bsd csd", lines[3]);

            Console.SetOut(writer);

            task.words = null;
            task.CompleteTask(false, ref choice);

            sb = writer.GetStringBuilder();
            lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[7]);
        }
    }
}
