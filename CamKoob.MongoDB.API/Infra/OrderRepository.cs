namespace CamKoob.MongoDB.API.Infra;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _ordersCollection;

    public OrderRepository(IMongoDatabase database)
    {
        _ordersCollection = database.GetCollection<Order>("orders");
    }

    public async Task<IEnumerable<Order>> GetAsync()
    {
        return await _ordersCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, id);

        return await _ordersCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        var filter = Builders<Order>.Filter.Eq(o => o.Id, order.Id);
        await _ordersCollection.ReplaceOneAsync(filter, order);
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, id);
        await _ordersCollection.DeleteOneAsync(filter);
    }

    public async Task CreateAsync(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        await _ordersCollection.InsertOneAsync(order);
    }
}