﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class AdminLogInDto : IEntity
    {
        public string AdminUserName { get; set; }

        public string AdminMail { get; set; }

        public string AdminPassword { get; set; }

        public string AdminRole { get; set; }
    }
}
