using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCK
{
    public class Barista : Person
    {
        public override string print_detail()
        {
            return "Barista's name: " + this.Name + "\nBarista's contact information: " + this.Contact_inf;
        }

        public Barista()
        {
           
        }

        public Barista(string name, string contact_inf)
        {
            this.Name = name;
            this.Contact_inf = contact_inf;
        }

        public string prepare_coffee() // return a string to show that coffee was prepared
        {
            return "Coffee was prepared !";
        }
    }
}