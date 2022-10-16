using Dapper;
using dapper_db.Entities;
using dapper_db.Interfaces;
using dapper_db.Context;
using System.Data;
using dapper_db.DTOs;

namespace dapper_db.Repository
{
    public class ProductsRespository : IProductsRespository
    {
        private readonly DapperContext _context;

        public ProductsRespository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAll()
        {
            using var connection = _context.CreateConnection();
            
            var query = "SELECT Id, Name, Price, Status, CreatedAt FROM Products";

            var companies = await connection.QueryAsync<Products>(query);

            return companies.ToList();
        }

        public async Task<Products> Get(int id)
        {
            using var connection = _context.CreateConnection();
            
            var query = "SELECT Id, Name, Price, Status, CreatedAt FROM Products WHERE Id = @Id";

            var company = await connection.QuerySingleOrDefaultAsync<Products>(query, new { id });

            return company;
        }

        public async Task<Products> Create(ProductCreateDto productDto)
        {
            using var connection = _context.CreateConnection();
            
            var query = @"INSERT INTO Products (Name, Price, Status) VALUES (@Name, @Price, @Status) 
                            SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", productDto.Name, DbType.String);
            parameters.Add("Price", productDto.Price, DbType.Decimal);
            parameters.Add("Status", productDto.Status, DbType.Boolean);

            var id = await connection.QuerySingleAsync<int>(query, parameters);

            return new Products
            {
                Id = id,
                Name = productDto.Name,
                Price = productDto.Price,
                Status = productDto.Status
            };
        }

        public async Task<Products> Update(int id, ProductUpdateDto productDto)
        {
            using var connection = _context.CreateConnection();
            
            var query = "UPDATE Products SET Name = @Name, Price = @Price, Status = @Status WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", productDto.Name, DbType.String);
            parameters.Add("Price", productDto.Price, DbType.Decimal);
            parameters.Add("Status", productDto.Status, DbType.Boolean);

            await connection.ExecuteAsync(query, parameters);

            return await Get(id);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            
            var query = "DELETE FROM Products WHERE Id = @Id";

            await connection.ExecuteAsync(query, new { id });
        }

        public async Task<IEnumerable<Products>> StoredProcedure(bool Status, decimal Price)
        {
            using var connection = _context.CreateConnection();

            var procedure = "sp_test";
            var values = new
            {
                Status,
                Price
            };

            return await connection.QueryAsync<Products>(procedure, values, commandType: CommandType.StoredProcedure);
        }
    }
}
