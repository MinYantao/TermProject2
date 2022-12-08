using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class AI:Role
    {
        private string name;
        public AI()
        {
            name= "AI";
        }
        public string getname() { return name; }
    }
}
