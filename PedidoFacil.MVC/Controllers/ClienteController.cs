using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PedidoFacil.DAL;
using PedidoFacil.Entidades;
using PedidoFacil.DAL.Repositorios;

namespace PedidoFacil.MVC.Controllers
{
    public class ClienteController : Controller
    {
        //private PedidoFacilContexto db = new PedidoFacilContexto();
        private readonly ClienteRepositorio repCli = new ClienteRepositorio();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(repCli.GetAll().ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repCli.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            RepresentadaRepositorio repRepresentada = new RepresentadaRepositorio();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Representada r in repRepresentada.GetAll())
            {
                listItems.Add(new SelectListItem { Text = r.Nome, Value = r.ID.ToString() });
            }
            ViewBag.RepresentadaID = listItems; 

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string representadaId, [Bind(Include = "ID,Nome,NomeAbreviado,Documento,Endereco,Contato,IE,CodigoFabrica,TributaIpi")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                RepresentadaRepositorio repRepresentada = new RepresentadaRepositorio();
                Representada representada = repRepresentada.Find(Convert.ToInt32(representadaId));
                cliente.Representada = representada;
                repCli.Adicionar(cliente);
                repCli.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repCli.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,NomeAbreviado,Documento,Endereco,Contato,IE,CodigoFabrica,TributaIpi")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cliente).State = EntityState.Modified;
                repCli.Atualizar(cliente);
                repCli.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = repCli.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = repCli.Find(id);
            repCli.Excluir(c => c.ID == cliente.ID);
            repCli.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repCli.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
