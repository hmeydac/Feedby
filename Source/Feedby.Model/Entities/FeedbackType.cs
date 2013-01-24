namespace Feedby.Model.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackType
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public string ClassName { get; set; }
    }
}
