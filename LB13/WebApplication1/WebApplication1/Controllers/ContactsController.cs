using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactsController : Controller
    {
        private static List<Contact> contacts = new List<Contact>();

        public IActionResult Index()
        {
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = contacts.Count + 1;
                contacts.Add(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

    }
}
