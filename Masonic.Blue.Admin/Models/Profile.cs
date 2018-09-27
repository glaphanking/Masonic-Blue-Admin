using System;
using System.ComponentModel.DataAnnotations;
using Masonic.Blue.Admin.Models;

namespace Masonic.Blue.Models
{
    public class Profile : BaseModel
    {
        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid CharterId { get;set; }
        public virtual Charter Charter { get; set; }

        public string MasonicBodies { get; set; }
        public bool Officer { get; set; }
        public bool Past { get; set; }
        public string OfficerTitle { get; set; }
        public string MasonicTitle { get; set; }
    }
}