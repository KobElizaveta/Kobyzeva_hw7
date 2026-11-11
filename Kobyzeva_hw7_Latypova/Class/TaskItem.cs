using Kobyzeva_hw7_Latypova.Enum;

namespace Kobyzeva_hw7_Latypova.Class
{
    public class TaskItem
    {
        public string Name { get; set; }
        public TaskType Type { get; set; }

        public TaskItem(string name, TaskType type)
        {
            Name = name;
            Type = type;
        }
    }
}
