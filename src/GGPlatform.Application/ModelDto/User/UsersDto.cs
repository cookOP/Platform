using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Application.ModelDto
{
   public class UsersDto
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        // public Gender Genders { get; set; }           
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
