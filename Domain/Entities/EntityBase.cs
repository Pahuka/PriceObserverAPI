namespace PriceObserverAPI.Domain.Entities;

public abstract class EntityBase
{
	public EntityBase()
	{
		Id = Guid.NewGuid();
		CreatedDate = DateTime.Now;
	}

	public Guid Id { get; set; }
	public DateTime CreatedDate { get; set; }
}