using DigitalFeedbackPortal.Models;

namespace DigitalFeedbackPortal.Utilities
{
    public static class FeedbackValidator
    {
        public static bool IsValid(FeedbackEntry entry)
        {
            return entry.SubmittedBy != null
                && !string.IsNullOrWhiteSpace(entry.SubmittedBy.Name) // Assuming 'Name' is a property of 'Employee'
                && !string.IsNullOrWhiteSpace(entry.Content)
                && Enum.IsDefined(typeof(Category), entry.Category);
        }
    }
}