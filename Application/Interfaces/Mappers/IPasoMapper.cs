﻿using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Mappers
{
    public interface IPasoMapper
    {
        Task<PasoResponse> GetPasoResponse(Paso unPaso);
        Task<List<PasoResponse>> GetListPasosResponse(ICollection<Paso> listaPasos);
    }
}
