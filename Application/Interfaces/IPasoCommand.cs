using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPasoCommand
    {
        public Task<Paso> CreatePaso(Paso paso);
        public Task<Paso> UpdatePaso(PasoRequest pasoRequest, int pasoId);
        public Task<Paso> DeletePaso(Paso unPaso);
    }
}
