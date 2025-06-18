using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Utilities;

namespace DigitalFeedbackTesting.FeedbackTests
{
    public class FeedbackValidationTests
    {
        [Test]
        public void IsValid_ValidFeedback_ReturnsTrue()
        {
            var entry = new FeedbackEntry("Great place!", Category.WorkCulture, new Employee(1, "Alice", "HR"));
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
