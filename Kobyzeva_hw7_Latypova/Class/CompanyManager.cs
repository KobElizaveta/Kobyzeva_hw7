using Kobyzeva_hw7_Latypova.Enum;
using System.Xml.Linq;

namespace Kobyzeva_hw7_Latypova.Class
{
    public class CompanyManager
    {
        private List<Employee> employees = new List<Employee>();

        public CompanyManager()
        {
            Employee timur = new TopManagment("Тимур");
            Employee rashid = new ITManagment("Рашид", timur);
            Employee ilham = new ITManagment("О Ильхам", timur);

            Employee orkadiy = new TeamLead("Оркадий", "Начальник инф.систем", ilham);
            Employee volodya = new TeamLead("Володя", "Зам. начальника", orkadiy);

            Employee ilyashat = new Worker("Ильяшат", "Главный у системщиков", volodya, TaskType.SystemAdmins);
            Employee ivahych = new Worker("Иваныч", "Зам.главного системщиков", ilyashat, TaskType.SystemAdmins);
            Employee ilya = new Worker("Илья", "Системщик", ilyashat, TaskType.SystemAdmins);
            Employee vitya = new Worker("Витя", "Системщик", ilyashat, TaskType.SystemAdmins);
            Employee zhenya = new Worker("Женя", "Системщик", ilyashat, TaskType.SystemAdmins);

            Employee sergey = new Worker("Сергей", "Главный у разработчиков", volodya, TaskType.Developers);
            Employee liasyan = new Worker("Ляйсан", "Зам.главного разработчиков", sergey, TaskType.Developers);
            Employee marat = new Worker("Марат", "Разработчик", liasyan, TaskType.Developers);
            Employee dina = new Worker("Дина", "Разработчик", liasyan, TaskType.Developers);
            Employee ildar = new Worker("Ильдар", "Разработчик", liasyan, TaskType.Developers);
            Employee anton = new Worker("Антон", "Разработчик", liasyan, TaskType.Developers);

            employees.AddRange(new[]
            {
                rashid, ilham, orkadiy, volodya, ilyashat, ivahych, ilya, vitya, zhenya, sergey, liasyan, marat, dina, ildar, anton
            });
        }

        public void PrintAboutEmployees()
        {
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"Имя - {employee.Name}, позиция - {employee.Postion}, начальник - {employee.Boss.Name}, " +
                    $"отдел - {employee.TaskSpecial}");
            }
        }

        public List<Employee> ReturnEmployees()
        {
            return employees;
        }

        public bool AssignTask(Employee employeeFrom, Employee employeeTo, TaskItem task)
        {
            if(employeeFrom == employeeTo) { return false; }
            Console.Write($"от человека {employeeFrom.Name} дается задача '{task.Name}' человеку {employeeTo.Name}");
            bool canTake = employeeTo.CanTakeTask(employeeFrom, task);
            if(!canTake)
            {
                Console.WriteLine($": НЕ берет");
                return false;
            }
            else
            {
                Console.WriteLine($": БЕРЕТ");
                return true;
            }
        }
    }
}
