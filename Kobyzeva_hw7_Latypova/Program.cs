using Kobyzeva_hw7_Latypova.Class;

using Kobyzeva_hw7_Latypova.Enum;

namespace Kobyzeva_hw7_Latypova
{
    internal class Program
    {

        static void Distribution(TaskItem task, List<Employee> employees, CompanyManager manager)
        {
            foreach (Employee employeeFrom in employees)
            {
                foreach (Employee employeeTo in employees)
                {
                    bool isTake = manager.AssignTask(employeeFrom, employeeTo, task);
                    if (isTake) { return;  }
                    else { continue;  }
                }
            }
        }
        static void Task()
        {
            Console.WriteLine("Задание - составление модели распределения задач между сотрудниками");
            CompanyManager manager = new CompanyManager();

            Console.WriteLine("Информация о всех сотрудниках");
            manager.PrintAboutEmployees();

            bool isContinue = true;
            while(isContinue) 
            {
                Console.WriteLine("Добавление новой задачи");
                Console.Write("Отдел (SystemAdmins, Developers, Management):  ");
                bool isParse = TaskType.TryParse(Console.ReadLine(), out TaskType taskType);
                Console.Write("Название задачи:  ");
                string nameTask = Console.ReadLine();
                if (!isParse)
                {
                    Console.WriteLine("Неверно указан отдел. Попробуйте заново");
                    continue;
                }
                TaskItem task = new TaskItem(nameTask, taskType);
                List<Employee> employees = manager.ReturnEmployees();
                Distribution(task, employees, manager);

                Console.Write("Хотите продолжить? (д/н)  ");
                if(Console.ReadLine() == "н")
                {
                    isContinue = false;
                }
            }        
        }
        static void Main(string[] args)
        {
            Task();
        }
    }
}
