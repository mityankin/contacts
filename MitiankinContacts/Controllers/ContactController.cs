using MitiankinContacts.Domain.Entity;
using MitiankinContacts.Models;
using MitiankinContacts.Models.GoogleJson;
using MitiankinContacts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MitiankinContacts.Controllers
{
    public class ContactController : Controller
    {

        #region View Action Methods      
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            List<ContactModelView> listContacts = ContactService.GetAllContact();            
            return View("Index", listContacts);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int id)
        {                              
            ContactModelView contactlView = ContactService.GetContactViewById(id);
            ViewData["GEO"] = ContactService.GetCoordinats(GoogleAddressAPI.GetGeo(contactlView.Address));           
            return View("Details", contactlView);
        }
        #endregion

        #region Create Action Methods
        [HttpGet]
        public ActionResult Create()
        {
            ContactModelView model = new ContactModelView();
            return View("Create", model);
        }       

        [HttpPost]
        public ActionResult Create(ContactModelView model)
        {
            ContactModelView contactlView = ContactService.SaveNewContactToDatabase(model);
            return RedirectToAction("Details", new { id = contactlView.PersonId });
        }
        #endregion

        #region Edit Action Methods
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewData["TypeList"] = ContactService.GetTypeList();
            ContactModelView contactlView = ContactService.GetContactViewById(id);
            return View("Edit", contactlView);
        }

        [HttpPost]
        public ActionResult Edit(ContactModelView model)
        {
            ContactModelView contactlView = ContactService.SaveExistingContactToDatabase(model);
            return RedirectToAction("Details", new { id = contactlView.PersonId });
        }
        #endregion

        public ActionResult CreateNewPhone(int id)
        {
            ViewData["TypeList"] = ContactService.GetTypeList();
            return PartialView("~/Views/Shared/EditorTemplates/AddNumber.cshtml", id);
        }



        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

 







    }
}
