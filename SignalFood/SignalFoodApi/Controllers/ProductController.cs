﻿using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLater.ProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());

            return Ok(values);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);

            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalContext();

            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                Price = y.Price,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });

            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductStatus = createProductDto.ProductStatus
            });

            return Ok("Ürün Eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);

            return Ok("Ürün Kaldırıldı!");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                ImageUrl= updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductStatus = updateProductDto.ProductStatus
            });

            return Ok("Ürün Güncellendi!");
        }

    }
}