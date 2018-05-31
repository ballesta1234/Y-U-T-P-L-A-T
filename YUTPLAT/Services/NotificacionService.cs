using System.Threading.Tasks;
using YUTPLAT.Repositories.Interface;
using System;
using System.Net.Mail;
using SendGrid;
using System.Configuration;
using YUTPLAT.Helpers;
using YUTPLAT.ViewModel;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using YUTPLAT.Models;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace YUTPLAT.Services.Interface
{
    public class NotificacionService : INotificacionService
    {
        private INotificacionRepository NotificacionRepository { get; set; }
        private IMedicionRepository MedicionRepository { get; set; }
        private IIndicadorRepository IndicadorRepository { get; set; }
        private IIndicadorAutomaticoService IndicadorAutomaticoService { get; set; }
        private IPersonaRepository PersonaRepository { get; set; }

        public NotificacionService(INotificacionRepository notificacionRepository,
                                   IMedicionRepository medicionRepository,
                                   IIndicadorRepository indicadorRepository,
                                   IIndicadorAutomaticoService indicadorAutomaticoService,
                                   IPersonaRepository personaRepository)
        {
            this.NotificacionRepository = notificacionRepository;
            this.MedicionRepository = medicionRepository;
            this.IndicadorRepository = indicadorRepository;
            this.IndicadorAutomaticoService = indicadorAutomaticoService;
            this.PersonaRepository = personaRepository;
        }

        private IMailStrategy ObtenerMailStrategy()
        {
            Enums.Enum.MailTipo tipoMailStrategy = EnumHelper<Enums.Enum.MailTipo>.Parse(ConfigurationManager.AppSettings["MailTipo"]);

            switch (tipoMailStrategy)
            {
                case Enums.Enum.MailTipo.Aplicacion:
                    return new MailApplicationStrategy();
                case Enums.Enum.MailTipo.BaseDatos:
                    return new MailDatabaseStrategy();
                case Enums.Enum.MailTipo.Sendgrid:
                    return new MailSendgridStrategy();
                default:
                    return null;
            }
        }

        public async Task NotificarCarga()
        {
            try
            {
                DateTime fechaActual = DateTimeHelper.OntenerFechaActual();

                if (fechaActual.Day >= 1)
                {
                    Dictionary<Persona, IList<Indicador>> avisos = new Dictionary<Persona, IList<Indicador>>();

                    int anio = fechaActual.Year;
                    int mes = fechaActual.Month;

                    if (mes == 1)
                    {
                        anio -= 1;
                        mes = 12;
                    }
                    else
                    {
                        mes -= 1;
                    }

                    IList<Indicador> indicadores = await IndicadorRepository.Buscar(new BuscarIndicadorViewModel { AnioTablero = anio }).ToListAsync();
                    IList<IndicadorAutomaticoViewModel> todosIndicadoresAutomaticos = this.IndicadorAutomaticoService.Todos();

                    foreach (Indicador indicador in indicadores)
                    {
                        if (!todosIndicadoresAutomaticos.Any(ia => ia.IndicadorViewModel.Grupo == indicador.Grupo) &&
                            (indicador.FechaFinValidez == null  || indicador.FechaFinValidez.Value.Month >= mes) &&
                            (indicador.FechaInicioValidez == null || indicador.FechaInicioValidez.Value.Month <= mes))
                        {
                            List<Medicion> mediciones = await MedicionRepository.Buscar(new MedicionViewModel { Grupo = indicador.Grupo, Anio = anio, Mes = EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString()) }).ToListAsync();

                            if (mediciones == null || mediciones.Count == 0)
                            {
                                IList<Persona> personasAAvisar = new List<Persona>();

                                personasAAvisar = personasAAvisar.Union(indicador.Responsables.Select(i => i.Persona).ToList()).ToList();
                                personasAAvisar = personasAAvisar.Union(await PersonaRepository.Buscar(new PersonaViewModel { EsUsuario = true, AreaViewModel = new AreaViewModel { Id = indicador.Objetivo.AreaID } }).ToListAsync()).ToList();

                                personasAAvisar = personasAAvisar.Distinct(new PersonaComparer()).ToList();

                                foreach (Persona personaAAvisar in personasAAvisar)
                                {
                                    if (avisos.ContainsKey(personaAAvisar))
                                    {
                                        avisos[personaAAvisar].Add(indicador);
                                    }
                                    else
                                    {
                                        IList<Indicador> indicadorAviso = new List<Indicador>();
                                        indicadorAviso.Add(indicador);
                                        avisos.Add(personaAAvisar, indicadorAviso);
                                    }
                                }
                            }
                        }
                    }

                    IMailStrategy mailStrategy = ObtenerMailStrategy();

                    foreach (Persona persona in avisos.Keys)
                    {
                        DataTable tabla = new DataTable();
                        tabla.Columns.Add("Área", typeof(string));
                        tabla.Columns.Add("Indicador", typeof(string));
                        tabla.Columns.Add("Mes", typeof(string));

                        foreach (Indicador indicador in avisos[persona])
                        {
                            tabla.Rows.Add(indicador.Objetivo.Area.Nombre,
                                           indicador.Nombre,
                                           EnumHelper<Enums.Enum.Mes>.Parse(mes.ToString()).ToString());
                        }

                        try
                        {
                            string cuerpoMail = CrearTablaHtmlCargaMediciones(tabla, persona.NombreApellido).ToString();                            
                            await mailStrategy.EnviarCorreo(persona.Email, "[Y U T P L A T] Indicadores incompletos", cuerpoMail);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.LogException(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }

        public async Task NotificarMetas()
        {
            try
            {
                if (DateTimeHelper.OntenerFechaActual().Day >= 10)
                {
                    List<Medicion> mediciones = await MedicionRepository.Buscar(new MedicionViewModel { SeDebeNotificar = true }).ToListAsync();

                    if (mediciones != null && mediciones.Count > 0)
                    {
                        IList<Persona> personasAAvisar = new List<Persona>();

                        DataTable tabla = new DataTable();
                        tabla.Columns.Add("Área", typeof(string));
                        tabla.Columns.Add("Indicador", typeof(string));
                        tabla.Columns.Add("Mes", typeof(string));
                        tabla.Columns.Add("Valor", typeof(string));
                        tabla.Columns.Add("Comentario", typeof(string));

                        foreach (Medicion medicion in mediciones)
                        {
                            personasAAvisar = personasAAvisar.Union(medicion.Indicador.Interesados.Select(i => i.Persona).ToList()).ToList();
                            personasAAvisar = personasAAvisar.Union(medicion.Indicador.Responsables.Select(i => i.Persona).ToList()).ToList();
                            personasAAvisar = personasAAvisar.Union(await PersonaRepository.Buscar(new PersonaViewModel { EsUsuario = true, AreaViewModel = new AreaViewModel { Id = medicion.Indicador.Objetivo.AreaID } }).ToListAsync()).ToList();

                            tabla.Rows.Add(medicion.Indicador.Objetivo.Area.Nombre,
                                           medicion.Indicador.Nombre,
                                           medicion.Mes.ToString(),
                                           medicion.Valor.ToString(),
                                           (medicion.Comentario == null ? "" : medicion.Comentario));
                        }

                        personasAAvisar = personasAAvisar.Distinct(new PersonaComparer()).ToList();

                        IMailStrategy mailStrategy = ObtenerMailStrategy();
                        
                        foreach (Persona persona in personasAAvisar)
                        {
                            try
                            {
                                string cuerpoMail = CrearTablaHtmlMedicionesInaceptables(tabla, persona.NombreApellido).ToString();                                
                                await mailStrategy.EnviarCorreo(persona.Email, "[Y U T P L A T] Indicadores no satisfactorios", cuerpoMail);                                
                            }
                            catch (Exception ex)
                            {
                                LogHelper.LogException(ex);
                            }
                        }

                        foreach (Medicion medicion in mediciones)
                        {
                            medicion.SeDebeNotificar = false;
                            await MedicionRepository.Guardar(medicion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
        }

        public StringBuilder CrearTablaHtmlCargaMediciones(DataTable dt, string nombreApellido)
        {
            string tab = "\t";

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<html>");
            sb.AppendLine(tab + "<body>");
            sb.AppendFormat("<p> Hola <b> {0}</b>,</p>", nombreApellido.Trim());
            sb.Append(@"<p><b> Y U T P L A T </b> le informa las mediciones pendientes de carga: </p>");
            sb.AppendLine(tab + tab + "<table style=\"border-collapse: collapse;\" ");

            sb.Append(tab + tab + tab + "<tr>");

            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("<th style=\"border:1px solid purple; padding:10px; text-align:center;\">{0}</th>", dc.ColumnName);
            }

            sb.AppendLine("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(tab + tab + tab + "<tr>");

                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<td style=\"border:1px solid purple; padding:10px; text-align:left;\">{0}</td>", cellValue);
                }

                sb.AppendLine("</tr>");
            }

            sb.AppendLine(tab + tab + "</table>");
            sb.AppendLine(tab + @"<p>Saludos, <br/>
                                  El equipo de <b> Y U T P L A T </b></p></body>");
            sb.AppendLine("</html>");

            return sb;
        }

        public StringBuilder CrearTablaHtmlMedicionesInaceptables(DataTable dt, string nombreApellido)
        {
            string tab = "\t";

            StringBuilder sb = new StringBuilder();

            sb.Append(@"<html>");
            sb.AppendLine(tab + "<body>");
            sb.AppendFormat("<p> Hola <b> {0}</b>,</p>", nombreApellido.Trim());
            sb.Append(@"<p><b> Y U T P L A T </b> le informa las mediciones que resultaron ""Inaceptables"": </p>");
            sb.AppendLine(tab + tab + "<table style=\"border-collapse: collapse;\" ");

            sb.Append(tab + tab + tab + "<tr>");

            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat("<th style=\"border:1px solid purple; padding:10px; text-align:center;\">{0}</th>", dc.ColumnName);
            }

            sb.AppendLine("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(tab + tab + tab + "<tr>");

                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<td style=\"border:1px solid purple; padding:10px; text-align:left;\">{0}</td>", cellValue);
                }

                sb.AppendLine("</tr>");
            }

            sb.AppendLine(tab + tab + "</table>");
            sb.AppendLine(tab + @"<p>Saludos, <br/>
                                  El equipo de <b> Y U T P L A T </b></p></body>");
            sb.AppendLine("</html>");

            return sb;
        }

    }
}