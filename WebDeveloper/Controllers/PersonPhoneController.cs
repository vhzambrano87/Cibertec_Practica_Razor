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
    public class PersonPhoneController : Controller
    {
        private PersonPhoneData _personPhone = new PersonPhoneData();
        private PhoneNumberTypeData _phoneNumberType = new PhoneNumberTypeData();
        public ActionResult Index(int id)
        {
            List<PersonPhoneModelView> objListPersonPhoneModelView = new List<PersonPhoneModelView>();
            PersonPhoneModelView objPersonPhoneModelViewResult = new PersonPhoneModelView();
            List<PersonPhoneModelView> objListPersonPhoneModelViewResult = new List<PersonPhoneModelView>();
            objListPersonPhoneModelView = Automapper.GetGeneric<List<PersonPhone>, List<PersonPhoneModelView>>(_personPhone.GetPersonPhoneByPersonId(id));
            foreach (var item in objListPersonPhoneModelView)
            {
                objPersonPhoneModelViewResult = item;
                objPersonPhoneModelViewResult.PhoneNumberTypeDesc = _phoneNumberType.GetPhoneNumberTypeById(item.PhoneNumberTypeID).Name;
                objListPersonPhoneModelViewResult.Add(objPersonPhoneModelViewResult);
            }
            ViewBag.PersonID = id;
            return View(objListPersonPhoneModelViewResult);
        }

        public ActionResult Create(int id)
        {
            LoadDropDown(0);
            return View(new PersonPhoneModelView() {BusinessEntityID=id });
        }

        [HttpPost]
        public ActionResult Create(PersonPhoneModelView objPersonPhone)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    objPersonPhone.ModifiedDate = DateTime.Now;
                    _personPhone.Add(Automapper.GetGenericDinamyc<PersonPhoneModelView,PersonPhone>(objPersonPhone));
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction("Index", new { id = objPersonPhone.BusinessEntityID });
        }

        public ActionResult Edit(string id)
        {
            string[] ids = id.Split('X');            
            LoadDropDown(Convert.ToInt32(ids[0]));
            return View(Automapper.GetGeneric<PersonPhone, PersonPhoneModelView>(_personPhone.GetPersonPhoneById(Convert.ToInt32(ids[0]), ids[1], Convert.ToInt32(ids[2]))));
        }

        [HttpPost]
        public ActionResult Edit(PersonPhoneModelView objPersonPhone)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    objPersonPhone.ModifiedDate = DateTime.Now;
                    _personPhone.Update(Automapper.GetGenericDinamyc<PersonPhoneModelView, PersonPhone>(objPersonPhone));
                    LoadDropDown(objPersonPhone.PhoneNumberTypeID);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            string[] ids = id.Split('X');
            PersonPhone objPersonPhone = new PersonPhone();
            objPersonPhone = _personPhone.GetPersonPhoneById(Convert.ToInt32(ids[2]), ids[1], Convert.ToInt32(ids[0]));
            _personPhone.Delete(objPersonPhone);
            return RedirectToAction("Index", new { id = Convert.ToInt32(ids[0]) });
        }
        public void LoadDropDown(int PersonPhoneTypeID)
        {
            try
            {
                ViewBag.ListPhoneNumberType = new SelectList(_phoneNumberType.GetList(), "PhoneNumberTypeID", "Name", PersonPhoneTypeID);
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}