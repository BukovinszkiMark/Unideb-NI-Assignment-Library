﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Common.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}