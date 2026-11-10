using Kobyzeva_hw7_Tumakov.Enum;

namespace Kobyzeva_hw7_Tumakov.Class
{
    /// <summary>
    /// Банковский счет с методами пополнения и снятия средств
    /// </summary>
    public class BankAccount
    {
        private decimal balance;
        private AccountType accountType;
        private static ulong accountNumberInf = 0;
        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public AccountType AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        /// <summary>
        /// Инициализирует экземпляр класса с автоматической генерацией номера
        /// </summary>
        /// <param name="balanceUser">Начальный баланс.</param>
        /// <param name="typeAccountUser">Тип счета.</param>
        public BankAccount(decimal balanceUser, AccountType typeAccountUser)
        {
            accountNumberInf++;
            accountNumber = accountNumberInf.ToString("D20");
            Balance = balanceUser;
            AccountType = typeAccountUser;
        }

        /// <summary>
        /// Выводит информацию о счете в консоль
        /// </summary>
        public void PrintOnConsole()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}\nБаланс: {Balance}\nТип счета: {AccountType}");
        }

        /// <summary>
        /// Пополнение баланса
        /// </summary>
        /// <param name="sum">Сумма для пополнения.</param>
        public bool Deposit(decimal sum)
        {
            try
            {
                Balance += sum;
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Снятие средств
        /// </summary>
        /// <param name="sum">Сумма для снятия</param>
        public bool Withdrawal(decimal sum)
        {
            try
            {
                if ((Balance - sum) < 0)
                {
                    return false;
                }
                else
                {
                    Balance -= sum;
                    return true;
                }
            }
            catch { return false; }
        }

        /// <summary>
        /// Перевод денег
        /// </summary>
        /// <param name="AccountFrom">Аккаунт банковских, откуда деньги приходят</param>
        /// <param name="sum">Сумма перевода</param>
        public bool Transfer(BankAccount AccountFrom, decimal sum)
        {
            try
            {
                if ((AccountFrom.Balance - sum) < 0 && sum > 0)
                {
                    Console.WriteLine("Недостаточно средств");
                    return false;
                }
                else
                {
                    Balance += sum;
                    AccountFrom.Balance -= sum;
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
