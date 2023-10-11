using Application.Exceptions;
using Application.Interfaces;
using Application.Mappers;
using Application.Request;
using Application.Response;
using Application.UseCases.SPasos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.SDificultad
{
    public class DificultadService:IDificultadService
    {
        private readonly IDificultadQuery _query;
        DificultadMapper mapper;

        public DificultadService(IDificultadQuery query)
        {
            _query = query;
            mapper = new DificultadMapper();
        }

        public async Task<List<DificultadResponse>> GetListDificultad()
        {
            try
            {
                return await mapper.GetListDificultadResponse(await _query.GetListDificultades());
            }
            catch (BadRequestt ex)
            {
                throw new Exceptions.BadRequestt("Error: "+ex.Message);
            }
            
        }

        //public async Task<DificultadResponse> GetDificultadById(int id)
        //{
        //    try
        //    {
        //        return await mapper.GetDificultadResponse(await _query.GetDificultadById(id));
        //    }
        //    catch (ExceptionNotFound)
        //    {
        //        throw new ExceptionNotFound("No existe esa dificultad");
        //    }
        //}

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

        private Task<DificultadResponse> GenerateDificultadResponse (Dificultad dificultad)
        {
            return Task.FromResult(new DificultadResponse
            {
                Id = dificultad.DificultadId,
                Nombre = dificultad.Nombre,
            });
        }

        private Task<List<DificultadResponse>> GenerateListDificultadResponse (List<Dificultad> listaDificultades)
        {
            List<DificultadResponse> listDificultadResponses = new List<DificultadResponse>();
            if (listaDificultades.Count > 0) 
            {    
                foreach (var dificultad in listaDificultades)
                {
                    DificultadResponse response = GenerateDificultadResponse(dificultad).Result;
                    listDificultadResponses.Add(response);
                } 
            }
            return Task.FromResult(listDificultadResponses);
        }
    }
}
