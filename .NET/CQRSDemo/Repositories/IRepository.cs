namespace CQRSDemo.Repositories;

public interface IRepository<T>
{
    public Task<List<T>> GetAllAsync();
    public Task<T> GetAsync(int Id);
    public Task<T> AddAsync(T t);
    public Task<int> UpdateAsync(T t);
    public Task<int> DeleteAsync(int Id);
}