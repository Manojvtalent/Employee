using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Models
{
    [Table("Employee")]
    public class employee
    {
        [Key]
        public int EmployeeNumber { get; set; }
        [Required(ErrorMessage ="please enter Last name...!")]
        [StringLength(10,ErrorMessage ="please enter only 10 charector...!")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="please enter charecter only...!")]
        public string Lastame { get; set; }
        [Required(ErrorMessage = "please enter First name...!")]
        [StringLength(10, ErrorMessage = "please enter only 10 charector...!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "please select gender...!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "please enter dateofBirth...!")]
        public int DateofBirth { get; set; }

        [Required(ErrorMessage = "please enter Emailaddress...!")]
       //[RegularExpression(@"^([\w.\-]+)@([\w\-]+)((\.(w){2,3})+)$", ErrorMessage = "please enter proper email format...!")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "please enter password...!")]
     
        public string password { get; set; }
        [Required(ErrorMessage = "please enter phoneNumber...!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "please enter digits only...!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "please enter Address...!")]

        public string Address { get; set; }






    }
}
