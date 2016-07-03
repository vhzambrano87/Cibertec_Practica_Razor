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
    public class EmailAddressController : Controller
    {
        private EmailAddressData _emailAddress = new EmailAddressData();
        public ActionResult Index(int id)
        {
            ViewBag.PersonID = id;

            List<EmailAddress> oListaEmailAddress = new List<EmailAddress>();
            oListaEmailAddress = _emailAddress.GetEmailAddressByPersonId(id);            
            return View(Automapper.GetGeneric<List<EmailAddress>,List<EmailAddressModelView>>(oListaEmailAddress));
        }
        public ActionResult Create(int id)
        {            
            return View(new EmailAddressModelView() { BusinessEntityID=id});
        }
        [HttpPost]
        public ActionResult Create(EmailAddressModelView objEmailAddress)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    objEmailAddress.ModifiedDate = DateTime.Now;
                    _emailAddress.Add(Automapper.GetGenericDinamyc<EmailAddressModelView, EmailAddress>(objEmailAddress));
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction("Index", new { id = objEmailAddress.BusinessEntityID});
        }

        public ActionResult Edit(int id)
        {
            return View(Automapper.GetGeneric<EmailAddress,EmailAddressModelView>(_emailAddress.GetEmailAddressById(id)));
        }

        [HttpPost]
        public ActionResult Edit(EmailAddressModelView objEmailAddress)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    objEmailAddress.ModifiedDate = DateTime.Now;
                    _emailAddress.Update(Automapper.GetGenericDinamyc<EmailAddressModelView, EmailAddress>(objEmailAddress));
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            return View(objEmailAddress);
        }

        public ActionResult Delete(int id)
        {
            EmailAddressModelView objEmailAddress = new EmailAddressModelView();
            string error = "";
            try
            {
                objEmailAddress = Automapper.GetGeneric<EmailAddress,EmailAddressModelView>(_emailAddress.GetEmailAddressById(id));
                _emailAddress.Delete(Automapper.GetGenericDinamyc<EmailAddressModelView, EmailAddress>(objEmailAddress));
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction("Index", new { id = objEmailAddress.BusinessEntityID });
        }
    }
}