using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Services;
using DigitalFeedbackPortal.Utilities;
using System;
using System.Threading.Tasks;

namespace DigitalFeedbackPortal
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Digital Feedback Portal ===\n");

            try
            {
                Console.Write("Enter your Employee ID: ");
                int employeeId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter your Name: ");
                string name = Console.ReadLine()!;

                Console.Write("Enter your Department: ");
                string department = Console.ReadLine()!;

                var employee = new Employee(employeeId, name, department);

                Console.WriteLine("\nSelect a Category:");
                var categories = Enum.GetValues<Category>();
                for (int i = 0; i < categories.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i]}");
                }

                int selectedIndex;
                do
                {
                    Console.Write("Enter choice (1-5): ");
                } while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > categories.Length);

                Category selectedCategory = categories[selectedIndex - 1];

                Console.Write("Enter your feedback: ");
                string content = Console.ReadLine()!;

                var feedback = new FeedbackEntry(content, selectedCategory, employee);

                var feedbackService = new FeedbackService();
                await feedbackService.SubmitFeedbackAsync(feedback);

                Console.WriteLine("\nFeedback submitted successfully!");
                
            }
            catch (Exception ex)
            {
                Logger.LogError("Error during feedback submission:\n" + ex.ToString());
                Console.WriteLine("An error occurred. Please check error_log.txt.");
            }

            
        }
    }
}
