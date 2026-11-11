using Kobyzeva_hw7_Latypova.Enum;

namespace Kobyzeva_hw7_Latypova.Class
{
    public class ITManagment: Employee
    {
        public ITManagment(string name, Employee boss) : base(name, "Директор по автоматизации", boss)
        {
            TaskSpecial = TaskType.Management;
        }
    }
}
