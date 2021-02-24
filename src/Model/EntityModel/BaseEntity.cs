using System;

namespace Model.EntityModel
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
