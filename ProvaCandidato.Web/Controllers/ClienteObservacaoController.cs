using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.ViewModel;
using ProvaCandidato.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class ClienteObservacaoController : Controller
    {
        private ContextoPrincipal db = new ContextoPrincipal();

        [HttpGet()]
        [Route("/observacao/add")]
        public ActionResult AddObsUser(int id)
        {
            return View("_AddObsUser", new ViewModelClienteObs { Codigo_Clilente = id });
        }

        [HttpPost()]
        [Route("/observacao/add")]
        public ActionResult AddObsUser(ViewModelClienteObs vmObs)
        {
            if (ModelState.IsValid)
            {

                

                var clienteObs = new ClienteObservacao
                {
                    Texto = vmObs.Observacao,
                    ClienteId = vmObs.Codigo_Clilente
                };

                db.ClienteObservacao.Add(clienteObs);
                db.SaveChanges();

                var lista = db.ClienteObservacao.Where(x => x.ClienteId == vmObs.Codigo_Clilente)
                              .Select(x=> new {

                                  x.Codigo,
                                  x.Texto,
                                 
                               }).ToList();

                this.DisplaySuccessMessage("Observação adicionada com sucesso");

                return Json(lista, JsonRequestBehavior.AllowGet);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Algo aconteceu de errado.");
        }
    }
}
