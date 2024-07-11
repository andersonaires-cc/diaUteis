using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendarioAPI.Interface;
using calendarioAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Implementation;
using Microsoft.VisualBasic;
using Nager.Holiday;

namespace calendarioAPI.services
{
    public class CalendarioService : ICalendario
    {
        
        List<Calendario> calendarios = new List<Calendario>();

        public List<Calendario> GetCalendarios()
        {
            return calendarios;
        }

        public async Task<float> PostCalendario(DateTime dataInicio, DateTime dataFinal, Calendario calendario)
        {
            
            DateTime[] feriados = await FeriadosBr();
            var diasUteis = ContarDiasUteis(dataInicio,dataFinal,feriados);
            

            calendario.cargaHorariaMes = ContarHoras(diasUteis,calendario.cargaHorariaDia);
            var result = calendario.cargaHorariaMes;
            calendarios.Add(calendario);



            return result; 
        }

        public async Task<DateTime[]> FeriadosBr()
        {
            using var holidayClient = new HolidayClient();
            var holidays = await holidayClient.GetHolidaysAsync(2024,"br");
            
            List<DateTime> data = new List<DateTime>();

            foreach(var feriado in holidays)
            {
                data.Add(feriado.Date);
            }

            return data.ToArray();
        }

        public static int ContarDiasUteis(DateTime dataInicio, DateTime dataFim, DateTime[] feriados)
        {            
            List<DateTime> datas = new List<DateTime>();

            for(DateTime i = dataInicio.Date;i<= dataFim.Date; i = i.AddDays(1))
            {
                datas.Add(i);
            }

            return datas.Count(d => d.DayOfWeek != DayOfWeek.Saturday &&
                                    d.DayOfWeek != DayOfWeek.Sunday &&
                                    !feriados.Contains(d));
        }

        public static float ContarHoras(int diasUteis,float cargaHorariaDia)
        {

            return diasUteis*cargaHorariaDia; 
        }


    }
}