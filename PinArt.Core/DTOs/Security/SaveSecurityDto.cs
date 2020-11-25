using PinArt.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinArt.Core.DTOs.Security
{
    public class SaveSecurityDto
    {
        public string User { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleType? Role { get; set; }
    }
}
