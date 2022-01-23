using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teste/Details/5
        public ActionResult Visualisar(int id)
        {
            return View();
        }

        // GET: Teste/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Teste/Create
        [HttpPost]
        public ActionResult Criar(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teste/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Teste/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teste/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teste/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
