using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Skylight.Models.Enums;
namespace Skylight.Models {

    public class Marketer {
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int MarketerID { get; set; }

        [Required]
        public string MarketerName { get; set; }

        // [Index (IsUnique = true)]
        public string PhoneNumber { get; set; }

        // [Index (IsUnique = true)]
        public string Email { get; set; }
        public string Address { get; set; }
        public string AffilliateLink { get; set; }
        public ComType CommissionType { get; set; }
        public string CommissionValue { get; set; }
        public List<Company> Companies { get; set; }
    }
}