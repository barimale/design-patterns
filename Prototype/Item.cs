using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Item
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Item Clone()
        {
            return new Item
            {
                Name = this.Name,
                Power = this.Power
            };
        }
    }

}
