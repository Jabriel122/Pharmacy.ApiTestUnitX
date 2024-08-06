using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPharamcyProducts.Domains;
using WebApiPharamcyProducts.Interface;
using WebApiPharamcyProducts.Repository;

namespace WebApiPharamcyProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private ProductsInterface _productsRepository;

        public ProductsController()
        {
            _productsRepository = new ProductsRepository();
        }

        [HttpPost]

        public IActionResult Post(ProductsDomain productsDomain)
        {
            try
            {
                _productsRepository.Post(productsDomain);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_productsRepository.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_productsRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]

        public IActionResult DeleteById(Guid id) 
        {
            try
            {
                 _productsRepository.Delete(id);
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ProductsDomain productsDomain, Guid id)
        {
            try
            {
                 _productsRepository.Update(productsDomain, id);
                return StatusCode(204);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
