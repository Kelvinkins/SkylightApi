using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Data.Models
{

    public class Country
    {
        public string CountryID { get; set; }
        public string Name { get; set; }

    }
    public class State
    {
        public string StateID { get; set; }
        public string Name { get; set; }
        public List<Provider> Providers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Dependant> Dependants { get; set; }

    }

    public class City
    {
        public string CityID { get; set; }
        public string Name { get; set; }
        public List<Provider> Providers { get; set; }

    }

    public class Region
    {
        public string RegionID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Dependant> Dependants { get; set; }


    }

}
