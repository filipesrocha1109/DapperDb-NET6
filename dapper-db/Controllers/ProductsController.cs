using dapper_db.Common.Response;
using dapper_db.DTOs;
using dapper_db.Enums;
using dapper_db.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dapper_db.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
            
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                var response = await _productsService.GetAll();

                return StatusCode(response.Status, response);
            }
            catch (Exception e)
            {
                return StatusCode((int)ReturnStatus.InternalServerError, new Response
                {
                    Message = $"MESSAGE => {e.Message} || INNER EXCEPTION => {e.InnerException}",
                    Code = (int)ReturnCodes.ExceptionEx,
                    Success = false
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetAll(int id)
        {
            try
            {
                var response = await _productsService.Get(id);

                return StatusCode(response.Status, response);
            }
            catch (Exception e)
            {
                return StatusCode((int)ReturnStatus.InternalServerError, new Response
                {
                    Message = $"MESSAGE => {e.Message} || INNER EXCEPTION => {e.InnerException}",
                    Code = (int)ReturnCodes.ExceptionEx,
                    Success = false
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Create(ProductCreateDto request)
        {
            try
            {
                var response = await _productsService.Create(request);

                return StatusCode(response.Status, response);
            }
            catch (Exception e)
            {
                return StatusCode((int)ReturnStatus.InternalServerError, new Response
                {
                    Message = $"MESSAGE => {e.Message} || INNER EXCEPTION => {e.InnerException}",
                    Code = (int)ReturnCodes.ExceptionEx,
                    Success = false
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Update(int id, ProductUpdateDto request)
        {
            try
            {
                var response = await _productsService.Update(id, request);

                return StatusCode(response.Status, response);
            }
            catch (Exception e)
            {
                return StatusCode((int)ReturnStatus.InternalServerError, new Response
                {
                    Message = $"MESSAGE => {e.Message} || INNER EXCEPTION => {e.InnerException}",
                    Code = (int)ReturnCodes.ExceptionEx,
                    Success = false
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            try
            {
                var response = await _productsService.Delete(id);

                return StatusCode(response.Status, response);
            }
            catch (Exception e)
            {
                return StatusCode((int)ReturnStatus.InternalServerError, new Response
                {
                    Message = $"MESSAGE => {e.Message} || INNER EXCEPTION => {e.InnerException}",
                    Code = (int)ReturnCodes.ExceptionEx,
                    Success = false
                });
            }
        }

        [HttpPost("StoredProcedures")]
        public async Task<ActionResult<Response>> StoredProcedures(bool Status, decimal Price)
        {
            try
            {
                var response = await _productsService.StoredProcedures(Status, Price);

                return StatusCode(response.Status, response);
            }
            catch (Exception e)
            {
                return StatusCode((int)ReturnStatus.InternalServerError, new Response
                {
                    Message = $"MESSAGE => {e.Message} || INNER EXCEPTION => {e.InnerException}",
                    Code = (int)ReturnCodes.ExceptionEx,
                    Success = false
                });
            }
        }
    }
}
