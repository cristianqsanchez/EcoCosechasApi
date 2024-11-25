using EcoCosechas.DTOs;
using EcoCosechas.Models;
using EcoCosechas.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EcoCosechas.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcoContext context;

        public ProductRepository(EcoContext context)
        {
            this.context = context;
        }

        public Task<Producto> Create(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await context.Productos
                .Include(p => p.Subcategoria)
                .Include(p => p.Marca)
                .Include(p => p.Unidad)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Producto>> List(PaginationDTO paginationDTO)
        {
            var queryable = context.Productos.AsQueryable();
            return await queryable
                .Include(p => p.Subcategoria)
                .Include(p => p.Marca)
                .Include(p => p.Unidad)
                .Paginate(paginationDTO)
                .ToListAsync();
        }

        public Task<bool> Update(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
