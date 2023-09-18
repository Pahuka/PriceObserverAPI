using System.Net;
using Newtonsoft.Json;
using PriceObserverAPI.Services.Interfaces;

namespace PriceObserverAPI.Services.UrlService;

public class UrlParseService : IUrlParseService
{
	private readonly HttpClientHandler httpHandler;

	public UrlParseService()
	{
		httpHandler = new HttpClientHandler
		{
			AllowAutoRedirect = false,
			AutomaticDecompression =
				DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None,
			CookieContainer = new CookieContainer()
		};
	}

	public async Task<IResponse<CurrentFloor>> GetPrice(string url)
	{
		var responce = new Response<CurrentFloor>();

		using (var clnt = new HttpClient(httpHandler, false))
		{
			using (var resp = clnt.GetAsync(url + "?ajax=1&similar=1").Result) //TODO: Продумать способ без изменения исходного урла
			{
				if (resp.IsSuccessStatusCode)
				{
					var json = resp.Content.ReadAsStringAsync().Result;
					responce.Data = JsonConvert.DeserializeObject<CurrentFloor>(json);
				}
			}
		}

		return responce;
	}
}