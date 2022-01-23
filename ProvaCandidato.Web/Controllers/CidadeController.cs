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

namespace ProvaCandidato.Controllers
{
    public class CidadesController : GenericBaseController<Cidade>
    {
        private ContextoPrincipal db = new ContextoPrincipal();


        public override ActionResult Criar()
        {
            ViewBag.CidadeId = db.Cidades.ToList();

            return View();
        }

        public override ActionResult Criar(Cidade entidade)
        {

            if (ModelState.IsValid)
            {
                db.Cidades.Add(entidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entidade);
        }

      

        public override ActionResult Editar(int id)
        {

            if (id == 0)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cidade cidade = db.Cidades.Find(id);

            if (cidade == null)
                return HttpNotFound();

            return View(cidade);
        }

        public override ActionResult Editar(int id, Cidade entidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entidade);
        }

        public override ActionResult Excluir(int id)
        {
            if (id == 0)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cidade cidade = db.Cidades.Find(id);

            if (cidade == null)

                return HttpNotFound();

            return View(cidade);
        }

        public override ActionResult Index()
        {
            var cidades = db.Cidades.ToList();

            return View(cidades);
        }

        public override ActionResult Visualisar(int id)
        {
            if (id == 0)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cidade cidade = db.Cidades.Find(id);

            if (cidade == null)

                return HttpNotFound();

            return View(cidade);
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
