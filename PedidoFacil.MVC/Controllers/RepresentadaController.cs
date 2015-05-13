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
    public class RepresentadaController : Controller
    {
        //private PedidoFacilContexto db = new PedidoFacilContexto();
        private readonly RepresentadaRepositorio repRepresentada = new RepresentadaRepositorio();

        // GET: Representada
        public ActionResult Index()
        {
            return View(repRepresentada.GetAll().ToList());
        }

        // GET: Representada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Representada representada = repRepresentada.Find(id);
            if (representada == null)
            {
                return HttpNotFound();
            }
            return View(representada);
        }

        // GET: Representada/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Representada/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,NomeAbreviado,Cnpj,Endereco,Contato")] Representada representada)
        {
            if (ModelState.IsValid)
            {
                repRepresentada.Adicionar(representada);
                repRepresentada.SalvarTodos();
                return RedirectToAction("Index");
            }

            return View(representada);
        }

        // GET: Representada/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Representada representada = repRepresentada.Find(id);
            if (representada == null)
            {
                return HttpNotFound();
            }
            return View(representada);
        }

        // POST: Representada/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,NomeAbreviado,Cnpj,Endereco,Contato")] Representada representada)
        {
            if (ModelState.IsValid)
            {
                repRepresentada.Atualizar(representada);
                repRepresentada.SalvarTodos();
                return RedirectToAction("Index");
            }
            return View(representada);
        }

        // GET: Representada/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Representada representada = repRepresentada.Find(id);
            if (representada == null)
            {
                return HttpNotFound();
            }
            return View(representada);
        }

        // POST: Representada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Representada representada = repRepresentada.Find(id);
            repRepresentada.Excluir(r => r.ID == representada.ID);
            repRepresentada.SalvarTodos();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repRepresentada.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
