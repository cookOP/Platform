using GGPlatform.Common.Enum;
using GGPlatoform.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatoform.Domain.Entity
{
    public class Menu : EntityBase
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Iocn { get; set; }
        public long ParentID { get; set; }        
        public byte IsDelete { get; set; }
        public byte IsShow { get; set; }
        public Target Targets { get; set; }

      
    }
}
