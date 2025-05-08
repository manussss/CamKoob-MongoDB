namespace CamKoob.MongoDB.API.Models;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<string> Items { get; private set; }

    public Order()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Items = [];
    }

    public void AddItems(string[] items)
    {
        Items.AddRange(items);
    }
}