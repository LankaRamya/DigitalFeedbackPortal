using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Services;

namespace DigitalFeedbackTesting.FeedbackTests
{
    public class FeedbackCreationTests
    {
        [Test]
        public async Task SubmitFeedbackAsync_ValidData_DoesNotThrow()
        {
            var feedbackService = new FeedbackService();
            var emp = new Employee(3, "David", "R&D");

            var entry = new FeedbackEntry("Good cafeteria", Category.Facilities, emp)
            {
                SubmittedBy = emp,
                Content = "Good cafeteria",
                Category = Category.Facilities
            };

            await feedbackService.SubmitFeedbackAsync(entry);

            Assert.Pass("No exception was thrown.");
        }

    }
}
