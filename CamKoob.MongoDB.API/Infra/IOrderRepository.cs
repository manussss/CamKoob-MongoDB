namespace CamKoob.MongoDB.API.Infra;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAsync();
    Task<Order> GetByIdAsync(Guid id);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
    Task CreateAsync(Order order);
}