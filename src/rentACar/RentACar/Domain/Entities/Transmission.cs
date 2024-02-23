using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transmission : Entity<int>
{
    public string Name { get; set; }

    public ICollection<Model> Models { get; set; }
    public Transmission()
    {
        Models = new List<Model>();
    }
    public Transmission(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}

