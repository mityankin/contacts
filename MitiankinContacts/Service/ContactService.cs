using MitiankinContacts.Domain.EF;
using MitiankinContacts.Domain.Entity;
using MitiankinContacts.Models;
using MitiankinContacts.Models.GoogleJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MitiankinContacts.Service
{
    public class ContactService
    {

        public static List<ContactModelView> GetAllContact()
        {
            // Get all person from database  
            List<Person> personList = null;
            List<ContactModelView> contactsViewList = new List<ContactModelView>();
            using (DataContext db = new DataContext())
            {
                personList = db.ContactPerson.ToList();
                // Convert Person to ContactModelView
                if (personList != null)
                {
                    foreach (Person person in personList)
                    {
                        List<NumberModelView> numbersViewList = new List<NumberModelView>();
                        if (person.PhoneNumbers != null)
                        {
                            foreach (Phone phone in person.PhoneNumbers)
                            {
                                numbersViewList.Add(new NumberModelView(phone.Id, phone.PhoneNumber, phone.Type.Id, phone.Type.TypeName));
                            }
                            contactsViewList.Add(new ContactModelView(person.Id, person.FirstName, person.LastName, person.Address, numbersViewList));
                        }
                    }
                }

            }
            return contactsViewList;
        }

        public static ContactModelView GetContactViewById(int id)
        {
            // Get person from database by id
            Person person = null;
            ContactModelView contactView = new ContactModelView();
            using (DataContext db = new DataContext())
            {
                person = db.ContactPerson.Find(id);
                // Convert Person to ContactModelView
                if (person != null)
                {
                    contactView.PersonId = person.Id;
                    contactView.FirstName = person.FirstName;
                    contactView.LastName = person.LastName;
                    contactView.Address = person.Address;
                    contactView.Numbers = new List<NumberModelView>();
                    foreach (Phone phone in person.PhoneNumbers)
                    {
                        contactView.Numbers.Add(new NumberModelView(phone.Id, phone.PhoneNumber, phone.Type.Id, phone.Type.TypeName));
                    }
                }
            }
            return contactView;
        }


        public static ContactModelView SaveNewContactToDatabase(ContactModelView contactView)
        {
            if (contactView == null)
            {
                // что лучше делать в таком случае (если вдруг такое случится)
                return new ContactModelView();
            }
            Person personSavedInDataBase = null;
            using (DataContext db = new DataContext())
            {
                Person person = new Person(); ;
                person.FirstName = contactView.FirstName;
                person.LastName = contactView.LastName;
                person.Address = contactView.Address;
                if (contactView.Numbers != null)
                {
                    foreach (NumberModelView number in contactView.Numbers)
                    {
                        //надо вытащить существующие номера на этом контакте и сравнить
                        PhoneType type = new PhoneType();
                        type.TypeName = number.Type;
                        type.Id = number.IdType;
                        Phone phone = new Phone();
                        phone.Id = number.IdInDatabase;
                        phone.PhoneNumber = number.Phone;
                        phone.Type = type;
                        person.PhoneNumbers.Add(phone);
                    }
                }
                personSavedInDataBase = db.ContactPerson.Add(person);
                db.SaveChanges();
            }
            ContactModelView contactViewSavedInDataBase = new ContactModelView();
            if (personSavedInDataBase != null)
            {
                contactViewSavedInDataBase.PersonId = personSavedInDataBase.Id;
                contactViewSavedInDataBase.FirstName = personSavedInDataBase.FirstName;
                contactViewSavedInDataBase.LastName = personSavedInDataBase.LastName;
                contactViewSavedInDataBase.Address = personSavedInDataBase.Address;
                contactViewSavedInDataBase.Numbers = new List<NumberModelView>();
                foreach (Phone phone in personSavedInDataBase.PhoneNumbers)
                {
                    contactViewSavedInDataBase.Numbers.Add(new NumberModelView(phone.Id, phone.PhoneNumber, phone.Type.Id, phone.Type.TypeName));
                }
            }
            return contactViewSavedInDataBase;
        }

        public static ContactModelView SaveExistingContactToDatabase(ContactModelView contactView)
        {
            if (contactView == null)
            {
                // что лучше делать в таком случае (если вдруг такое случится)
                return new ContactModelView();
            }
            Person person = null;
            using (DataContext db = new DataContext())
            {
                person = db.ContactPerson.Find(contactView.PersonId);
                person.FirstName = contactView.FirstName;
                person.LastName = contactView.LastName;
                person.Address = contactView.Address;
                if (contactView.Numbers != null)
                {
                    foreach (NumberModelView number in contactView.Numbers)
                    {
                        //надо вытащить существующие номера на этом контакте и сравнить
                        PhoneType type = db.ContactPhoneType.Find(number.IdType);
                        Phone phone = null;
                        if (number.IdInDatabase == 0)
                        {
                            phone = db.ContactPhone.Add(new Phone());
                        }
                        else
                        {
                            phone = db.ContactPhone.Find(number.IdInDatabase);
                        }                                        

                        phone.PhoneNumber = number.Phone;
                        phone.Type = type;
                        phone.person = person;
                        if (number.Deleted)
                        {
                            db.ContactPhone.Remove(phone);
                        }
                        db.SaveChanges();
                    }
                }
                db.SaveChanges();
            }
            return GetContactViewById(contactView.PersonId);
        }

        public static List<SelectListItem> GetTypeList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            using (DataContext db = new DataContext())
            {
                List<PhoneType> phoneTypeDataBaseModel = db.ContactPhoneType.ToList();
                foreach (PhoneType phone in phoneTypeDataBaseModel)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = phone.TypeName,
                        Value = phone.Id.ToString()
                    });                  
                }
            }
            return listItems;
        }

        public static GeoModelView GetCoordinats(RootObject googlesJsonInObj)
        {
            GeoModelView geo = new GeoModelView();
            if (googlesJsonInObj!=null && googlesJsonInObj.Status!=null && googlesJsonInObj.Status.Equals("OK"))
            {
                if(googlesJsonInObj.Results!=null 
                    && googlesJsonInObj.Results.FirstOrDefault()!=null
                    && googlesJsonInObj.Results.FirstOrDefault().Geometry!=null 
                    && googlesJsonInObj.Results.FirstOrDefault().Geometry.Location != null)
                {
                    geo.Lat = googlesJsonInObj.Results.FirstOrDefault().Geometry.Location.Lat;
                    geo.Lng = googlesJsonInObj.Results.FirstOrDefault().Geometry.Location.Lng;
                }

                    
            }
            return geo;
        }
    }
}