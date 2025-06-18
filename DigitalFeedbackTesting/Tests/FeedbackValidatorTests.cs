using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Utilities;

namespace DigitalFeedbackTesting.Tests
{
    public class FeedbackValidatorTests
    {
        [Test]
        public void IsValid_ValidFeedback_ReturnsTrue()
        {
            var entry = new FeedbackEntry("Great place!", Category.WorkCulture, new Employee(1, "Alice", "HR"))
            {
                SubmittedBy = new Employee(1, "Alice", "HR"),
                Category = Category.WorkCulture,
                Content = "Great place to work"
            };

            var result = FeedbackValidator.IsValid(entry);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_MissingContent_ReturnsFalse()
        {
            var entry = new FeedbackEntry("", Category.Policies, new Employee(2, "Bob", "IT"));
            var result = FeedbackValidator.IsValid(entry);
            Assert.IsFalse(result);
        }
    }
}

