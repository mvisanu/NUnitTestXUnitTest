using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }

        bool IsPlatinum { get; set; }

        int OrderTotal { get; set; }

        string GreetMessage { get; set; }

        string CombineNames(string firstName, string LastName);

        CustomerType GetCustomerDetails();
    }
    public class Customer : ICustomer
    {
       
        public int Discount { get; set; }
        public bool IsPlatinum { get; set; }

        public int OrderTotal { get; set; } 

        public string GreetMessage { get; set; }

        public Customer()
        {
            IsPlatinum = false;
            Discount = 15;
        }

        public string CombineNames(string firstName, string LastName)
        {
            GreetMessage = $"Hello, {firstName} {LastName}";

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty firstname");
            }
            Discount = 20;
            return  GreetMessage;   
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }

            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }

    public class BasicCustomer: CustomerType { }

    public class PlatinumCustomer : CustomerType { }


}
