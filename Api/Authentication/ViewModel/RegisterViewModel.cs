using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.ViewModel
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string State { get; set; }
        public int? SolID { get; set; }
        public string Role { get; set; }
    }
}
