using DigitalFeedbackPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFeedbackPortal.Services
{
    public class FeedbackFilterService
    {
        public IEnumerable<FeedbackEntry> FilterByCategory(IEnumerable<FeedbackEntry> feedbacks, Category category)
        {
            return feedbacks.Where(f => f.Category == category);
        }
        public IEnumerable<FeedbackEntry> FilterByDateRange(IEnumerable<FeedbackEntry> feedbacks, DateTime startdate, DateTime enddate)
        {
            return feedbacks.Where(f => f.SubmittedOn >= startdate && f.SubmittedOn <= enddate);
        }
        public IEnumerable<FeedbackEntry> FilterByContent(IEnumerable<FeedbackEntry> feedbacks, string contant)
        {
            return feedbacks.Where(f => string.Equals(f.Content, contant, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<FeedbackEntry> FilterByEmployee(List<FeedbackEntry> entries, int employeeId)
        {
            return entries.Where(e => e.SubmittedBy.EmployeeId == employeeId);
        }

        public void Displayfeedback(IEnumerable<FeedbackEntry> feedbacks)
        {
            foreach (var fb in feedbacks)
            {
                Console.WriteLine($"[{fb.SubmittedOn}] {fb.SubmittedBy} - {fb.Category}  /n{fb.Content}");
            }
        }
    }
}

