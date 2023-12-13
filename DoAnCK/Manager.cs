using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCK
{
    public class Manager : Person
    {
        public override string print_detail() 
        {
            return "Manager's name: " + this.Name + "\nManager's contact information: " + this.Contact_inf;
        }

        public string manage_inventory() 
        {
            DateTime date = DateTime.Now;
            return $"Inventory on {date.ToString("dd/MM/yyyy")}";
        }

        public string view_sales_report() 
        {
            DateTime date = DateTime.Now;
            return $"Sales report on {date.ToString("dd/MM/yyyy")}, look at the table below!";
        }

        public Manager()
        {
            
        }

        public Manager(string name, string contact_inf)
        {
            this.Name = name;
            this.Contact_inf = contact_inf;
        }
    }
}