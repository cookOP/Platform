using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.ModelDto
{
    public class UserDto
    {
        //public string ID { get; set; }
        public string UserName { get; set; }        
        public int Age { get; set; }
        public int Sex { get; set; }           
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
