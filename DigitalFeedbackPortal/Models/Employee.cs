namespace DigitalFeedbackPortal.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee(int id, string name, string department)
        {
            EmployeeId = id;
            Name = name;
            Department = department;
        }
        //Ganesh Varma
        public override string ToString()
        {
            return $"{Name} (ID: {EmployeeId}) - {Department}";
        }
    }
}
