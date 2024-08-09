namespace CleanArchitecture.Domain.Interfaces.GenericRepository;

public interface IUpdateRepository<in T> where T : class
{
    Task Update(Guid id, T entity);
}