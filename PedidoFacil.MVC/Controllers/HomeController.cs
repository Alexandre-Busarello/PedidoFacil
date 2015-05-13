using PedidoFacil.DAL.Repositorios;
using PedidoFacil.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidoFacil.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListarRepresentadas()
        {
            RepresentadaRepositorio representadaRep = new RepresentadaRepositorio();
            ICollection<Representada> lista = representadaRep.GetAll().ToList<Representada>();

            return View("Representada", lista);
        }
    }
}