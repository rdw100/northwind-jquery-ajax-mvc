using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NorthwindJqueryAjaxMvc.Models
{
    public partial class Shipper
    {
        [Key]
        public int ShipperId { get; set; }

        [Display(Name = "Company")]
        [MaxLength(40, ErrorMessage = "Maximum 40 characters only.")]
        [Required(ErrorMessage = "This field is required.")]
        public string CompanyName { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(40, ErrorMessage = "Maximum 24 characters only.")]
        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^([\(]{1}[0-9]{3}[\)]{1}[ ]{1}[0-9]{3}[\-]{1}[0-9]{4})$", ErrorMessage = "Invalid phone number.")]                             
        public string Phone { get; set; }
    }
}
