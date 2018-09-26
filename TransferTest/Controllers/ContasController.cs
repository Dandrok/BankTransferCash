using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransferTest.Models;

namespace TransferTest.Controllers
{
    public class ContasController : Controller
    {
        private Context db = new Context();

        // GET: Contas
        public ActionResult Index()
        {
            var contas = db.Contas.Include(c => c.Clientes);
            return View(contas.ToList());
        }

        // GET: Contas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Contas.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // GET: Contas/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nome");
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Conta_Id,NConta,Saldo,Cliente_Id")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                db.Contas.Add(conta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nome", conta.Cliente_Id);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Contas.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nome", conta.Cliente_Id);
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Conta_Id,NConta,Saldo,Cliente_Id")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_Id = new SelectList(db.Clientes, "Cliente_Id", "Nome", conta.Cliente_Id);
            return View(conta);
        }

        // GET: Contas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Contas.Find(id);
            if (conta == null)
            {
                return HttpNotFound();
            }
            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conta conta = db.Contas.Find(id);
            db.Contas.Remove(conta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
