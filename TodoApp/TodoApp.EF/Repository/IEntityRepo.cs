using TodoApp.Model;

namespace TodoApp.EF.Repository;

public interface IEntityRepo<TEntity>
    where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    void Add(TEntity entity);
    void Update(int id, TEntity entity);
    void Delete(int id);
}