using RestfulApi.Models;

namespace RestfulApi.IServices
{
    public interface IProductService
    {
        List<Product> FindAll();

        Product? FindByProid(int proid);

        void Save(Product product);

        void Delete(int proid);

        List<Product> FindBySql();
    }
}
