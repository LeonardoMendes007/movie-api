namespace MovieApp.Domain.Entities;

public class Rate
{
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public int Grade { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}