using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemowithEF1.Entities
{
    [Table("Student")]
    public class Student
    {
        public virtual decimal ID { get; set; }
        public virtual string SName { get; set; }
        public virtual string Area { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual string Phone { get; set; }
    }
}
