using dapper_db.Common.Response;
using dapper_db.DTOs;

namespace dapper_db.Interfaces
{
    public interface IProductsService
    {
        Task<Response> GetAll();
        Task<Response> Get(int id);
        Task<Response> Create(ProductCreateDto request);
        Task<Response> Update(int id, ProductUpdateDto request);
        Task<Response> Delete(int id);
        Task<Response> StoredProcedures(bool Status, decimal Price);
    }
}
