using PriceObserverAPI.ViewModels;

namespace PriceObserverAPI.Services.Interfaces;

public interface IEmailService
{
	public Task<IResponse<bool>> SendEmail(IEnumerable<ObserverViewModel> observersCollection);
}