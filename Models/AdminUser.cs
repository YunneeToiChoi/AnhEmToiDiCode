﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirBNB_Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AdminUser
    {
        [Display(Name = "Mã User")]
        [Required(ErrorMessage = "ID not Empty.....")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name not Empty.....")]
        [Display(Name = ("Tên User"))]
        public string Name_User { get; set; }

        [Required(ErrorMessage = "Email not Empty....")]
        [Display(Name = ("Email User"))]
        public string Email_User { get; set; }
        [DisplayName("Nhập Mật Khẩu")]
        [Required(ErrorMessage = "Pass not Empty....")]
        [DataType(DataType.Password)]
        public string Password_User { get; set; }

        [NotMapped]
        //[Compare("PasswordUser")]
        [Required(ErrorMessage = "PasswordConfirm not Empty....")]
        [DisplayName("Nhập Lại Mật Khẩu")]
        public string ConfirmPassword {  get; set; }
        [NotMapped]
        public string ErrorLogin {  get; set; }
    }
}
