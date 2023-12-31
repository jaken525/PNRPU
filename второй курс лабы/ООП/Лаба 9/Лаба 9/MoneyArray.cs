using VitalikTeamLibrary;

namespace VitalikTeamMoney
{
    public class MoneyArray
    {
        Money[] money;

        public MoneyArray()
        {
            money = new Money[0];
        }

        public MoneyArray(int count)
        {
            money = new Money[count];
        }

        public Money this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                return money[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                money[index] = value;
            }
        }

        public int Count
        {
            get => money.Length;
        }

        public void PrintArray()
        {
            if (Count > 0)
                for (int i = 0; i < Count; i++)
                    money[i].PrintBalance($"{i + 1}");
            else
                Console.WriteLine("Массив пуст. Сначала заполните его.\n");
        }

        public void WriteArray(bool isRandom)
        {
            for (int i = 0; i < Count; i++)
                if (!isRandom)
                    money[i] = new Money(VitalikTeam.ReadValue("кол-во рублей"), VitalikTeam.ReadValue("кол-во копеек"));
                else
                    money[i] = new Money(VitalikTeam.Random(0, 300), VitalikTeam.Random(0, 99));

            Console.WriteLine("Массив заполнен.\n");
        }

        public int GetMinimalNumber()
        {
            if (Count > 0)
            {
                int minimalIndex = 0;

                Money maxMoney = new Money(int.MaxValue, int.MaxValue);

                for (int i = 0; i < Count; i++)
                    if (money[i].Rubles * 100 + money[i].Kopeks < maxMoney.Rubles * 100 + maxMoney.Kopeks)
                    {
                        maxMoney = new Money(money[i]);
                        minimalIndex = i;
                    }

                return minimalIndex + 1;
            }
            else
            {
                Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                return -1;
            }
        }

        public static int GetObjectCount()
        {
            return Money.objectsCount;
        }
    }
}
