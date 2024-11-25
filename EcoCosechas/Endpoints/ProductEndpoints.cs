using AutoMapper;
using EcoCosechas.DTOs;
using EcoCosechas.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EcoCosechas.Endpoints
{
    public static class ProductEndpoints
    {
        public static RouteGroupBuilder MapProducts(this RouteGroupBuilder group)
        {
            group.MapGet("/", ListProducts);
            group.MapGet("/{id:int}", GetProductById);
            return group;
        }

        static async Task<Ok<List<ProductoDTO>>> ListProducts(IProductRepository repository, IMapper mapper, int page = 1, int recordsPerPage = 50)
        {
            var pagination = new PaginationDTO { Page = page, RecordsPerPage = recordsPerPage };
            var products = await repository.List(pagination);
            var productsDTO = mapper.Map<List<ProductoDTO>>(products);
            return TypedResults.Ok(productsDTO);
        }

        static async Task<Results<Ok<ProductoDTO>, NotFound>> GetProductById(int id, IProductRepository repository, IMapper mapper)
        {
            var product = await repository.GetById(id);

            if (product is null)
            {
                return TypedResults.NotFound();
            }

            var productDTO = mapper.Map<ProductoDTO>(product);
            return TypedResults.Ok(productDTO);
        }
    }
}
