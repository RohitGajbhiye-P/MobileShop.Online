using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Online.Models
{
    public class MobilesModels
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength = 2)]
        [Required(ErrorMessage ="Please enter name of your model")]
        public string MobileName { get; set; }

        [Required(ErrorMessage ="Please enter version of your model")]
        public string MobileVersion { get; set; }

        [StringLength(500,MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage ="please enter prize of a mobile")]
        public int? Price { get; set; }
        public string Color { get; set; }
        public int MyProperty { get; set; }

        [Required(ErrorMessage ="Please select required language")]
        public string Language { get; set; }
    }
}
