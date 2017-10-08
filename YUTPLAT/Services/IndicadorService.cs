
using System.Collections.Generic;
using YUTPLAT.Models;
using YUTPLAT.Repositories.Interface;
using System.Linq;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Services.Interface
{
    public class IndicadorService : IIndicadorService
    {
        private IIndicadorRepository IndicadorRepository { get; set; }
        private IResponsableIndicadorRepository ResponsableIndicadorRepository { get; set; }
        private IInteresadoIndicadorRepository InteresadoIndicadorRepository { get; set; }

        public IndicadorService(IIndicadorRepository indicadorRepository,
                                IResponsableIndicadorRepository responsableIndicadorRepository,
                                IInteresadoIndicadorRepository interesadoIndicadorRepository)
        {
            this.IndicadorRepository = indicadorRepository;
            this.ResponsableIndicadorRepository = responsableIndicadorRepository;
            this.InteresadoIndicadorRepository = interesadoIndicadorRepository;
        }

        public IndicadorViewModel GetById(int id)
        {
            Indicador indicador = IndicadorRepository.GetById(id).First();

            IndicadorViewModel indicadorViewModel = AutoMapper.Mapper.Map<IndicadorViewModel>(indicador);
            indicadorViewModel.ObjetivoViewModel = AutoMapper.Mapper.Map<ObjetivoViewModel>(indicador.Objetivo);
            indicadorViewModel.ObjetivoViewModel.AreaViewModel = AutoMapper.Mapper.Map<AreaViewModel>(indicador.Objetivo.Area);
            indicadorViewModel.FrecuenciaMedicionIndicadorViewModel = AutoMapper.Mapper.Map<FrecuenciaMedicionIndicadorViewModel>(indicador.FrecuenciaMedicion);
            indicadorViewModel.Interesados = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Interesados.Select( i=> i.Persona ));
            indicadorViewModel.Responsables = AutoMapper.Mapper.Map<IList<PersonaViewModel>>(indicador.Responsables.Select(i => i.Persona));

            return indicadorViewModel;
        }

        public IList<IndicadorViewModel> Todas()
        {
            return AutoMapper.Mapper.Map<IList<IndicadorViewModel>>(IndicadorRepository.Todas().ToList());            
        }

        public IList<IndicadorViewModel> Buscar(BuscarIndicadorViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<IndicadorViewModel>>(IndicadorRepository.Buscar(filtro.Busqueda).ToList());           
        }

        public int Guardar(IndicadorViewModel indicadorViewModel)
        {
            // Borrar los responsables previos
            ResponsableIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            // Borrar los interesados previos
            InteresadoIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            // Guardar el indicador
            Indicador indicador = AutoMapper.Mapper.Map<Indicador>(indicadorViewModel);
            IndicadorRepository.Guardar(indicador);
            
            // Guardar los responsables
            GuardarResponsables(indicadorViewModel.Responsables, indicador.IndicadorID);
            
            // Guardar los interesados
            GuardarInteresados(indicadorViewModel.Interesados, indicador.IndicadorID);

            return indicador.IndicadorID;
        }

        private void GuardarResponsables(IList<PersonaViewModel> responsables, int indicadorID)
        {
            if (responsables != null)
            {                
                foreach (PersonaViewModel responsable in responsables)
                {
                    ResponsableIndicador responsableIndicador = new ResponsableIndicador();

                    responsableIndicador.IndicadorID = indicadorID;
                    responsableIndicador.PersonaID = responsable.Id;

                    ResponsableIndicadorRepository.Guardar(responsableIndicador);
                }
            }
        }

        private void GuardarInteresados(IList<PersonaViewModel> interesados, int indicadorID)
        {
            if (interesados != null)
            {
                foreach (PersonaViewModel interesado in interesados)
                {
                    InteresadoIndicador interesadoIndicador = new InteresadoIndicador();

                    interesadoIndicador.IndicadorID = indicadorID;
                    interesadoIndicador.PersonaID = interesado.Id;
                    
                    InteresadoIndicadorRepository.Guardar(interesadoIndicador);
                }
            }
        }
    }
}