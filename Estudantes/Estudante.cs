public class Estudante
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public bool active { get; private set; }

    public Estudante(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        active = true;
    }

    public void setName(string name)
    {
        Name = name;
    }

    public void setActive(bool active)
    {
        this.active = active;
    }
}
