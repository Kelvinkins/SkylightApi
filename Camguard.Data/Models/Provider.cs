using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Skylight.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using  Newtonsoft.Json;
using Skylight.Data.Models;

namespace Skylight.Models
{

    public class Provider:BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string OldCode { get; set; }
        // [Index (IsUnique = true)]
        public string ProviderPhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Discontinued { get; set; }
        public PType ProviderType { get; set; }
        public string ContactPersion { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }

        // [Index (IsUnique = true)]
        public string Email { get; set; }

        public List<Employee> Employee { get; set; }
        public List<Dependant> Dependants { get; set; }
        public List<Capitation> Capitations { get; set; }

        [JsonIgnore] 
        public int? ProviderLevelID { get; set; }
        public ProviderLevel ProviderLevel { get; set; }

        public string TariffID { get; set; }
        public Tariff Tariff { get; set; }

        public string StateID { get; set; }
        public State State { get; set; }
        public string CityID { get; set; }
        public City City { get; set; }
        public SerType ProviderService { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Password { get; set; }
        public DateTime? SystemDateTime { get; set; }
        public DateTime? LastUpdated { get; set; }



    }
}