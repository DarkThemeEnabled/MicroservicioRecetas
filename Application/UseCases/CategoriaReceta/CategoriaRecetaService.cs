using Application.Exceptions;
using Application.Interfaces.Mappers;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Application.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.UseCases.CategoriaReceta
{
    public class CategoriaRecetaService : ICategoriaRecetaService
    {
        private readonly ICategoriaRecetaQuery _categoriaQuery;
        private readonly ICategoriaRecetaMapper _categoriaMapper;

        public CategoriaRecetaService(ICategoriaRecetaQuery categoriaQuery, ICategoriaRecetaMapper mapper)
        {
            _categoriaQuery = categoriaQuery;
            _categoriaMapper = mapper;
        }

        public async Task<CategoriaRecetaResponse> GetCategoriaRecetaById(int id)
        {
            try
            {
                return await _categoriaMapper.GetCategoriaRecetaResponse(await _categoriaQuery.GetCategoriaRecetaById(id));
            }
            catch (BadRequestt ex)
            {
                throw new Exceptions.BadRequestt("Error: " + ex.Message);
            }
        }

        public async Task<List<CategoriaRecetaResponse>> GetCategoriasReceta()
        {
                try
                {
                    return await _categoriaMapper.GetListCategoriaRecetaResponse(await _categoriaQuery.GetCategoriaRecetas());
                }
                catch (BadRequestt ex)
                {
                    throw new Exceptions.BadRequestt("Error: " + ex.Message);
                }

        }

        public async Task<bool> ValidateCategoriaRecetaById(int categoriaRecetaId)
        {
            return !(await _categoriaQuery.GetCategoriaRecetaById(categoriaRecetaId) == null);
        }
    }
}
