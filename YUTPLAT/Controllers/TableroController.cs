using System.Collections.Generic;
using System.Web.Mvc;
using YUTPLAT.ViewModel;

namespace YUTPLAT.Controllers
{
    [Authorize]
    public class TableroController : Controller
    {
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

            IList<aa> aas = new List<aa>();


            aa person = new aa()
            {
                dim1 = 1,
                dim2 = 1,
                value = 15
            };

            aa person1 = new aa()
            {
                dim1 = 1,
                dim2 = 2,
                value = 1
            };

            aa person2 = new aa()
            {
                dim1 = 1,
                dim2 = 3,
                value = 5
            };

            aa person3 = new aa()
            {
                dim1 = 1,
                dim2 = 4,
                value = 15
            };

            aa person4 = new aa()
            {
                dim1 = 1,
                dim2 = 5,
                value = 1
            };

            aa person5 = new aa()
            {
                dim1 = 1,
                dim2 = 6,
                value = 5
            };

            aa person6 = new aa()
            {
                dim1 = 1,
                dim2 = 7,
                value = 15
            };

            aa person7 = new aa()
            {
                dim1 = 1,
                dim2 = 8,
                value = 1
            };

            aa person8 = new aa()
            {
                dim1 = 1,
                dim2 = 9,
                value = 5
            };

            aa person9 = new aa()
            {
                dim1 = 1,
                dim2 = 10,
                value = 15
            };

            aa person10 = new aa()
            {
                dim1 = 1,
                dim2 = 11,
                value = 1
            };

            aa person11 = new aa()
            {
                dim1 = 1,
                dim2 = 12,
                value = 5
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

            return Json(aas, JsonRequestBehavior.AllowGet);
        }
        
    }

    public class aa
    {
        public int dim1 { get; set; }
        public int dim2 { get; set; }
        public int value { get; set; }
    }
}