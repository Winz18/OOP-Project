using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAnCK
{
    public class Customer : Person
    {
        public Customer()
        {
            
        }
        public Customer (string name, string contact_inf)
        {
            this.Name = name;
            this.Contact_inf = contact_inf;
        }
        public override string print_detail()
        {
           return "Customer's name: " + this.Name + "\nCustomer's contact information: " + this.Contact_inf;
        }

        // func order_coffee:
        // - Input: Coffee details, quantity.
        // - Output: Order confirmation.
        public string order_coffee(Coffee coffe, int quantity, Boolean iced)
        {
            return $"You have ordered {quantity} {coffe.Name} coffee(s) {(iced ? "iced" : "hot")} !";
        }
        public string order_coffee(Coffee coffe, int quantity, Boolean iced, Boolean take_away) 
        {
            return $"You have ordered {quantity} {coffe.Name} coffee(s) {(iced ? "iced" : "hot")} {(take_away ? "to take away" : "to drink here")} !";
        }

        // Handle Payment func
        // - Customer can pay for the ordered coffee.
        // - Input: Payment method, amount.
        // - Output: Payment confirmation.
        public string handle_payment(string payment_method, string amount)
        {
           return $"You have paid {amount} by {payment_method}!";
        }

        // Generate Customer Feedback
        // - Customer can provide feedback on the coffee and service.
        // - Input: Feedback details.
        // - Output: Confirmation of feedback submission.
        public string generate_customer_feedback(string feedback_details)
        {
            return $"Your feedback has been submitted !\nFeedback details: {feedback_details}\nThanks for choosing us! See you again!";
        }
    }
}