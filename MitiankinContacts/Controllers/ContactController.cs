using MitiankinContacts.Domain.Entity;
using MitiankinContacts.Models;
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
       

       
        [HttpGet]
        public ActionResult Index()
        {
            List<ContactModelView> listContacts = ContactService.GetAllContact();            
            return View("Index", listContacts);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ContactModelView contactlView = ContactService.GetContactViewById(id);         
            return View("Details", contactlView);
        }

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
            return RedirectToAction("Details", contactlView);
        }  

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ContactModelView contactlView = ContactService.GetContactViewById(id);
            return View("Edit", contactlView);
        }

        [HttpPost]
        public ActionResult Edit(ContactModelView model)
        {
            ContactModelView contactlView = ContactService.SaveExistingContactToDatabase(model);
            return RedirectToAction("Details", new { id = contactlView.PersonId });
        }

        public ActionResult CreateNewPhone()
        {
            var numberModelView = new NumberModelView();
            return PartialView("~/Views/Shared/EditorTemplates/NumberModelView.cshtml", numberModelView);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }






    }
}
