using PriceObserverAPI.Services.Interfaces;
using PriceObserverAPI.ViewModels;

namespace PriceObserverAPI.Services.UpdatePriceService;

public class UpdatePriceService : IUpdatePriceService
{
	private readonly IObserverService _observerService;
	private readonly IUrlParseService _urlParseService;

	public UpdatePriceService(IObserverService observerService, IUrlParseService urlParseService)
	{
		_observerService = observerService;
		_urlParseService = urlParseService;
	}

	public async Task<IResponse<List<ObserverViewModel>>> UpdatePrices(
		IEnumerable<ObserverViewModel> observerCollection)
	{
		var responce = new Response<List<ObserverViewModel>> { Data = new List<ObserverViewModel>() };

		try
		{
			foreach (var observerViewModel in observerCollection)
			{
				var newData = await _urlParseService.GetPrice(observerViewModel.Url);

				if (observerViewModel.CurrentPrice != newData.Data.price)
				{
					observerViewModel.CurrentPrice = newData.Data.price;
					responce.Data.Add(observerViewModel);
					await _observerService.Update(observerViewModel);
				}
			}

			return responce;
		}
		catch (Exception e)
		{
			responce.Description = e.Message;

			return responce;
		}
	}
}