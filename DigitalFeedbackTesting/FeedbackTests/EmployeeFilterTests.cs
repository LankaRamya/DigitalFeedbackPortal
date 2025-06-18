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
    public class EmployeeFilterTests
    {
        [Test]
        public void FilterByEmployee_ReturnsCorrectFeedbacks()
        {
            var emp1 = new Employee(1, "Test", "QA");
            var emp2 = new Employee(2, "Jane", "HR");

            var feedbacks = new List<FeedbackEntry>
    {
        new FeedbackEntry("Issue with AC", Category.Facilities, emp1),
        new FeedbackEntry("HR policy is unclear", Category.Policies, emp2),
        new FeedbackEntry("Loved the culture", Category.WorkCulture, emp1)
    };

            var service = new FeedbackFilterService();
            var result = service.FilterByEmployee(feedbacks, emp1.EmployeeId);

            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(f => f.SubmittedBy.EmployeeId == emp1.EmployeeId));
        }

    }
}
