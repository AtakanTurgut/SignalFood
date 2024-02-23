using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalFoodWebUI.Dtos.MessageDtos
{
	public class UpdateMessageDto
	{
		public int MessageId { get; set; }
		public string? NameSurname { get; set; }
		public string? Mail { get; set; }
		public string? MessageSubject { get; set; }
		public string? MessageContent { get; set; }
		public DateTime SendDate { get; set; }
		public bool MessageStatus { get; set; }
	}
}
