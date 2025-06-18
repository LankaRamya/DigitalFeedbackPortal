using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Utilities;
using DigitalFeedbackPortal.Services;
using System;

namespace DigitalFeedbackPortal
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //--Member-3--
            Console.WriteLine("=== Digital Feedback Portal ===\n");

            // Employee Input
            Console.Write("Enter your Employee ID: ");
            int employeeId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter your Department: ");
            string department = Console.ReadLine()!;

            var employee = new Employee(employeeId, name, department);

            // Category Selection
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

            // Feedback Content
            Console.Write("Enter your feedback: ");
            string content = Console.ReadLine()!;

            var feedback = new FeedbackEntry(content, selectedCategory, employee);

            // === Member 6: Exception Handling and Logging START ===
            try
            {
                var feedbackservice = new FeedbackService();
                await feedbackservice.SubmitFeedbackAsync(feedback);
                Console.WriteLine("\nFeedback submitted successfully!");
            }
            catch (Exception ex)
            {
                Logger.LogError("Feedback submission error: " + ex.Message);
                Console.WriteLine("An error occurred. Please check error_log.txt.");
            }

            try
            {
                Employee emp = new Employee(1, null, "IT");
                Console.WriteLine("Employee name length: " + emp.Name.Length); // causes exception
            }
            catch (NullReferenceException ex)
            {
                Logger.LogError("Null reference error: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.LogError("Unauthorized access: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.LogError("General error: " + ex.Message);
            }

            Console.WriteLine("Program completed with error logging.");
            // === Member 6: Exception Handling and Logging END ===
        }
    }
}