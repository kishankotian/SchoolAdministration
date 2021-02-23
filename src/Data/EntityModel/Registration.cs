using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModel
{
    public class Registration : BaseEntity
    {
        public string StudentEmail { get; set; }
        public string RegisteredBy { get; set; }

    }
}
