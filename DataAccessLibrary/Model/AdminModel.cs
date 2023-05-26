using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Model
{
    public class AdminModel
    {
        public string? User_id { get; set; }
        public string? Created_at { get; set; }
        public string? User_name { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public string? Phone_no { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }

        public AdminModel() { }
    }
}
