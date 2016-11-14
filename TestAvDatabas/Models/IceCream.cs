using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAvDatabas.Models
{
    public class IceCream
    {
        public int IceCreamId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}