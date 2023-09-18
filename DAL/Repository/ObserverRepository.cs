using Microsoft.EntityFrameworkCore;
using PriceObserverAPI.DAL.Interfaces;
using PriceObserverAPI.Domain.Entities;

namespace PriceObserverAPI.DAL.Repository;

public class ObserverRepository : IObserverRepository
{
	private readonly AppDbContext _appDbContext;

	public ObserverRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public async Task<bool> CreateAsync(Observer entity)
	{
		await _appDbContext.Observers.AddAsync(entity);
		return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
	}

	public async Task<Observer> UpdateAsync(Observer entity)
	{
		var observer = await _appDbContext.Observers
			.FirstOrDefaultAsync(x => x.Email == entity.Email);

		if (observer == null)
			throw new Exception($"Email {entity.Email} не найден."); //TODO: Сделать кастомный exception

		observer.UpdateObserverData(entity);

		_appDbContext.Observers.Update(entity);
		await _appDbContext.SaveChangesAsync();

		return observer;
	}

	public async Task<bool> DeleteAsync(Observer entity)
	{
		_appDbContext.Observers.Remove(entity);

		return _appDbContext.SaveChangesAsync().IsCompletedSuccessfully;
	}

	public async Task<IQueryable<Observer>> GetAllAsync()
	{
		return _appDbContext.Observers.AsQueryable();
	}
}