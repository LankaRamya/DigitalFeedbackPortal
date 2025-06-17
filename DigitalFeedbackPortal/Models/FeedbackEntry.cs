using System;

namespace DigitalFeedbackPortal.Models
{
    public class FeedbackEntry
    {
        public Guid FeedbackId { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
        public DateTime SubmittedOn { get; set; }
        public Employee SubmittedBy { get; set; }

        public FeedbackEntry(string content, Category category, Employee submittedBy)
        {
            FeedbackId = Guid.NewGuid();
            Content = content;
            Category = category;
            SubmittedOn = DateTime.Now;
            SubmittedBy = submittedBy;
        }

        public override string ToString()
        {
            return $"[{SubmittedOn}] {SubmittedBy.Name}: \"{Content}\" ({Category})";
        }
    }
}