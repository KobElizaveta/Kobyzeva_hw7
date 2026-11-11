using Kobyzeva_hw7_Latypova.Enum;

namespace Kobyzeva_hw7_Latypova.Class
{
    internal class Worker: Employee
    {
        public Worker(string name, string position, Employee boss, TaskType specialization) : base(name, position, boss)
        {
            TaskSpecial = specialization;
        }
    }
}
