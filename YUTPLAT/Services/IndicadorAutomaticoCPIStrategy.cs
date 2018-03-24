using System;
using System.Collections.Generic;
using YUTPLAT.Helpers;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using YUTPLAT.ViewModel;
using System.Linq;
using System.Data.Entity.Core.Objects;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorAutomaticoCPIStrategy : IIndicadorAutomaticoStrategy
    {
        private IMedicionRepository MedicionRepository { get; set; }

        public IndicadorAutomaticoCPIStrategy(IMedicionRepository medicionRepository)
        {
            this.MedicionRepository = medicionRepository;
        }

        private Object thisLock = new Object();

        public void EjecutarIndicador(IndicadorViewModel indicadorViewModel)
        {
            lock (thisLock)
            {
                YUTPLAT_DESAEntities spContext = new YUTPLAT_DESAEntities();

                Enums.Enum.Mes mesActual = Helpers.EnumHelper<Enums.Enum.Mes>.Parse(DateTimeHelper.OntenerFechaActual().Month.ToString());

                IList<Medicion> medicionesNuevas = AutoMapper.Mapper.Map<IList<Medicion>>(spContext.ObtenerTodasMediciones().ToList());
                Medicion medicionNuevaMes = medicionesNuevas.First(mn => (int)mn.Mes == DateTimeHelper.OntenerFechaActual().Month);
                
                Medicion medicionMes = this.MedicionRepository.Buscar(new MedicionViewModel { Grupo = indicadorViewModel.Grupo, Mes = mesActual }).FirstOrDefault();

                if (medicionMes == null)
                {
                    medicionMes = new Medicion();
                    medicionMes.Mes = mesActual;
                    medicionMes.IndicadorID = indicadorViewModel.Id;
                }

                medicionMes.FechaCarga = DateTimeHelper.OntenerFechaActual();
                medicionMes.UsuarioCargo = "Automático Sistema";
                medicionMes.Valor = medicionNuevaMes.Valor;

                this.MedicionRepository.Guardar(medicionMes);
            }
        }

        public decimal RecalcularIndicador(int mes)
        {
            ObjectParameter valorOtuput = new ObjectParameter("ValorOutput", typeof(decimal));

            YUTPLAT_DESAEntities spContext = new YUTPLAT_DESAEntities();
            spContext.ObtenerMedicionPorMes(mes, valorOtuput);

            return decimal.Parse(valorOtuput.Value.ToString());
        }

        public IList<MedicionExportarDTO> ObtenerDetallesMediciones()
        {
            YUTPLAT_DESAEntities spContext = new YUTPLAT_DESAEntities();
            return AutoMapper.Mapper.Map<IList<MedicionExportarDTO>>(spContext.ObtenerDetallesMediciones().ToList());            
        }
    }
}