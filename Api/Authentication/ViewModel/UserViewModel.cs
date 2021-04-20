using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.ViewModel
{
    public class UserViewModel
    {

        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public string  State { get; set; }
        public int? SolID { get; set; }

    }
}
