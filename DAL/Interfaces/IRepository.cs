namespace PriceObserverAPI.DAL.Interfaces;

public interface IRepository<TEntity>
{
	public Task<bool> CreateAsync(TEntity entity);
	public Task<TEntity> UpdateAsync(TEntity entity);
	public Task<bool> DeleteAsync(TEntity entity);
	public Task<IQueryable<TEntity>> GetAllAsync();
}