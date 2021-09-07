using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Classes
{
    public class ContactClass
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public Boolean Status { get; set; }

    }
}
