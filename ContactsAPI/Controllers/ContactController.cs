using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        // GET: ContactController
        BL.ContactBL ContactBAL = new BL.ContactBL();
        public ActionResult Index()
        {
            return Ok(true);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var o = JsonConvert.SerializeObject(ContactBAL.getContacts());
            return Ok(o);
        }

        // POST: ContactController/Create
        [HttpPost]
        [Route("[action]")]
        public ActionResult Create(ContactsAPI.Classes.ContactClass newContact)
        {
            try
            {
                bool strResult = false;
                strResult = ContactBAL.AddNewContact(newContact);
                return Ok(strResult);
            }
            catch
            {
                return Ok(false);
            }
        }

       
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(int Id)
        {
            try
            {
                bool strResult = false;
                strResult = ContactBAL.DeleteContact(Id);
                return Ok(strResult);
            }
            catch(Exception ex)
            {
              return  Ok(false);
            }
        }
    }
}
