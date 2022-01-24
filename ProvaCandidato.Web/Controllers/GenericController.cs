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

        public abstract ActionResult Index(string txtSearch);

        [HttpGet()]
        public abstract ActionResult Create();

        [HttpPost()]
        public abstract ActionResult Create(T entidade);

        [HttpGet()]
        public abstract ActionResult Edit(int id);

        [HttpPost()]
        public abstract ActionResult Edit(int id, T entidade);

        [HttpGet()]
        public abstract ActionResult Excluir(int id);

        [HttpGet()]
        public abstract ActionResult Visualisar(int id);
        
    }
}
