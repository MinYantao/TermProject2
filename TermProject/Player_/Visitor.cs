﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 游客身份
    /// </summary>
    public class Visitor:Identity
    {
        private string name;
        private Chessman chessman;
        public Visitor()
        {
            name = "Visitor";
        }
        public override string getname() { return name; }
        public override Piece play()
        {
            return null;
        }
    }
}
