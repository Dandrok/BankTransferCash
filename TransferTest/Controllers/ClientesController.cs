using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransferTest.Helper;
using TransferTest.Models;

namespace TransferTest.Controllers
{
    public class ClientesController : Controller
    {
        private Context db = new Context();


        //CONTROLE EM CASCATA
        public JsonResult GetConta(int Cliente_Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var contacasc = db.Contas.Where(m => m.Cliente_Id == Cliente_Id);
            return Json(contacasc);
        }

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cliente_Id,Nome,Telefone,Address,Idade,Sexo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cliente_Id,Nome,Telefone,Address,Idade,Sexo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET TRANSFER
        public ActionResult Transfer(int? id)
        {
            var viewModel = new ViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conta conta = db.Contas.Find(id);
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nome = new SelectList(ComboHelper.GetClientes(), "Cliente_Id", "Nome", conta.Cliente_Id);
            ViewBag.Conta = new SelectList(ComboHelper.GetConta(), "Cliente_Id", "NConta", conta.Cliente_Id);

            return View(viewModel);
        }

        //POST TRANSFER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfer( Clientes clientes, Conta contas)
        {
            var viewModel = new ViewModel();
            if (ModelState.IsValid)
            {
                db.Entry(viewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nome = new SelectList(ComboHelper.GetClientes(), "Cliente_Id", "Nome", clientes.Cliente_Id);
            ViewBag.Conta = new SelectList(ComboHelper.GetConta(), "Cliente_Id", "NConta", clientes.Cliente_Id);

            return View(viewModel);
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
