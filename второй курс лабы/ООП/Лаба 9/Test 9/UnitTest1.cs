using VitalikTeamMoney;

namespace Test_9
{
    [TestClass]
    public class MoneyTest
    {
        public static int objectsCount = 0;

        [TestMethod]
        public void TestMoneyConstructor()
        {
            Money money = new Money();

            Money res = new Money();
            res.Rubles = 0;
            res.Kopeks = 0;

            objectsCount += 2;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyConstructor1()
        {
            Money money = new Money(12, 45);

            Money res = new Money();
            res.Rubles = 12;
            res.Kopeks = 45;

            objectsCount += 2;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyImplicit()
        {
            Money money = new Money(12, 45);

            int rubles = money;

            objectsCount += 1;
            Assert.AreEqual(12, rubles);
        }

        [TestMethod]
        public void TestMoneyExplicit()
        {
            Money money = new Money(12, 45);

            double kopeks = (double)money;

            objectsCount += 1;
            Assert.AreEqual((double)0.45, kopeks);
        }

        [TestMethod]
        public void TestMoneyOperator5()
        {
            Money money = new Money(0, 0);

            Money res = new Money(0, 1);

            money++;

            objectsCount += 2;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyOperator4()
        {
            Money money = new Money(0, 1);

            Money res = new Money(0, 0);

            money--;

            objectsCount += 2;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyOperator3()
        {
            Money money = new Money(0, 0);

            Money res = new Money(0, 75);
            money = 120 - new Money(0, 45);

            objectsCount += 3;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyOperator2()
        {
            Money money = new Money(13, 20);

            Money res = new Money(12, 75);
            money = money - 45;

            objectsCount += 2;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyOperator1()
        {
            Money money = new Money(13, 20);

            Money res = new Money(12, 75);
            res += 45;

            objectsCount += 2;
            Assert.AreEqual(money, res);
        }

        [TestMethod]
        public void TestMoneyOperator()
        {
            Money money = new Money(13, 20);

            Money res = new Money(12, 75);
            res = 45 + res;

            objectsCount += 2;
            Assert.AreEqual(money, res);
        }

        [TestMethod]
        public void TestMoneyConstructor3()
        {
            Money money = new Money(13, 20);

            objectsCount += 1;
            Assert.AreEqual(13, money.Rubles);
        }

        [TestMethod]
        public void TestMoneyConstructor4()
        {
            Money money = new Money(0, 20);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            money.Kopeks -= 30;

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            objectsCount += 1;
            Assert.AreEqual("Недостаточно средств для списания.", lines[0]);
        }

        [TestMethod]
        public void TestMoneyConstructor2()
        {
            Money money = new Money(1, 20);

            money.Kopeks -= 30;

            Money res = new Money(0, 90);

            objectsCount += 2;
            Assert.AreEqual(res, money);
        }

        [TestMethod]
        public void TestMoneyPrintBalance()
        {
            Money money = new Money(12, 45);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            money.PrintBalance("bruh");

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            objectsCount += 1;
            Assert.AreEqual("bruh Баланс: 12,45", lines[0]);
        }

        [TestMethod]
        public void TestMoneyPrintBalance1()
        {
            Money money = new Money(12, 45);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            money.PrintBalance();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            objectsCount += 1;
            Assert.AreEqual("Баланс: 12,45", lines[0]);
        }

        [TestMethod]
        public void TestMoneyGetCount()
        {
            Assert.AreEqual(objectsCount, Money.GetObjectCount());
        }

        [TestMethod]
        public void TestMoneyEquals()
        {
            Money money = new Money(12, 45);
            Money money2 = new Money(12, 45);

            bool equal = money.Equals(money2);

            objectsCount += 2;
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void TestMoneyEquals1()
        {
            Money money = new Money(12, 45);
            Money money2 = new Money(13, 45);

            bool equal = money.Equals(money2);

            objectsCount += 2;
            Assert.AreEqual(false, equal);
        }
    }

    [TestClass]
    public class MoneyArrayTest
    {
        [TestMethod]
        public void TestMoneyArrayConstructor()
        {
            MoneyArray val = new MoneyArray();

            Assert.AreEqual(val.Count, 0);
        }

        [TestMethod]
        public void TestMoneyArrayConstructor1()
        {
            MoneyArray val = new MoneyArray(5);

            Assert.AreEqual(5, val.Count);
        }

        [TestMethod]
        public void TestMoneyArrayIndex()
        {
            MoneyArray val = new MoneyArray(5);

            val[3] = new Money(1, 2);

            MoneyTest.objectsCount += 2;
            Assert.AreEqual(new Money(1, 2), val[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMoneyArrayIndex1()
        {
            MoneyArray val = new MoneyArray(1);

            val[5] += 5;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMoneyArrayIndex2()
        {
            MoneyArray val = new MoneyArray(1);

            val[-1] += 1;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMoneyArrayIndex3()
        {
            MoneyArray val = new MoneyArray(1);

            val[0] = val[5];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestMoneyArrayIndex4()
        {
            MoneyArray val = new MoneyArray(1);

            val[0] = val[-1];
        }

        [TestMethod]
        public void TestMoneyArrayPrint()
        {
            MoneyArray val = new MoneyArray(2);

            val[0] = new Money(1, 2);
            val[1] = new Money(1, 3);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            val.PrintArray();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            MoneyTest.objectsCount += 2;
            Assert.AreEqual("1 Баланс: 1,2", lines[0]);
            Assert.AreEqual("2 Баланс: 1,3", lines[1]);
        }

        [TestMethod]
        public void TestMoneyArrayPrint1()
        {
            MoneyArray val = new MoneyArray();

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            val.PrintArray();
            val.GetMinimalNumber();

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[0]);
            Assert.AreEqual("Массив пуст. Сначала заполните его.", lines[1]);
        }

        [TestMethod]
        public void TestMoneyArrayGetMinNumber()
        {
            MoneyArray val = new MoneyArray(2);

            val[0] = new Money(1, 2);
            val[1] = new Money(1, 3);

            MoneyTest.objectsCount += 3;
            Assert.AreEqual(1, val.GetMinimalNumber());
        }

        [TestMethod]
        public void TestMoneyArrayGetObjects()
        {
            Assert.AreEqual(MoneyTest.objectsCount, MoneyArray.GetObjectCount());
        }

        [TestMethod]
        public void TestMoneyArrayWriteArray()
        {
            MoneyArray val = new MoneyArray(2);

            string input = "7\n9\n5\n6\n";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            val.WriteArray(false);

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            MoneyTest.objectsCount += 2;
            Assert.AreEqual("Массив заполнен.", lines[4]);
        }

        [TestMethod]
        public void TestMoneyArrayWriteArray1()
        {
            MoneyArray val = new MoneyArray(2);

            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            val.WriteArray(true);

            var output = _stringWriter.GetStringBuilder();
            var lines = output.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);

            MoneyTest.objectsCount += 2;
            Assert.AreEqual("Массив заполнен.", lines[0]);
        }
    }
}
