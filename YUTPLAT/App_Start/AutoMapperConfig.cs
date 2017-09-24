using AutoMapper;
using YUTPLAT.Models;
using YUTPLAT.ViewModel;

namespace YUTPLAT.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(
                cfg => cfg.CreateMap<Area, AreaViewModel>()
                    .ForMember(x => x.FechaCreacion, x => x.MapFrom(y => y.FechaCreacion.ToShortDateString()))
                    .ForMember(x => x.FechaUltimaModificacion, x => x.MapFrom(y => y.FechaUltimaModificacion.ToShortDateString()))

            /*.ForMember(x => x.Pais, x => x.MapFrom(y => y.Pais.Nombre))
            .ForMember(x => x.Nombre, x => x.MapFrom(y => string.Format("{0} {1}", y.Nombre, y.Apellido)))
            .ForMember(x => x.Edad, x => x.MapFrom(y => DateTime.Now.Year - y.Nacimiento.Year));
            */
            );           
        }
    }
}