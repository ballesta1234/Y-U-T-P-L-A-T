using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.Services.Interface;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class TableroController : Controller
    {
        public IMedicionService MedicionService { get; set; }

        public TableroController(IMedicionService medicionService)
        {
            this.MedicionService = medicionService;
        }

        public ActionResult Ver()
        {
            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Gauge()
        {
            DemoViewModel model = new DemoViewModel();
            model.Titulo = "Dashboard";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        public ActionResult Tablero()
        {
            TableroViewModel model = new TableroViewModel();
            model.Titulo = "Tablero";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }

        [HttpPost]
        public ActionResult ObtenerValores(string nombre)
        {
            IList<MedicionViewModel> mediciones = MedicionService.Todas();

            IList<aa> aas = new List<aa>();

            CargarValores(1, aas, 20);
            CargarValores(2, aas, 11);
            CargarValores(3, aas, 5);
            CargarValores(4, aas, 1);
            CargarValores(5, aas, 15);
            CargarValores(6, aas, 8);



            return Json(aas, JsonRequestBehavior.AllowGet);
        }



        public void CargarValores(int fila, IList<aa> aas, int i)
        {
            aa person = new aa()
            {
                dim1 = fila,
                dim2 = 1,
                value = (decimal)((decimal)(5 + i) / 100)
            };

            aa person1 = new aa()
            {
                dim1 = fila,
                dim2 = 2,
                value = (decimal)((decimal)(15 + i) / 100)
            };

            aa person2 = new aa()
            {
                dim1 = fila,
                dim2 = 3,
                value = (decimal)((decimal)(20 + i) / 100)
            };

            aa person3 = new aa()
            {
                dim1 = fila,
                dim2 = 4,
                value = (decimal)((decimal)(30 + i) / 100)
            };

            aa person4 = new aa()
            {
                dim1 = fila,
                dim2 = 5,
                value = (decimal)((decimal)(40 + i) / 100)
            };

            aa person5 = new aa()
            {
                dim1 = fila,
                dim2 = 6,
                value = (decimal)((decimal)(50 + i) / 100)
            };

            aa person6 = new aa()
            {
                dim1 = fila,
                dim2 = 7,
                value = (decimal)((decimal)(60 + i) / 100)
            };

            aa person7 = new aa()
            {
                dim1 = fila,
                dim2 = 8,
                value = (decimal)((decimal)(70 + i) / 100)
            };

            aa person8 = new aa()
            {
                dim1 = fila,
                dim2 = 9,
                value = (decimal)((decimal)(80 + i) / 100)
            };

            aa person9 = new aa()
            {
                dim1 = fila,
                dim2 = 10,
                value = (decimal)((decimal)(85 + i) / 100)
            };

            aa person10 = new aa()
            {
                dim1 = fila,
                dim2 = 11,
                value = (decimal)((decimal)(90 + i) / 100)
            };

            aa person11 = new aa()
            {
                dim1 = fila,
                dim2 = 12,
                value = (decimal)((decimal)(95 + i) / 100)
            };

            aas.Add(person);
            aas.Add(person1);
            aas.Add(person2);
            aas.Add(person3);
            aas.Add(person4);
            aas.Add(person5);
            aas.Add(person6);
            aas.Add(person7);
            aas.Add(person8);
            aas.Add(person9);
            aas.Add(person10);
            aas.Add(person11);
        }
    }
    public class aa
    {
        public int dim1 { get; set; }
        public int dim2 { get; set; }
        public decimal value { get; set; }
    }
}