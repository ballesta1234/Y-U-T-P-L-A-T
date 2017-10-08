using AutoMapper;
using System;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Area, AreaViewModel>()
                    .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => y.FechaCreacion != null ? y.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm tt") : ""))
                    .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => y.FechaUltimaModificacion != null ? y.FechaUltimaModificacion.Value.ToString("dd/MM/yyyy HH:mm tt") : ""));

                    cfg.CreateMap<AreaViewModel, Area>()
                   .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaCreacion) ? DateTime.Parse(y.FechaCreacion) : (DateTime?)null))
                   .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaUltimaModificacion) ? DateTime.Parse(y.FechaUltimaModificacion) : (DateTime?)null));

                    cfg.CreateMap<Objetivo, ObjetivoViewModel>()
                    .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => y.FechaCreacion != null ? y.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm tt") : ""))
                    .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => y.FechaUltimaModificacion != null ? y.FechaUltimaModificacion.Value.ToString("dd/MM/yyyy HH:mm tt") : ""))
                    .ForMember(x => x.IdArea, x => x.MapFrom(y => y.Area != null ? y.Area.Id.ToString() : ""));
                    
                    cfg.CreateMap<ObjetivoViewModel, Objetivo>()
                   .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaCreacion) ? DateTime.Parse(y.FechaCreacion) : (DateTime?)null))
                   .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaUltimaModificacion) ? DateTime.Parse(y.FechaUltimaModificacion) : (DateTime?)null))
                   .ForMember(x => x.AreaID, x => x.MapFrom(y => !string.IsNullOrEmpty(y.IdArea) ? Int32.Parse(y.IdArea) : 0));

                    cfg.CreateMap<Indicador, IndicadorViewModel>()
                    .ForMember(x => x.Id, x => x.MapFrom(y => y.IndicadorID))
                    .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => y.FechaCreacion != null ? y.FechaCreacion.Value.ToString("dd/MM/yyyy HH:mm tt") : ""))
                    .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => y.FechaUltimaModificacion != null ? y.FechaUltimaModificacion.Value.ToString("dd/MM/yyyy HH:mm tt") : ""))
                    .ForMember(x => x.FrecuenciaMedicionIndicadorID, x => x.MapFrom(y => y.FrecuenciaMedicion != null ? y.FrecuenciaMedicion.FrecuenciaMedicionIndicadorID.ToString() : ""))
                    .ForMember(x => x.AreaID, x => x.MapFrom(y => y.Objetivo != null ? y.Objetivo.Area.Id.ToString() : ""))
                    .ForMember(x => x.Responsables, x => x.Ignore())
                    .ForMember(x => x.Interesados, x => x.Ignore());

                    cfg.CreateMap<IndicadorViewModel, Indicador>()
                    .ForMember(x => x.IndicadorID, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaCreacion) ? DateTime.Parse(y.FechaCreacion) : (DateTime?)null))
                    .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaUltimaModificacion) ? DateTime.Parse(y.FechaUltimaModificacion) : (DateTime?)null))
                    .ForMember(x => x.Responsables, x => x.Ignore())
                    .ForMember(x => x.Interesados, x => x.Ignore());
                    
                    cfg.CreateMap<FrecuenciaMedicionIndicador, FrecuenciaMedicionIndicadorViewModel>();
                    cfg.CreateMap<FrecuenciaMedicionIndicadorViewModel, FrecuenciaMedicionIndicador>();
                                       
                    cfg.CreateMap<Persona, PersonaViewModel>()
                   .ForMember(x => x.NombreUsuario, x => x.MapFrom(y => y.UserName));                  
                });
        }
    }
}