using BusinessLayer.Abstract;
using DtoLater.MenuTableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalFoodApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menuTableService.TGetAll();

			return Ok(values);
		}

		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);

			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				TableNumber = createMenuTableDto.TableNumber,
				Status = false,
			};

			_menuTableService.TAdd(menuTable);

			return Ok("Masa Başarılı Bir Şekilde Eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);

			return Ok("Masa Kaldırıldı!");
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable menuTable = new MenuTable()
			{
				MenuTableId = updateMenuTableDto.MenuTableId,
				TableNumber = updateMenuTableDto.TableNumber,
				Status = false,
			};

			_menuTableService.TUpdate(menuTable);

			return Ok("Masa Güncellendi!");
		}

	}
}
