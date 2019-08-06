using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatestikAspITPlannerKjeld.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Team { get; set; }

        public bool Aktiv { get; set; }
    }
}
