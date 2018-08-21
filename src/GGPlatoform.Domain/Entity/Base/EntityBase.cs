using GGPlatform.Common.SnowflakeToTwitter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GGPlatoform.Domain.Entity.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            ID = Snowflake.Instance().GetId();
        }
        public long ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

    }
}
