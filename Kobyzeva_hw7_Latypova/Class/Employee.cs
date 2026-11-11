using Kobyzeva_hw7_Latypova.Enum;

namespace Kobyzeva_hw7_Latypova.Class
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Postion { get; set; }

        public Employee Boss { get; set; }
        public TaskType TaskSpecial { get; set; }

        public Employee(string name, string postion, Employee boss)
        {
            Name = name;
            Postion = postion;
            Boss = boss;
        }

        public virtual bool CanTakeTask(Employee fromWho, TaskItem task)
        {
            if(fromWho == Boss && TaskSpecial == task.Type)
            {
                return true;
            }
            return false;
        }
    }
}
