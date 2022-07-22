using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.IServices;
using RestfulApi.Models;

namespace RestfulApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;



        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }



        //fetch('https://localhost:7052/product').then(res => {console.log(res)}).catch(e => {console.log(e)})
        [HttpGet]
        public List<Product> GetAll()
        {
            return _productService.FindAll();
        }



        //fetch('https://localhost:7052/product/100000026').then(res => res.json()).then(json => console.log(json)).catch(e => {console.log(e)})
        [HttpGet("{proid}")]
        public Product? GetProduct(int proid)
        {
            return _productService.FindByProid(proid);
        }



        //fetch('https://localhost:7052/product', {
        //method: 'POST', 
        //body: JSON.stringify({proname:"asdas",proprice:123,proqty:123}),
        //headers: new Headers({
        //      'Content-Type': 'application/json'
        // })
        //}).then(res => { console.log(res)}).catch (e => { console.log(e)})
        [HttpPost]
        public Product Post(Product product)
        {
            _productService.Save(product);
            return product;
        }



        //    fetch('https://localhost:7052/product', {
        //    method: 'PUT', 
        //body: JSON.stringify({ proid: 100000024,proname: "測試測設",proprice: 123,proqty: 123}),
        //    headers: new Headers({
        //          'Content-Type': 'application/json'
        //     })
        //    }).then(res => { console.log(res)}).catch (e => { console.log(e)
        //})
        [HttpPut]
        public Product Put(Product product)
        {
            _productService.Save(product);
            return product;
        }


        //    fetch('https://localhost:7052/product/100000024', {
        //    method: 'DELETE', 
        //    }).then(res => { console.log(res)}).catch (e => { console.log(e)
        //})
        [HttpDelete("{proid}")]
        public String Delete(int proid)
        {
            _productService.Delete(proid);
            return "刪除成功";
        }

        [HttpHead("head")]
        public void Head() 
        {
        }


    }
}
