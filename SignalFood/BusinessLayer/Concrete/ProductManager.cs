using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

		public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDal.ProductCountByCategoryNameDrink();
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public string TProductNameByMaxPrice()
		{
			return _productDal.ProductNameByMaxPrice();
		}

		public string TProductNameByMinPrice()
		{
			return _productDal.ProductNameByMinPrice();
		}

		public decimal TProductAvgPriceByHamburger()
		{
            return _productDal.ProductAvgPriceByHamburger();
		}
	}
}
