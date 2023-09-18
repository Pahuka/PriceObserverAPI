using PriceObserverAPI.Domain.Entities;
using PriceObserverAPI.ViewModels;

namespace PriceObserverAPI.Mappers;

public static class ObserverMapper
{
	public static Observer ToEntity(this ObserverViewModel observerViewModel)
	{
		return new Observer
		{
			Email = observerViewModel.Email,
			Url = observerViewModel.Url,
			CurrentPrice = observerViewModel.CurrentPrice
		};
	}

	public static ObserverViewModel ToViewModel(this Observer observer)
	{
		return new ObserverViewModel
		{
			Email = observer.Email,
			Url = observer.Url,
			CurrentPrice = observer.CurrentPrice
		};
	}
}