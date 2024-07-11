using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendarioAPI.models;

namespace calendarioAPI.Interface
{
    public interface ICalendario
    {
        List<Calendario> GetCalendarios();

        public Task<float> PostCalendario(DateTime dataInicio, DateTime dataFinal, Calendario calendario);
    }
}