using System;
using System.Collections.Generic;

namespace Lesson7.Data.Models
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
