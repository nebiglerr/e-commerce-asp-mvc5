using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
  public  class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public bool IsAdmin { get; set; }

        public virtual List<User> User { get; set; }
        public Login()
        {
            User = new List<User>();
        }
    }
}
