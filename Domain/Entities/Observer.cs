namespace PriceObserverAPI.Domain.Entities;

public class Observer : EntityBase
{
	public string Email { get; set; }
	public int CurrentPrice { get; set; }
	public string Url { get; set; } //TODO: Сделать списком

	public void UpdateObserverData(Observer newData)
	{
		Email = newData.Email;
		CurrentPrice = newData.CurrentPrice;
		Url = newData.Url;
	}
}