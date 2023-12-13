using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCK
{
    public abstract class Person
    {
        private string name; // name of person
        private string contact_inf; // contact information of person (phone number)

        public abstract string print_detail(); // print detail of person (name, contact_inf)

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Contact_inf
        {
            get => contact_inf;
            set => contact_inf = value;
        }
    }
}