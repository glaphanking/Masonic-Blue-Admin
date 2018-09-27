using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Masonic.Blue.Admin.ViewModels
{
    public class CharterListVm
    {
        public int Id { get; set; }
        public string LodgeType { get;set; }
        public string BodyType { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get;set; }
    }
}