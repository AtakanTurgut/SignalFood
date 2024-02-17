using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLater.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalFoodApi.Models;

namespace SignalFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);

            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalContext();
            var values = context.Baskets.Include(x => x.Product)
                .Where(y => y.MenuTableId == id).Select(z => new ResultBasketListWithProducts
                {
                    BasketId = z.BasketId,
                    MenuTableId = z.MenuTableId,
                    ProductId = z.ProductId,
                    ProductName = z.Product.ProductName,
                    Count = z.Count,
                    Price = z.Price,
                    TotalPrice = z.TotalPrice
                }).ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalContext();
            _basketService.TAdd(new Basket()
            {
                MenuTableId = 5,
                ProductId = createBasketDto.ProductId,
                Count = 1,
                Price = context.Products.Where(x => x.ProductId == createBasketDto.ProductId)
                    .Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);

            return Ok("Ürün Sepetten Kaldırıldı!");
        }
    }
}
