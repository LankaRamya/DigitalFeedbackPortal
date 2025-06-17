namespace DigitalFeedbackPortalTesting
{
    using DigitalFeedbackPortal.Models;
    using DigitalFeedbackPortal.Services;
    using DigitalFeedbackPortal.Utilities;

    [TestFixture]
    public class FeedbackFilterServiceTests
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
            new FeedbackEntry("Culture is amazing", Category.WorkCulture, emp),
        };
            _mockData[0].SubmittedOn = new DateTime(2024, 01, 01);
            _mockData[1].SubmittedOn = new DateTime(2024, 05, 01);
        }

        [Test]
        public void FilterByCategory_ReturnsCorrect()
        {
            var result = _filter.FilterByCategory(_mockData, Category.WorkCulture);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Culture is amazing", result.First().Content);
        }

        [Test]
        public void FilterByDateRange_ReturnsExpected()
        {
            var result = _filter.FilterByDateRange(_mockData, new DateTime(2024, 04, 01), DateTime.Now);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void FilterByContent_MatchingCaseInsensitive()
        {
            var result = _filter.FilterByContent(_mockData, "ac issue");
            Assert.AreEqual(1, result.Count());
        }
    }
    [TestFixture]
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