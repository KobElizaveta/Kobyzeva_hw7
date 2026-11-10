using Kobyzeva_hw7_Tumakov.Class;
using Kobyzeva_hw7_Tumakov.Enum;

namespace Kobyzeva_hw7_Tumakov
{
    internal class Program
    {
        static BankAccount AddAccount()
        {
            bool flag = true;
            BankAccount NewAccount = null;
            while (flag)
            {
                Console.Write("Баланс счета: ");
                bool isParseBalance = decimal.TryParse(Console.ReadLine(), out decimal balance);
                Console.Write("Тип счета (DepositeAccount, CreditAccount, CurrentAccount): ");
                bool isParseTypeAcc = AccountType.TryParse(Console.ReadLine(), out AccountType accountType);
                if (!isParseBalance | !isParseTypeAcc)
                {
                    Console.WriteLine("Неверно введены данные, попробуйте заново");
                }
                else
                {
                    try
                    {
                        NewAccount = new BankAccount(balance, accountType);
                        Console.WriteLine("Данные добавлены.");
                        return NewAccount;
                    }
                    catch
                    {
                        Console.WriteLine("Возникла ошибка. Данные не добавлены.");
                    }
                }
            }
            return NewAccount;
        }
        static void Task81()
        {
            Console.WriteLine("Упражнение 8.1");
            Console.WriteLine("Добавьте аккаунт банка отправителя");
            BankAccount accountFrom = AddAccount();
            Console.WriteLine("Добавьте аккаунт банка получателя");
            BankAccount accountTo = AddAccount();
            Console.Write("Введите сумму перевода: ");
            bool isParseSumTransfer = decimal.TryParse(Console.ReadLine(), out decimal sumToTransfer);
            if(!isParseSumTransfer && sumToTransfer <= 0) 
            { 
                Console.WriteLine("Неверный формат суммы"); 
            }
            else
            {
                Console.WriteLine("Выполнение перевода...");
                bool isTransfer = accountTo.Transfer(accountFrom, sumToTransfer);
                if (!isTransfer)
                {
                    Console.WriteLine("Перевод не выполнен");
                }
                else
                {
                    Console.WriteLine($"Перевод выполнен. Текущий счет банка отправителя - {accountFrom.Balance}; банка получателя - {accountTo.Balance}");
                }
            }
        }

        static string ReverseLetter(string stringBefore)
        {
            string stringAfter = "";
            foreach(char letter in stringBefore)
            {
                stringAfter = letter + stringAfter;
            }
            return stringAfter;
        }

        static void Task82()
        {
            Console.WriteLine("Упражнение 8.2");
            Console.Write("Введите строку: ");
            string stringEnter = Console.ReadLine();
            Console.WriteLine($"Результат: {ReverseLetter(stringEnter)}");
        }

        static void Task83()
        {
            Console.WriteLine("Упражнение 8.3");

            string pathFiles = "..\\..\\..\\Files";
            List<string> fileNames = Directory.GetFiles(pathFiles).Select(Path.GetFileNameWithoutExtension).ToList();
            Console.Write("Имеющиеся файлы: ");
            foreach(var nameFile in fileNames)
            {
                Console.Write(nameFile + ",  ");
            }

            Console.Write("\nВведите название файла: ");
            string nameFileEnter = Console.ReadLine();
            if(!fileNames.Contains(nameFileEnter))
            {
                Console.WriteLine("Данного файла не существует :(");
            }
            else
            {
                string pathOutputFile = "..\\..\\..\\Files\\FileOutput.txt";
                if(File.Exists(pathOutputFile))
                {
                    File.Delete(pathOutputFile);
                }
                string pathFile = $"..\\..\\..\\Files\\{nameFileEnter}.txt";
                string textFileInital = File.ReadAllText(pathFile);
                using (StreamWriter outputFile = File.CreateText(pathOutputFile))
                {
                    outputFile.WriteLine(textFileInital.ToUpper());
                }

                Console.WriteLine($"Содержание выходного файла: {File.ReadAllText(pathOutputFile)}");
            }
        }

