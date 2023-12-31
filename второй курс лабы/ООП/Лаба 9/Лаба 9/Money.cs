using VitalikTeamLibrary;

namespace VitalikTeamMoney
{
    public class Money
    {
        private int rubles;
        private int kopeks;

        public static int objectsCount = 0;

        ///////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        ///////////////////////////////////////////////////////////////////
        public Money()
        {
            Rubles = 0;
            Kopeks = 0;

            objectsCount++;
        }

        public Money(int rubles, int kopeks) : this()
        {
            Rubles = rubles;
            Kopeks = kopeks;
        }

        public Money(Money newMoney)
        {
            this.Rubles = newMoney.rubles;
            this.Kopeks = newMoney.kopeks;
        }

        public int Rubles
        {
            get { return rubles; }
            set { rubles = value; }
        }

        public int Kopeks
        {
            get { return kopeks; }
            set
            {
                if (value < 0)
                {
                    if (rubles * 100 < Math.Abs(value))
                    {
                        Console.WriteLine("Недостаточно средств для списания.");
                        return;
                    }

                    int temp = rubles;
                    rubles = 0;
                    Kopeks = temp * 100 - Math.Abs(value);
                    return;
                }

                rubles += value / 100;
                kopeks = value % 100;
            }
        }


        ///////////////////////////////////////////////////////////////////
        // METHODS
        ///////////////////////////////////////////////////////////////////
        public void PrintBalance(string description = "")
        {
            Console.WriteLine($"{description} Баланс: {this.rubles},{this.kopeks}");
        }

        public void PrintBalance()
        {
            Console.WriteLine($"Баланс: {this.rubles},{this.kopeks}\n");
        }

        public override bool Equals(object? obj)
        {
            bool isEqual = false;

            if (obj is Money other)
                isEqual = (rubles == other.rubles && kopeks == other.kopeks);

            return isEqual;
        }


        ///////////////////////////////////////////////////////////////////
        // OPERATORS
        ///////////////////////////////////////////////////////////////////
        public static Money operator +(Money firstMoney, int kopeks)
        {
            Money temp = new Money(firstMoney);
            temp.Kopeks += kopeks;

            return temp;
        }

        public static Money operator +(int kopeks, Money firstMoney)
        {
            return firstMoney + kopeks;
        }

        public static Money operator -(Money money, int kopeks)
        {
            Money temp = new Money(money);
            temp.Kopeks -= kopeks;

            return temp;
        }

        public static Money operator -(int kopeks, Money money)
        {
            kopeks -= money.Kopeks + money.Rubles * 100;

            return new Money (0, kopeks);
        }

        public static implicit operator int(Money money)
        {
            return money.rubles;
        }

        public static explicit operator double(Money money)
        {
            return (double)money.kopeks / 100;
        }

        public static Money operator --(Money money)
        {
            return new Money(money.Rubles, money.Kopeks - 1);
        }

        public static Money operator ++(Money money)
        {
            return new Money(money.Rubles, money.Kopeks + 1);
        }

        public static int GetObjectCount()
        {
            return objectsCount;
        }
    }
}
