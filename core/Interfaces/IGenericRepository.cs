using core.Entities;

namespace core;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> GetEntityWithSpec(ISpecification<T> Spec);

     Task<IReadOnlyList<T>> ListAsync(ISpecification<T> Spec);
}
