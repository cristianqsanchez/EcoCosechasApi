using EcoCosechas.Models;
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

        public Task<Producto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> List()
        {
            return await context.Productos
                .Include(p => p.Subcategoria)
                .Include(p => p.Marca)
                .Include(p => p.Unidad)
                .ToListAsync();
        }

        public Task<bool> Update(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
