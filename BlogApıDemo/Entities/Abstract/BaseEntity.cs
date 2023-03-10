using System;

namespace BlogApıDemo.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
