namespace PriceObserverAPI.Services.Interfaces;

public interface IResponse<T>
{
	T Data { get; set; }
	public string Description { get; set; }
}