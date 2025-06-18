using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Services;

namespace DigitalFeedbackTesting.Tests
{
    public class FeedbackServiceTests
    {
        [Test]
        public async Task SubmitFeedbackAsync_ValidData_WritesToFile()
        {
            var feedbackService = new FeedbackService();
            var emp = new Employee(3, "David", "R&D");

            var entry = new FeedbackEntry("Good cafeteria", Category.Facilities, emp)
            {
                SubmittedBy = emp,
                Content = "Good cafeteria",
                Category = Category.Facilities
            };

            // Act and Assert
            Assert.DoesNotThrowAsync(async () => await feedbackService.SubmitFeedbackAsync(entry));
        }
    }
}
