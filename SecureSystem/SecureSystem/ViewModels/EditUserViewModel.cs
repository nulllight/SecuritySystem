﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSystem.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NameOrg { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string Key{ get; set; }
    }
}
