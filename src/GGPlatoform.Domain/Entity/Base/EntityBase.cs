using GGPlatform.Common.SnowflakeToTwitter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GGPlatoform.Domain.Entity.Base
{
    public class EntityBase
    {
        private long _id;
        public long ID
        {
            get => _id;
            set
            {
                if (_id == 0)
                    _id = Snowflake.Instance().GetId();
                else
                    _id = value;
            }
        }
      //  public long ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

    }
}
