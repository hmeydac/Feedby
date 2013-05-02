namespace Feedby.Infrastructure.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
