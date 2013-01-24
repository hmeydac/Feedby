namespace Feedby.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public FeedbackType FeedbackType { get; set; }

        public string Text { get; set; }

        public Employee SubmittedTo { get; set; }

        public Employee SubmittedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmittedDate { get; set; }
    }
}
