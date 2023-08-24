using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get;set; }
        
        public string Type { get; set; }
        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}
