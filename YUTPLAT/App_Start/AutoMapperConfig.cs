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
                    .ForMember(x => x.IdArea, x => x.MapFrom(y => y.Area != null ? y.Area.Id.ToString() : ""))
                    .ForMember(x => x.AreaViewModel, x => x.MapFrom(y => y.Area));

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
                    .ForMember(x => x.ObjetivoViewModel, x => x.MapFrom(y => y.Objetivo))
                    .ForMember(x => x.Grupo, x => x.MapFrom(y => y.Grupo))
                    .ForMember(x => x.MetaAceptableViewModel, x => x.MapFrom(y => y.MetaAceptable))
                    .ForMember(x => x.MetaAMejorarViewModel, x => x.MapFrom(y => y.MetaAMejorar))
                    .ForMember(x => x.MetaExcelenteViewModel, x => x.MapFrom(y => y.MetaExcelente))
                    .ForMember(x => x.MetaInaceptableViewModel, x => x.MapFrom(y => y.MetaInaceptable))
                    .ForMember(x => x.MetaSatisfactoriaViewModel, x => x.MapFrom(y => y.MetaSatisfactoria))
                    .ForMember(x => x.Responsables, x => x.Ignore())
                    .ForMember(x => x.Interesados, x => x.Ignore());

                    cfg.CreateMap<Indicador, FilaHeatMapViewModel>()
                    .ForMember(x => x.IdIndicador, x => x.MapFrom(y => y.IndicadorID))
                    .ForMember(x => x.Grupo, x => x.MapFrom(y => y.Grupo))
                    .ForMember(x => x.NombreIndicador, x => x.MapFrom(y => y.Nombre));

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

                    cfg.CreateMap<Meta, MetaViewModel>()
                    .ForMember(x => x.Valor1, x => x.MapFrom(y => (y.Valor1 == 0 && (int)y.Signo1 == 0) ? "" : y.Valor1.ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.')))               
                    .ForMember(x => x.Valor2, x => x.MapFrom(y => (y.Valor2 == 0 && (int)y.Signo2 == 0) ? "" : y.Valor2.ToString().Replace(",", ".").TrimEnd('0').TrimEnd('.')));

                    cfg.CreateMap<MetaViewModel, Meta>()
                    .ForMember(x => x.Valor1, x => x.MapFrom(y => Decimal.Parse(y.Valor1.Replace(".",","))))
                    .ForMember(x => x.Valor2, x => x.MapFrom(y => Decimal.Parse(y.Valor2.Replace(".", ","))));

                    cfg.CreateMap<Medicion, MedicionViewModel>()
                    .ForMember(x => x.Valor, x => x.MapFrom(y => (y.Valor == 0) ? "" : y.Valor.ToString().Replace(",", ".")))
                    .ForMember(x => x.FechaCarga, x => x.MapFrom(y => y.FechaCarga != null ? y.FechaCarga.Value.ToString("dd/MM/yyyy HH:mm tt") : ""))
                    .ForMember(x => x.IndicadorViewModel, x => x.MapFrom(y => y.Indicador));

                    cfg.CreateMap<Medicion, LineViewModel>()
                    .ForMember(x => x.Valor, x => x.MapFrom(y => y.Valor))
                    .ForMember(x => x.Mes, x => x.MapFrom( y => y.Mes.ToString()));
                    
                    cfg.CreateMap<MedicionViewModel, Medicion>()                    
                    .ForMember(x => x.FechaCarga, x => x.MapFrom(y => !string.IsNullOrEmpty(y.FechaCarga) ? DateTime.Parse(y.FechaCarga) : (DateTime?)null))
                    .ForMember(x => x.Indicador, x => x.MapFrom(y => y.IndicadorViewModel))
                    .ForMember(x => x.Valor, x => x.MapFrom(y => Decimal.Parse(y.Valor.Replace(".", ","))));
                });
        }
    }
}