using Microsoft.AspNetCore.Mvc;
using PriceObserverAPI.Services.Interfaces;
using PriceObserverAPI.ViewModels;

namespace PriceObserverAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObserverController : ControllerBase
{
	private readonly IObserverService _observerService;
	private readonly IUrlParseService _parseService;
	private readonly IUpdatePriceService _updatePriceService;
	private readonly IEmailService _emailService;

	public ObserverController(IObserverService observerService, IUrlParseService parseService, 
		IUpdatePriceService updatePriceService, IEmailService emailService)
	{
		_observerService = observerService;
		_parseService = parseService;
		_updatePriceService = updatePriceService;
		_emailService = emailService;
	}

	/// <summary>
	/// Подписаться на отслеживание цены
	/// </summary>
	/// <param name="url"></param>
	/// <param name="email"></param>
	/// <returns></returns>
	[HttpPost("Subscribe")]
	public async Task<IResponse<bool>> Subscribe(string url, string email)
	{
		var currenPrice = await _parseService.GetPrice(url);
		var observer = new ObserverViewModel
		{
			CurrentPrice = currenPrice.Data.price,
			Url = url,
			Email = email
		};

		return await _observerService.Create(observer);
	}

	/// <summary>
	/// Получить список всех подписок
	/// </summary>
	/// <returns></returns>
	[HttpGet("GetAllSucsrcribers")]
	public async Task<IQueryable<ObserverViewModel>> GetAllSucsrcribers()
	{
		var response = await _observerService.GetAll();

		return response.Data;
	}

	/// <summary>
	/// Обновляет цены подписок и отправляет уведомления по email
	/// </summary>
	/// <returns></returns>
	[HttpGet("UpdateAllPrices")]
	public async Task<IResponse<bool>> UpdateAllPrices()
	{
		var updateResult = await _updatePriceService.UpdatePrices(_observerService.GetAll().Result.Data);
		var response = await _emailService.SendEmail(updateResult.Data);

		return response;
	}
}