namespace TaskDelegator.Models
{
    public class Assignment
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public User User { get; set; }
    }
}