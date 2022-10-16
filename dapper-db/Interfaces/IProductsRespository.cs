using dapper_db.DTOs;
using dapper_db.Entities;

namespace dapper_db.Interfaces
{
    public interface IProductsRespository
    {
        Task<IEnumerable<Products>> GetAll();
        Task<Products> Get(int id);
        Task<Products> Create(ProductCreateDto productDto);
        Task<Products> Update(int id, ProductUpdateDto productDto);
        Task Delete(int id);
        Task<IEnumerable<Products>> StoredProcedure(bool Status, decimal Price);
    }
}
