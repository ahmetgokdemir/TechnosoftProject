﻿using Project.ENTITIES.Enums;

namespace Project.ENTITIES.CoreInterfaces
{
    public abstract class EntityBase : IEntity
    {
        public int ID { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? DeletedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DataStatus? DataStatus { get; set; }

        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            DataStatus = Enums.DataStatus.Inserted;
        }
    }
}