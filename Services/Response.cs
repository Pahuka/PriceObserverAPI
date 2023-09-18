using PriceObserverAPI.Services.Interfaces;

namespace PriceObserverAPI.Services;

public class Response<T> : IResponse<T>
{
	public T Data { get; set; }
	public string Description { get; set; }
}