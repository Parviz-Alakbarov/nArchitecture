using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Fuel : Entity<int>
{
    public string Name { get; set; }

    public ICollection<Model> Models { get; set; }
    public Fuel()
    {
        Models = new List<Model>();
    }
    public Fuel(int id, string name):this()
    {
        Id = id;
        Name = name;
    }
}

