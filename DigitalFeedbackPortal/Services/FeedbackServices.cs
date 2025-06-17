using DigitalFeedbackPortal.Models;
using DigitalFeedbackPortal.Utilities;

namespace DigitalFeedbackPortal.Services
{
    public class FeedbackService
    {
        private static readonly string FilePath = "feedback.txt";

        public async Task SubmitFeedbackAsync(FeedbackEntry entry)
        {
            if (!FeedbackValidator.IsValid(entry))
                throw new ArgumentException("Invalid Feedback Entry.");

            string formatted = entry.ToString();
            await File.AppendAllTextAsync(FilePath, formatted + Environment.NewLine);
        }
    }
}
