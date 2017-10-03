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
                });
        }
    }
}