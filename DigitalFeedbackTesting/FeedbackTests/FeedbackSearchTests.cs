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
    public class FeedbackSearchTests
    {
        private FeedbackFilterService _filter;
        private List<FeedbackEntry> _mockData;

        [SetUp]
        public void Setup()
        {
            _filter = new FeedbackFilterService();
            var emp = new Employee(1, "Test", "QA");

            _mockData = new List<FeedbackEntry>
            {
                new FeedbackEntry("AC issue", Category.Facilities, emp),
                new FeedbackEntry("Culture is amazing", Category.WorkCulture, emp)
            };

            _mockData[0].SubmittedOn = new DateTime(2024, 01, 01);
            _mockData[1].SubmittedOn = new DateTime(2024, 05, 01);
        }

        [Test]
        public void FilterByContent_CaseInsensitiveMatch_ReturnsResult()
        {
            var result = _filter.FilterByContent(_mockData, "ac issue");
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void FilterByCategory_ReturnsCorrectEntry()
        {
            var result = _filter.FilterByCategory(_mockData, Category.WorkCulture);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Culture is amazing", result.First().Content);
        }

        [Test]
        public void FilterByDateRange_ReturnsExpectedResults()
        {
            var result = _filter.FilterByDateRange(_mockData, new DateTime(2024, 04, 01), DateTime.Now);
            Assert.AreEqual(1, result.Count());
        }
    }
}
