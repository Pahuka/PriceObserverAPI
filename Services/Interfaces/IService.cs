namespace PriceObserverAPI.Services.Interfaces;

public interface IService<TViewModel>
{
	public Task<IResponse<IQueryable<TViewModel>>> GetAll();
	public Task<IResponse<bool>> Create(TViewModel viewModel);
	public Task<IResponse<TViewModel>> Update(TViewModel viewModel);
}