using DigitalFeedbackPortal.Models;

namespace DigitalFeedbackPortal.Utilities
{
    public static class FeedbackCategories
    {
        public static readonly Dictionary<Category, string> CategoryDisplayNames = new()
        {
            { Category.Facilities, "Facilities" },
            { Category.WorkCulture, "Work Culture" },
            { Category.Policies, "Policies" },
            { Category.Projects, "Projects" },
            { Category.Management, "Management" }
        };

        // Optional: Method to get display name
        public static string GetDisplayName(Category category)
        {
            return CategoryDisplayNames.TryGetValue(category, out var name)
                ? name
                : "Unknown";
        }
    }
}
