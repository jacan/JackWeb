using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JackWeb.Data.Entities.Tech;
using JackWeb.Data;

namespace JackWeb.Controllers
{
    public class TechChoiceController : Controller
    {
        protected readonly IRepository<TechChoiceReason> _repository;

        public TechChoiceController(IRepository<TechChoiceReason> repository)
        {
            _repository = repository;
        }

        //
        // GET: /TechChoice/

        public ActionResult Index()
        {
            var techChoices = _repository.GetAll();
            
            return View(techChoices.OrderBy(x => x.Created));
        }
    }
}
