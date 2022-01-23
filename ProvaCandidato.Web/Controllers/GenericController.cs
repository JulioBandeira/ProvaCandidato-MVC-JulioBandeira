using ProvaCandidato.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public abstract class  GenericBaseController<T> : Controller where T : class
    {

        public abstract ActionResult Index();

        [HttpGet()]
        public abstract ActionResult Criar();

        [HttpPost()]
        public abstract ActionResult Criar(T entidade);

        [HttpGet()]
        public abstract ActionResult Editar(int id);

        [HttpPost()]
        public abstract ActionResult Editar(int id, T entidade);

        [HttpGet()]
        public abstract ActionResult Excluir(int id);

        [HttpGet()]
        public abstract ActionResult Visualisar(int id);
        
    }
}
