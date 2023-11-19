using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  // attribute : bir classla ilgili bilgi verme, imzalama (bu class bir controllerdır)
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //IoC Container => Inversion of Control
        IProductService _productService;

        public ProductsController (IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public List<Product> Get()
        {
           
           var result = _productService.GetAll();
            return result.Data;
        }
    }
}
