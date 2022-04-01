using TodoApp.Model;

namespace TodoApp.EF.Repository;

public interface IEntityRepo<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Fetches data from store
    /// </summary>
    /// <returns>An enumerable collection</returns>
    IEnumerable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();
    TEntity? GetById(int id);
    Task<TEntity?> GetByIdAsync(int id);
    [Obsolete("Please use AddAsync")]
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(int id, TEntity entity);
    Task UpdateAsync(int id, TEntity entity);
    void Delete(int id);
    Task DeleteAsync(int id);
}