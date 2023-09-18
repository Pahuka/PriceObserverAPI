using PriceObserverAPI.Services.UrlService;

namespace PriceObserverAPI.Services.Interfaces;

public interface IUrlParseService
{
	public Task<IResponse<CurrentFloor>> GetPrice(string url);
}