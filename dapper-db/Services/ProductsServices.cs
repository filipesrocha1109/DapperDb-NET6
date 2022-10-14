using dapper_db.Common.Response;
using dapper_db.DTOs;
using dapper_db.Enums;
using dapper_db.Interfaces;

namespace dapper_db.Services
{
    public class ProductsServices : IProductsService
    {
        private readonly IProductsRespository _productsRespository;

        public ProductsServices(IProductsRespository productsRespository)
        {
            _productsRespository = productsRespository;
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var products = await _productsRespository.GetAll();

                return new Response
                {
                    Data = products,
                    Success = true,
                    Message = Utils.GetEnumDescription(ReturnCodes.Ok),
                    Code = (int)ReturnCodes.Ok,
                    Status = (int)ReturnStatus.Ok
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Success = false,
                    Message = $"{Utils.GetEnumDescription(ReturnCodes.InternalError)} => {e.Message}|| {e.InnerException}",
                    Code = (int)ReturnCodes.InternalError,
                    Status = (int)ReturnStatus.InternalServerError
                };
            }
        }

        public async Task<Response> Get(int id)
        {
            try
            {
                var products = await _productsRespository.Get(id);

                if(products is null)
                    return new Response
                    {
                        Success = false,
                        Message = Utils.GetEnumDescription(ReturnCodes.NotFound),
                        Code = (int)ReturnCodes.NotFound,
                        Status = (int)ReturnStatus.NotFound
                    };

                return new Response
                {
                    Data = products,
                    Success = true,
                    Message = Utils.GetEnumDescription(ReturnCodes.Ok),
                    Code = (int)ReturnCodes.Ok,
                    Status = (int)ReturnStatus.Ok
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Success = false,
                    Message = $"{Utils.GetEnumDescription(ReturnCodes.InternalError)} => {e.Message}|| {e.InnerException}",
                    Code = (int)ReturnCodes.InternalError,
                    Status = (int)ReturnStatus.InternalServerError
                };
            }
        }

        public async Task<Response> Create(ProductCreateDto request)
        {
            try
            {
                var product = await _productsRespository.Create(request);

                return new Response
                {
                    Data = product,
                    Success = true,
                    Message = Utils.GetEnumDescription(ReturnCodes.Ok),
                    Code = (int)ReturnCodes.Ok,
                    Status = (int)ReturnStatus.Ok
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Success = false,
                    Message = $"{Utils.GetEnumDescription(ReturnCodes.InternalError)} => {e.Message}|| {e.InnerException}",
                    Code = (int)ReturnCodes.InternalError,
                    Status = (int)ReturnStatus.InternalServerError
                };
            }
        }

        public async Task<Response> Update(int id,ProductUpdateDto request)
        {
            try
            {
                var product = await _productsRespository.Update(id,request);

                return new Response
                {
                    Data = product,
                    Success = true,
                    Message = Utils.GetEnumDescription(ReturnCodes.Ok),
                    Code = (int)ReturnCodes.Ok,
                    Status = (int)ReturnStatus.Ok
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Success = false,
                    Message = $"{Utils.GetEnumDescription(ReturnCodes.InternalError)} => {e.Message}|| {e.InnerException}",
                    Code = (int)ReturnCodes.InternalError,
                    Status = (int)ReturnStatus.InternalServerError
                };
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                await _productsRespository.Delete(id);

                return new Response
                {
                    Success = true,
                    Message = Utils.GetEnumDescription(ReturnCodes.Ok),
                    Code = (int)ReturnCodes.Ok,
                    Status = (int)ReturnStatus.Ok
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    Success = false,
                    Message = $"{Utils.GetEnumDescription(ReturnCodes.InternalError)} => {e.Message}|| {e.InnerException}",
                    Code = (int)ReturnCodes.InternalError,
                    Status = (int)ReturnStatus.InternalServerError
                };
            }
        }
    }
}
