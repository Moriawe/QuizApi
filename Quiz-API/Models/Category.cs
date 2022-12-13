namespace Quiz_API.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    
    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}