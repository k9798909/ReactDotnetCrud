using RestfulApi.Context;
using RestfulApi.Models;
using Microsoft.EntityFrameworkCore;
using RestfulApi.IServices;

namespace RestfulApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;


        public ProductService(ProductContext productContext) {
            _productContext = productContext;
        }


        public List<Product> FindAll() {
            return _productContext.Product.ToList();
        }


        public Product? FindByProid(int proid)
        {
            //var product = _productContext.Product.Find(proid);
            var product = (from p in _productContext.Product where p.Proid == proid select p).Single();
            return product;
        }


        public void Save(Product product) {
            if (product.Proid != null)
            {
                _productContext.Product.Update(product);
            }
            else 
            {
                _productContext.Product.Add(product);
            }
            _productContext.SaveChanges();
        }

        public void Delete(int proid)
        {
            _productContext.Remove(new Product() { Proid = proid });
            _productContext.SaveChanges();
        }

        public List<Product> FindBySql() 
        {
           return  _productContext.Product
                .FromSqlRaw(" select * from product where proname = {0} ", "多拉a夢")
                .ToList();
        }



    }
}
