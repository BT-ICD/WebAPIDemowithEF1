using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemowithEF1.Entities
{
    public class StudentDTO
    {
        public virtual decimal ID { get; set; }
        public virtual string SName { get; set; }
    }
}
