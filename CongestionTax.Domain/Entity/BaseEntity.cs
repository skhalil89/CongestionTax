namespace CongestionTax.Domain
{
    public class BaseEntity
    { 
        public Guid Id { get; set; } 
        public DateTimeOffset CreatedDate { get; set; }
    }
}
