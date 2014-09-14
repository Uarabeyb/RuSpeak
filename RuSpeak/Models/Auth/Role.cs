using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RuSpeak.Models.Auth
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}