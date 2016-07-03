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
    public class PasswordController : Controller
    {
        private PasswordData _password = new PasswordData();
        public ActionResult Index(int id)
        {
            ViewBag.PersonID = id;
            return View(Automapper.GetGeneric<Password,PasswordModelView>(_password.GetPasswordById(id)));
        }

        public ActionResult Create(int id)
        {
            return View(new PasswordModelView() {BusinessEntityID=id});
        }
        [HttpPost]
        public ActionResult Create(PasswordModelView objPassword)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    objPassword.ModifiedDate = DateTime.Now;
                    objPassword.PasswordSalt = Util.Util.getSalt().Substring(0,10);
                    objPassword.PasswordHash = Util.Util.CreatePasswordHash(objPassword.PasswordHash, objPassword.PasswordSalt);
                    _password.Add(Automapper.GetGenericDinamyc<PasswordModelView, Password>(objPassword));
                }

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return RedirectToAction("Index", new { id = objPassword.BusinessEntityID });
        }
        public ActionResult Edit(int id)
        {
            return View(Automapper.GetGeneric<Password, PasswordModelView>(_password.GetPasswordById(id)));
        }
        [HttpPost]
        public ActionResult Edit(PasswordModelView objPassword)
        {
            string error = "";
            try
            {
                if (ModelState.IsValid)
                {
                    objPassword.ModifiedDate = DateTime.Now;
                    objPassword.PasswordSalt = Util.Util.getSalt().Substring(0,10);
                    objPassword.PasswordHash = Util.Util.CreatePasswordHash(objPassword.PasswordHash, objPassword.PasswordSalt);
                    _password.Update(Automapper.GetGenericDinamyc<PasswordModelView, Password>(objPassword));
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return View(objPassword);
        }

        public ActionResult Delete(int id)
        {
            _password.Delete(_password.GetPasswordById(id));
            return RedirectToAction("Index", new { id = id });
        }
    }
}