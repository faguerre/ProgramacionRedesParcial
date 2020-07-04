﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IEMEDEBE.AdminWebService.Models
{
    public class LoginModel
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}