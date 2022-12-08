using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class Visitor:Role
    {
        private string name;
        public Visitor()
        {
            name = "Visitor";
        }
        public string getname() { return name; }
    }
}
