using PriceObserverAPI.DAL.Interfaces;
using PriceObserverAPI.Mappers;
using PriceObserverAPI.Services.Interfaces;
using PriceObserverAPI.ViewModels;

namespace PriceObserverAPI.Services.ObserverService;

public class ObserverService : IObserverService
{
	private readonly IObserverRepository _observerRepository;

	public ObserverService(IObserverRepository observerRepository)
	{
		_observerRepository = observerRepository;
	}

	public async Task<IResponse<bool>> Create(ObserverViewModel observerViewModel)
	{
		//TODO: Сделать проверку на уникальность email, если находим - добавить новый url

		var response = new Response<bool>();

		try
		{
			response.Data = _observerRepository.CreateAsync(observerViewModel.ToEntity()).IsCompletedSuccessfully;

			return response;
		}
		catch (Exception e)
		{
			response.Data = false;
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<IQueryable<ObserverViewModel>>> GetAll()
	{
		var response = new Response<IQueryable<ObserverViewModel>>();

		try
		{
			var games = await _observerRepository.GetAllAsync();
			response.Data = games.Select(x => x.ToViewModel());

			return response;
		}
		catch (Exception e)
		{
			response.Description = e.Message;

			return response;
		}
	}

	public async Task<IResponse<ObserverViewModel>> Update(ObserverViewModel viewModel)
	{
		var response = new Response<ObserverViewModel>();

		try
		{
			await _observerRepository.UpdateAsync(viewModel.ToEntity());
			response.Data = viewModel;

			return response;
		}
		catch (Exception e)
		{
			response.Description = e.Message;

			return response;
		}
	}
}