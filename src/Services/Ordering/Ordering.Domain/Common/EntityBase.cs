using System;

namespace Ordering.Domain.Common
{
    public class EntityBase
    {
        public int Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }

    }
}