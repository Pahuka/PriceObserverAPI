using PriceObserverAPI.ViewModels;
using System.Collections.Generic;

namespace PriceObserverAPI.Services.Interfaces;

public interface IUpdatePriceService
{
	public Task<IResponse<List<ObserverViewModel>>> UpdatePrices(IEnumerable<ObserverViewModel> observerCollection);
}