        static string CheckFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formatObj = obj as IFormattable;
                if (formatObj != null)
                {
                    return $"Результат приведения: {formatObj.ToString()}";
                }
                else
                {
                    return $"Приведение не удалось";
                }
            }
            else
            {
                return "Объект не реализует интерфейс";
            }
        }
        static void Task84()
        {
            Console.WriteLine("Упражнение 8.4");
            Console.WriteLine("Проверка на реализацию IFormattable");

            int test1 = 123;
            Console.WriteLine($"Ввод: {test1}, тип - {test1.GetType().Name}: {CheckFormattable(test1)}");

            float test2 = (float)12.3;
            Console.WriteLine($"Ввод: {test2}, тип - {test2.GetType().Name}: {CheckFormattable(test2)}");

            string test3 = "text";
            Console.WriteLine($"Ввод: {test3}, тип - {test3.GetType().Name}: {CheckFormattable(test3)}");

            bool test4 = false;
            Console.WriteLine($"Ввод: {test4}, тип - {test4.GetType().Name}: {CheckFormattable(test4)}");

            List<int> test5 = new List<int> { 1, 2, 3 };
            Console.WriteLine($"Ввод: {test5}, тип - {test5.GetType().Name}: {CheckFormattable(test5)}");
        }

        static void FindMail(ref string s)
        {
            string[] parts = s.Split("#");
            foreach(string part in parts)
            {
                if(part.Contains("@"))
                {
                    s = part;
                    return;
                }
            }
            s = "";
        }

        static void Task81_hw()
        {
            Console.WriteLine("Домашняя работа 8.1");

            string pathFile = "..\\..\\..\\Files\\File81.txt";
            if(!File.Exists(pathFile))
            {
                Console.WriteLine("Файл не найден");
            }
            else
            {
                string pathFileMails = "..\\..\\..\\Files\\FileMails.txt";
                if (File.Exists(pathFileMails))
                {
                    File.Delete(pathFileMails);
                }
                using (StreamWriter fileMails =  new StreamWriter(pathFileMails))
                {
                    string[] textInFile = File.ReadAllLines(pathFile);
                    for (byte i = 0; i < textInFile.Length; i++)
                    {
                        FindMail(ref textInFile[i]);
                        if(textInFile[i] != "")
                        {
                            fileMails.WriteLine(textInFile[i]);
                        }
                    }
                }
                Console.WriteLine("Содержание выходного файла:");
                string[] textInFileMails = File.ReadAllLines(pathFileMails);
                foreach(string mail in textInFileMails)
                {
                    Console.WriteLine(mail);
                }
            }
        }
        static Song AddSong()
        {
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            Console.Write("Введите исполнителя: ");
            string author = Console.ReadLine();
            Song newSong = new Song(name, author);
            return newSong;
        }
        static void Task82_hw()
        {
            Console.WriteLine("Домашняя работа 8.2");
            Console.WriteLine("Необходимо ввести 4 песни");
            Console.WriteLine("Первая:");
            Song song1 = AddSong();
            Console.WriteLine("Вторая:");
            Song song2 = AddSong();
            song2.Prev = song1;
            Console.WriteLine("Третья:");
            Song song3 = AddSong();
            song3.Prev = song2;
            Console.WriteLine("Четвертая:");
            Song song4 = AddSong();
            song4.Prev = song3;

            Console.WriteLine("Сравнение первой и второй песни");
            bool isEquals = song1.Equals(song2);
            if(isEquals) { Console.WriteLine("Песни совпадают"); }
            else { Console.WriteLine("Песни НЕ совпадают"); }

        }
        static void Main(string[] args)
        {
            Task81();
            Task82();
            Task83();
            Task84();

            Task81_hw();
            Task82_hw();
        }
    }
}
