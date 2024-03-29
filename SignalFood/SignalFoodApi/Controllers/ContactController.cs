﻿using AutoMapper;
using BusinessLayer.Abstract;
using DtoLater.ContactDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
				FooterTitle = createContactDto.FooterTitle,
				FooterDescription = createContactDto.FooterDescription,
				Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone,

				OpenDaysTitle = createContactDto.OpenDaysTitle,
				OpenDaysDescription = createContactDto.OpenDaysDescription,
				OpenHours = createContactDto.OpenHours,
			});

            return Ok("İletişim Bilgisi Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);

            return Ok("İletişim Bilgisi Kaldırıldı!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactId = updateContactDto.ContactId,
                FooterTitle = updateContactDto.FooterTitle,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone,

                OpenDaysTitle = updateContactDto.OpenDaysTitle,
                OpenDaysDescription = updateContactDto.OpenDaysDescription,
                OpenHours = updateContactDto.OpenHours,
            });

            return Ok("İletişim Bilgisi Güncellendi!");
        }

    }
}
