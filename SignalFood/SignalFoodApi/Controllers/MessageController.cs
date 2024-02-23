using BusinessLayer.Abstract;
using DtoLater.MessageDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalFoodApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetAll();

			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetById(id);

			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			Message message = new Message()
			{
				NameSurname = createMessageDto.NameSurname,
				Mail = createMessageDto.Mail,
				MessageSubject = createMessageDto.MessageSubject,
				MessageContent = createMessageDto.MessageContent,
				SendDate = DateTime.Now,
				MessageStatus = false,
			};

			_messageService.TAdd(message);

			return Ok("Mesaj Başarılı Bir Şekilde Eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetById(id);
			_messageService.TDelete(value);

			return Ok("Mesaj Kaldırıldı!");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			Message message = new Message()
			{
				MessageId = updateMessageDto.MessageId,
				NameSurname = updateMessageDto.NameSurname,
				Mail = updateMessageDto.Mail,
				MessageSubject = updateMessageDto.MessageSubject,
				MessageContent = updateMessageDto.MessageContent,
				SendDate = updateMessageDto.SendDate,
				MessageStatus = updateMessageDto.MessageStatus,
			};

			_messageService.TUpdate(message);

			return Ok("Mesaj Güncellendi!");
		}

	}
}
