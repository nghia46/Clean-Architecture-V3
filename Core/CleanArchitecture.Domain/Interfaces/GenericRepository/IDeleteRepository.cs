namespace CleanArchitecture.Domain.Interfaces.GenericRepository;

public interface IDeleteRepository
{
    Task DeleteAsync(Guid id);
}