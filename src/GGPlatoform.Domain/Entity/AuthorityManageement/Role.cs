using GGPlatoform.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatoform.Domain.Entity
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public string MenuPermissionID { get; set; }
        public byte IsDelete { get; set; }


    }
}
