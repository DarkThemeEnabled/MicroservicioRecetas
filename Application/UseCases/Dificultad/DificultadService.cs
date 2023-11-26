using Application.Exceptions;
using Application.Interfaces.Mappers;
using Application.Interfaces.Querys;
using Application.Interfaces.Services;
using Application.Mappers;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases.SDificultad
{
    public class DificultadService : IDificultadService
    {
        private readonly IDificultadQuery _query;
        private readonly IDificultadMapper _mapper;

        public DificultadService(IDificultadQuery query, IDificultadMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<List<DificultadResponse>> GetListDificultad()
        {
            try
            {
                return await _mapper.GetListDificultadResponse(await _query.GetListDificultades());
            }
            catch (BadRequestt ex)
            {
                throw new Exceptions.BadRequestt("Error: " + ex.Message);
            }

        }

        public async Task<DificultadResponse> GetDificultadById(int id)
        {
            try
            {
                DificultadResponse dificultad = new DificultadResponse();
                if (await ValidateDificultadById(id))
                { 
                  dificultad=await _mapper.GetDificultadResponse(await _query.GetDificultadById(id));
                }
                return dificultad;
            }
            catch (BadRequestt ex)
            {
                throw new Exceptions.BadRequestt("Error: " + ex.Message);
            }

        }

        public async Task<bool> ValidateDificultadById(int dificultadId)
        {
            try
            {
                return (await _query.GetDificultadById(dificultadId) != null);
            }
            catch (Exceptions.BadRequestt ex)
            {
                throw new Exceptions.BadRequestt(ex.Message);
            }
        }
    }
}
