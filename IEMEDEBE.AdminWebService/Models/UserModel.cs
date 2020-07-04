using IEMEDEBE.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IEMEDEBE.AdminWebService.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "NickName is required")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Birthday date is required and should be with the format  dd - MM - yyyy")]
        public string Birthday { get; set; }

        public User ToEntity()
        {
            return new User()
            {
                NickName = this.NickName,
                Mail = this.Email,
                FullName = this.Name,
                Birthday = DateTime.ParseExact(this.Birthday, "dd-MM-yyyy", null),
                Password = this.Password
            };
        }
    }
}