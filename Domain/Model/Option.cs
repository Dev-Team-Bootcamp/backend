namespace Domain.Model;

public class Option
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    
    public virtual Survey Survey { get; set; }
    public virtual List<Vote> Votes { get; set; }
}