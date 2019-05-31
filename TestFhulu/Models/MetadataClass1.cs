using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestFhulu.Models
{
    [MetadataType(typeof(Usermetadata))]
    public partial class User
    {

        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        [Remote("IsUsernameAvailable", "Manage", ErrorMessage = "Invalid username")]
        public string username { get; set; }


        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "password Don't Match")]
        [Display(Name = "Retype password")]
        public string RPassword { get; set; }

    }



    public partial class Usermetadata
    {
        [Required(ErrorMessage = "can no be empty" , AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "can no be empty", AllowEmptyStrings = false)]
        [Display(Name = "District")]
        public Nullable<int> DistrictID { get; set; }
    }


    [MetadataType(typeof(LoginMetadata))]
    public partial class Login
    {
    }

    public partial class LoginMetadata
    {
       
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}