using System.Net;
using System.Net.Mail;
using PriceObserverAPI.Services.Interfaces;
using PriceObserverAPI.ViewModels;

namespace PriceObserverAPI.Services.EmailService;

public class EmailService : IEmailService
{
	public async Task<IResponse<bool>> SendEmail(IEnumerable<ObserverViewModel> observersCollection)
	{
		var response = new Response<bool>();
		var fromEmail = ""; //Для проверки рассылки использовалась личная почта gmail
		var fromPassword = "";
		var fromAddress = new MailAddress(fromEmail, "FlatQuestion");
		var smtp = new SmtpClient
		{
			DeliveryMethod = SmtpDeliveryMethod.Network,
			Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
			UseDefaultCredentials = false,
			EnableSsl = true,
			Host = "smtp.gmail.com",
			Port = 587
		};

		try
		{
			foreach (var currentObserver in observersCollection)
			{
				var toAddress = new MailAddress(currentObserver.Email);
				var subject = "Изменение цены на отслеживаемую жилплощадь";
				var body = $"Новая цена {currentObserver.CurrentPrice}\n{currentObserver.Url}";
				using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
				{
					await smtp.SendMailAsync(message);
				}
			}

			response.Data = true;

			return response;
		}
		catch (Exception e)
		{
			response.Data = false;
			response.Description = e.Message;

			return response;
		}
	}
}