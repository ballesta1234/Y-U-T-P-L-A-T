﻿using System.Web.Mvc;
using YUTPLAT.Models;

namespace YUTPLAT.Controllers
{
    public class ObjetivoController : Controller
    {
        public ActionResult Buscar()
        {
            ObjetivoViewModel model = new ObjetivoViewModel();
            model.Titulo = "Objetivos";

            ViewBag.Titulo = model.Titulo;

            return View(model);
        }
    }
}