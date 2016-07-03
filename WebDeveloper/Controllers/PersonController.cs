using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;
using WebDeveloper.Model.DTO;

namespace WebDeveloper.Controllers
{   
    public class PersonController : Controller
    {
        private PersonData _person = new PersonData();
        private BusinessEntityData _businessEntity = new BusinessEntityData();
        public ActionResult Index()
        {
            List<Person> persons = new List<Person>();
            persons = _person.GetList();
            return View(Automapper.GetGeneric<List<Person>, List<PersonModelView>>(persons));
        }

        public ActionResult Detail(int id)
        {
            return View(Automapper.GetGeneric<Person,PersonModelView>(_person.GetPersonById(id)));
        }


    }
}