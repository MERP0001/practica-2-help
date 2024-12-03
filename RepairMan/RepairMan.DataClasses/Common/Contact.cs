using System;

namespace RepairMan.DataClasses.Common
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
