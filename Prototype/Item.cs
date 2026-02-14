using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Item: ICloneable
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public object Clone()
        {
            return new Item
            {
                Name = this.Name,
                Power = this.Power
            };
        }
    }

}
