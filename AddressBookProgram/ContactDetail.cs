using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBookProgram
{
    public class ContactDetail
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be min 3 characters and max 100")]
        [DataType(DataType.Text)]
        public string first_Name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be min 3 characters and max 100")]
        [DataType(DataType.Text)]
        public string last_Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.Text)]
        public string address { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [DataType(DataType.Text)]
        public string city { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [DataType(DataType.Text)]
        public string state { get; set; }

        [Required(ErrorMessage = "Pin Code is required")]
        [StringLength( 6, ErrorMessage = "Pin Code should be of only 6 numbers")]
        [DataType(DataType.PostalCode)]
        public string pincode { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("^[+]*[0-9]{2}[\\s][0-9]{10}")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNum { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[^\.][a-zA-Z_\-0-9]*[\.]*[a-zA-Z_\-0-9]+@[a-z0-9]+[\.][a-z]{2,4}([\.][a-z]{2,3})?$")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    }
}
