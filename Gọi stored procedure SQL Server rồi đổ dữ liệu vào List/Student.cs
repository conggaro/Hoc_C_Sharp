using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }


        public override string ToString()
        {
            return $"[{Id}, {Name}, {Email}, {Mobile}]";
        }
    }
}
