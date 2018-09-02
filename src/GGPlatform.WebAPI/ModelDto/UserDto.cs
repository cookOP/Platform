using GGPlatform.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.ModelDto
{
    public class UserDto
    {
        public long ID { get; set; }
        public string UserName { get; set; }        
        public int Age { get; set; }
       // public Gender Genders { get; set; }           
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
