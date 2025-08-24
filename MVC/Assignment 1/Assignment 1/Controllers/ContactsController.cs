using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_1.Models;
using Assignment_1.Repository;

namespace Assignment_1.Controllers
{
    public class ContactsController : Controller
    {
        private ContactContext db = null;
        private IContactRepository _contactRepo = null;

        public ContactsController()
        {
            db = new ContactContext();
            _contactRepo = new ContactRepository();
        }

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            return View(await db.Contacts.ToListAsync());
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepo.CreateAsync(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _contactRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
