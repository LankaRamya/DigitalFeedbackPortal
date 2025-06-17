namespace DigitalFeedbackPortal.Models
{
    public class Admin : Employee
    {
        public string Role { get; set; }

        public Admin(int id, string name, string department, string role = "Admin")
            : base(id, name, department)
        {
            Role = role;
        }

        public override string ToString()
        {
            return $"Admin: {Name} Role: {Role} - Dept: {Department}";
        }
    }
}
