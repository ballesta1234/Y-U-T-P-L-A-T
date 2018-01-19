﻿
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
        private IMetaRepository MetaRepository { get; set; }
        private IMedicionRepository MedicionRepository { get; set; }

        public IndicadorService(IIndicadorRepository indicadorRepository,
                                IResponsableIndicadorRepository responsableIndicadorRepository,
                                IInteresadoIndicadorRepository interesadoIndicadorRepository,
                                IMetaRepository metaRepository,
                                IMedicionRepository medicionRepository)
        {
            this.IndicadorRepository = indicadorRepository;
            this.ResponsableIndicadorRepository = responsableIndicadorRepository;
            this.InteresadoIndicadorRepository = interesadoIndicadorRepository;
            this.MetaRepository = metaRepository;
            this.MedicionRepository = medicionRepository;
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
        
        public IList<IndicadorViewModel> Buscar(BuscarIndicadorViewModel filtro)
        {
            return AutoMapper.Mapper.Map<IList<IndicadorViewModel>>(IndicadorRepository.Buscar(filtro).ToList());           
        }

        public int Guardar(IndicadorViewModel indicadorViewModel)
        {
            Indicador indicadorOriginal = IndicadorRepository.GetById(indicadorViewModel.Id).First();

            bool modificado = false;

            if(HayCambios(indicadorOriginal, indicadorViewModel) && MedicionRepository.Buscar(new MedicionViewModel { IndicadorID = indicadorViewModel.Id}).Any())
            {
                indicadorViewModel.Id = 0;
                modificado = true;
            }

            // Borrar los responsables previos
            ResponsableIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            // Borrar los interesados previos
            InteresadoIndicadorRepository.EliminarPorIndicador(indicadorViewModel.Id);

            Indicador indicador = AutoMapper.Mapper.Map<Indicador>(indicadorViewModel);

            if(modificado)
            {
                indicador.FechaCreacion.Value.AddMilliseconds(1);
            }

            indicador.MetaAceptableMetaID = GuardarMeta(indicadorViewModel.MetaAceptableViewModel);
            indicador.MetaAMejorarMetaID = GuardarMeta(indicadorViewModel.MetaAMejorarViewModel);
            indicador.MetaExcelenteMetaID = GuardarMeta(indicadorViewModel.MetaExcelenteViewModel);
            indicador.MetaInaceptableMetaID = GuardarMeta(indicadorViewModel.MetaInaceptableViewModel);
            indicador.MetaSatisfactoriaMetaID = GuardarMeta(indicadorViewModel.MetaSatisfactoriaViewModel);
            
            // Guardar el indicador
            IndicadorRepository.Guardar(indicador);
            
            // Guardar los responsables
            GuardarResponsables(indicadorViewModel.Responsables, indicador.IndicadorID);
            
            // Guardar los interesados
            GuardarInteresados(indicadorViewModel.Interesados, indicador.IndicadorID);

            return indicador.IndicadorID;
        }

        private bool HayCambios(Indicador indicadorOriginal, IndicadorViewModel indicadorCargado)
        {
            if (!indicadorOriginal.Nombre.Trim().Equals(indicadorCargado.Nombre.Trim()) ||
                !indicadorOriginal.Descripcion.Trim().Equals(indicadorCargado.Descripcion.Trim()))
            {
                return true;
            }
            if( !indicadorOriginal.ObjetivoID.ToString().Trim().Equals(indicadorCargado.ObjetivoID.Trim()) || 
                !indicadorOriginal.FrecuenciaMedicionIndicadorID.ToString().Trim().Equals(indicadorCargado.FrecuenciaMedicionIndicadorID.Trim()))
            {
                return true;
            }
            if( MetasDiferentes(indicadorOriginal.MetaAceptable, indicadorCargado.MetaAceptableViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaAMejorar, indicadorCargado.MetaAMejorarViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaExcelente, indicadorCargado.MetaExcelenteViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaInaceptable, indicadorCargado.MetaInaceptableViewModel) ||
                MetasDiferentes(indicadorOriginal.MetaSatisfactoria, indicadorCargado.MetaSatisfactoriaViewModel))
            {
                return true;
            }
            if(InteresadosDiferentes(indicadorOriginal.Interesados, indicadorCargado.Interesados))
            {
                return true;
            }
            if (ResponsablesDiferentes(indicadorOriginal.Responsables, indicadorCargado.Responsables))
            {
                return true;
            }
            return false;
        }

        private bool InteresadosDiferentes(ICollection<InteresadoIndicador> interesadosOriginales, IList<PersonaViewModel> interesadosCargados)
        {
            if (interesadosOriginales.Count != interesadosCargados.Count)
                return true;

            foreach(PersonaViewModel interesadoCargado in interesadosCargados)
            {
                if (!interesadosOriginales.Any( i => i.Persona.UserName.Trim().Equals(interesadoCargado.NombreUsuario)))
                    return true;
            }

            return false;
        }

        private bool ResponsablesDiferentes(ICollection<ResponsableIndicador> responsablesOriginales, IList<PersonaViewModel> responsablesCargados)
        {
            if (responsablesOriginales.Count != responsablesCargados.Count)
                return true;

            foreach (PersonaViewModel responsableCargado in responsablesCargados)
            {
                if (!responsablesOriginales.Any(i => i.Persona.UserName.Trim().Equals(responsableCargado.NombreUsuario)))
                    return true;
            }

            return false;
        }

        private bool MetasDiferentes(Meta metaOriginal, MetaViewModel metaCargada)
        {
            if(!metaOriginal.Valor1.ToString().Trim().Equals(metaCargada.Valor1.Trim()))
            {
                return true;
            }
            if (!metaOriginal.Valor2.ToString().Trim().Equals(metaCargada.Valor2.Trim()))
            {
                return true;
            }
            if (!metaOriginal.Signo1.ToString().Trim().Equals(metaCargada.Signo1.ToString().Trim()))
            {
                return true;
            }
            if (!metaOriginal.Signo2.ToString().Trim().Equals(metaCargada.Signo2.ToString().Trim()))
            {
                return true;
            }

            return false;
        } 

        private int GuardarMeta(MetaViewModel metaViewModel)
        {
            Meta meta = AutoMapper.Mapper.Map<Meta>(metaViewModel);
            return MetaRepository.Guardar(meta);
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