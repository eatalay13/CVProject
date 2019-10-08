using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Models
{
    public class BaseModel
    {
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
