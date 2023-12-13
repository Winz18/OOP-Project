using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCK
{
    public class Coffee
    {
        private string name;
        private float price;
      
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }

        public Coffee() { }

        public Coffee(string name, float price)
        {
            this.name = name;
            this.price = price;
        }
    }
}