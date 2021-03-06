﻿using System.ComponentModel.DataAnnotations;

namespace YUTPLAT.Enums
{
    public static class Enum
    {
        public enum Rol
        {
            [Display(Name = " ")]
            Indefinido = 0,
            [Display(Name = "admin")]
            Admin = 1,
            [Display(Name = "usuario")]
            Usuario = 2,
            [Display(Name = "operador")]
            Operador = 3
        }

        public enum Signo
        {
            [Display(Name = " ")]
            Indefinido = 0,
            [Display(Name = "<")]
            Menor = 1,
            [Display(Name = ">")]
            Mayor = 2,
            [Display(Name = "=")]
            Igual = 3,
            [Display(Name = ">=")]
            MayorOIgual = 4,
            [Display(Name = "<=")]
            MenorOIgual = 5,
        }

        public enum Mes
        {
            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12,
        }

        public enum ColorMeta
        {
            MetaExcelente = 0,
            MetaSatisfactoria = 1,
            MetaAceptable = 2,
            MetaAMejorar = 3,
            MetaInaceptable = 4
        }

        public enum PermisoIndicador
        {
            SoloLectura = 1,
            LecturaEscritura = 2
        }

        public enum CategoriaIndicadorAutomatico
        {
            CPI = 1,
            CPI_Servicios = 2,
            CPI_Llave_En_Mano = 3
        }

        public enum MailTipo
        {
            Sendgrid = 1,
            Aplicacion = 2,
            BaseDatos = 3
        }

        public enum TipoAuditoria
        {
            UltimaActualizacionVistaTablero = 1,
            ModificacionIndicador = 2,
            LoginUsuario = 3
        }
    }
}