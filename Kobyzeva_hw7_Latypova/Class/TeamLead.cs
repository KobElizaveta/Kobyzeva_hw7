using Kobyzeva_hw7_Latypova.Enum;

namespace Kobyzeva_hw7_Latypova.Class
{
    public class TeamLead: Employee
    {
        public TeamLead(string name, string position, Employee boss) : base(name, position, boss)
        {
            TaskSpecial = TaskType.Management;
        }
    }
}
