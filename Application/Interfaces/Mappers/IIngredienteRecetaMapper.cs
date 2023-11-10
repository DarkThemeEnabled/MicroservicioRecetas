﻿using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Mappers
{
    public interface IIngredienteRecetaMapper
    {
        Task<IngredienteRecetaResponse> GetIngredienteRecetaResponse(IngredienteReceta unIngRec);
        Task<List<IngredienteRecetaResponse>> GetIngredientesRecetaResponse(ICollection<IngredienteReceta> listaIngReceta);
        Task<IngredienteRecetaDeleteResponse> GetIngredienteDeleteResponse(IngredienteReceta unIngRec);
    }
}
