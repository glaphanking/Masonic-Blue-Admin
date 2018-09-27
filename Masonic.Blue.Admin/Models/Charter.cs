using System;
using System.Collections.Generic;

namespace Masonic.Blue.Models
{
    public class Charter : BaseModel
    {
        public int LodgeTypeId { get; set; }
        public virtual LodgeType LodgeType { get; set; }

        public int BodyTypeId { get; set; }
        public virtual BodyType BodyType { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public List<Contact> ContactInformation { get; set; }
    }
}