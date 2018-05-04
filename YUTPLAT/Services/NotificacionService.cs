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
        private IPersonaRepository PersonaRepository { get; set; }

        public NotificacionService(INotificacionRepository notificacionRepository,
                                   IMedicionRepository medicionRepository,
                                   IPersonaRepository personaRepository)
        {
            this.NotificacionRepository = notificacionRepository;
            this.MedicionRepository = medicionRepository;
            this.PersonaRepository = personaRepository;
        }

        public async Task NotificarCarga()
        {
            try
            {
                var myMessage = new SendGridMessage();
                myMessage.AddTo(ConfigurationManager.AppSettings["SendGridToAccountTest"]);
                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["SendGridFromAccount"], "Y U T P L A T");
                myMessage.Subject = "Asunto Test";
                myMessage.Text = "Cuerpo Test";

                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SendGridUsername"],
                                                     ConfigurationManager.AppSettings["SendGridPassword"]);

                var transportWeb = new Web(credentials);
                await transportWeb.DeliverAsync(myMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

                        foreach (Persona persona in personasAAvisar)
                        {
                            try
                            {
                                string cuerpoMail = CrearTablaHtmlMedicionesInaceptables(tabla, persona.NombreApellido).ToString();

                                var myMessage = new SendGridMessage();
                                myMessage.AddTo(persona.Email);
                                myMessage.From = new MailAddress(ConfigurationManager.AppSettings["SendGridFromAccount"], "Y U T P L A T");
                                myMessage.Subject = "[Y U T P L A T] Notificación de mediciones incorrectas";
                                myMessage.Html = cuerpoMail;

                                System.Net.NetworkCredential credentials =
                                    new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SendGridUsername"],
                                                                     ConfigurationManager.AppSettings["SendGridPassword"]);

                                var transportWeb = new Web(credentials);
                                await transportWeb.DeliverAsync(myMessage);
                            }
                            catch (Exception ex) { }
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
                Console.WriteLine(ex.Message);
            }
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
                sb.AppendFormat("<th style=\"border:1px solid orange; padding:10px; text-align:center;\">{0}</th>", dc.ColumnName);
            }

            sb.AppendLine("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(tab + tab + tab + "<tr>");

                foreach (DataColumn dc in dt.Columns)
                {
                    string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
                    sb.AppendFormat("<td style=\"border:1px solid orange; padding:10px; text-align:left;\">{0}</td>", cellValue);
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