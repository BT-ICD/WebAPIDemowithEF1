using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemowithEF1.Entities
{
    public class Employee
    {
        public decimal ID { get; set; }
        public string Ename { get; set; }

        public string Designation { get; set; }
    }
}
