﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_2_4
{
    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Author { get; set; }  

        public string Genre { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
 