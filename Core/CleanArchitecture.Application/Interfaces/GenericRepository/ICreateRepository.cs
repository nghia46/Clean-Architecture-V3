namespace CleanArchitecture.Application.Interfaces.GenericRepository;

public interface ICreateRepository<in T> where T : class
{
    Task Create(T entity);
}