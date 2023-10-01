using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _ProductWriteRepository;
        readonly private IProductReadRepository _ProductReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _ProductWriteRepository = productWriteRepository;
            _ProductReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get() {

            await _ProductWriteRepository.AddAsync(new() { Name ="C Product", Price=1.500F, Stock =10,CreatedDate=DateTime.UtcNow});
            await _ProductWriteRepository.SaveAsync();


            //   await  _ProductWriteRepository.AddRangeAsync(new()
            //     {
            //         new(){Id=Guid.NewGuid(), Name="Product 1",Price=100, CreatedDate =DateTime.UtcNow, Stock=10},
            //         new(){Id=Guid.NewGuid(), Name="Product 2",Price=200, CreatedDate =DateTime.UtcNow, Stock=20},
            //         new(){Id=Guid.NewGuid(), Name="Product 3",Price=300, CreatedDate =DateTime.UtcNow, Stock=130},
            //     });
            //var count =    await _ProductWriteRepository.SaveAsync();

            //******************************

            //Product p =  await _ProductReadRepository.GetByIdAsync("e1d6de41-dbae-4397-9304-66fb58891538",false);
            //p.Name = "Mehmet";
            //await _ProductWriteRepository.SaveAsync();


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(string id)
        {
            Product product = await _ProductReadRepository.GetByIdAsync(id);
            return Ok(product);
        }


        //private readonly IProductService _productService;

        //public ProductsController(IProductService productService)
        //{
        //    _productService = productService;

        //}

        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //  var products =  _productService.GetProducts();
        //    return Ok(products);
        //}
    }
}
