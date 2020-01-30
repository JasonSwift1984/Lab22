using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quanity { get; set; }
        public string Price { get; set; }
    }
}
