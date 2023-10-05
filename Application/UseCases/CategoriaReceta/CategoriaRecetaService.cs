﻿using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CategoriaReceta
{
    public class CategoriaRecetaService: ICategoriaRecetaService
    {
        private readonly ICategoriaRecetaQuery _categoriaQuery;

        public CategoriaRecetaService(ICategoriaRecetaQuery categoriaQuery)
        {
            _categoriaQuery = categoriaQuery;
        }

        public async Task<bool> ValidateCategoriaRecetaById(int categoriaRecetaId)
        {
            return !(await _categoriaQuery.getCategoriaRecetaById(categoriaRecetaId) == null);
        }
    }
}