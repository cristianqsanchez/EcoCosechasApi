﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcoCosechas.DTOs;
using EcoCosechas.Models;

namespace EcoCosechas.Repositories
{
    public interface IProductRepository
    {
        Task<Producto> Create(Producto producto);

        Task<Producto?> GetById(int id);

        Task<bool> Update(Producto producto);

        Task<bool> Delete(int id);

        Task<List<Producto>> List(PaginationDTO paginationDTO);
    }
}
