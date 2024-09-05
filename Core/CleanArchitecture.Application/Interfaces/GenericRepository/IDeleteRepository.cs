namespace CleanArchitecture.Application.Interfaces.GenericRepository;

public interface IDeleteRepository
{
    Task DeleteAsync(Guid id);
}