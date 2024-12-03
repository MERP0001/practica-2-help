using System;
using System.Collections.Generic;
using System.Text;

namespace RepairMan.DataClasses.Common
{
    public enum IdentityDocumentType
    {
        Personal,
        Fiscal
    }

    public class IdentityDocument
    {
        public Guid IdentityDocumentId { get; set; }
        public IdentityDocumentType Type { get; set; }
        public string Reference { get; set; }
    }
}
