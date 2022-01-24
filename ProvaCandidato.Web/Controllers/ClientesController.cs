using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Helper;

namespace ProvaCandidato.Controllers
{
    public class ClientesController : GenericBaseController<Cliente>
    {
        private ContextoPrincipal db = new ContextoPrincipal();

        // GET: Cliente
        public override ActionResult Index(string txtSearch)
        {
            var clientes = db.Clientes.Include(c => c.Cidade);

            if (!string.IsNullOrEmpty(txtSearch))
                clientes = clientes.Where(x => x.Nome.Contains(txtSearch));

            return View(clientes.ToList());
        }

        // GET: Cliente/Details/5
        public override ActionResult Visualisar(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public override ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (cliente.DataNascimento > DateTime.Now)
                ModelState.AddModelError("DataNascimento", "A data de nascimento não pode ser maior que a data atual.");

            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();

                this.DisplaySuccessMessage("Cliente salvo com sucesso.");

                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public override ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        public override ActionResult Edit(int id, Cliente entidade)
        {

            if (ModelState.IsValid)
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", entidade.CidadeId);
            return View(entidade);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }



        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            this.DisplaySuccessMessage("Cliente excluído com sucesso.");
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

        public override ActionResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
