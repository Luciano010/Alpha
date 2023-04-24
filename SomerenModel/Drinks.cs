using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drinks
    {
        public int drinkId { get; set; }     // database id
        public string drinkName { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public bool isAlcoholic { get; set; }
    }
}
