using GGPlatoform.Domain.Entity.Base;
using GGPlatform.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatoform.Domain.Entity.User
{
    public class Users : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public Gender Genders { get; set; }
        public int IsEnabled { get; set; }
        public int LoginCount { get; set; }
        public int LookCount { get; set; }
        public DateTime LookTime { get; set; }

       
    }
}
