namespace CleanArchitecture.Domain.Interfaces.GenericRepository;

public interface IReadRepository<T>
{
    Task<IEnumerable<T>> GetsAsync();
    Task<T> GetByIdAsync(Guid id);
}