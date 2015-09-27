using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalTractor;

namespace appTractor.Model
{
    public class CustomerModel : IModelBase
    {
        private Customer customer;

        public List<Customer> getAllCustomers() {
            return CustomerDAL.getCustomers();
        }

        public void add(Customer customer, int userId)
        {
            this.customer = customer;
            if (valid())
            {
                CustomerDAL.create(customer.CustomerName, customer.Contact, customer.Address, customer.Fax, customer.TaxNo, userId);
            }
            else {
                throw new Exception("Invalid data!");
            }
        }

        public void update(Customer customer, int userId)
        {
            this.customer = customer;
            if (valid())
            {
                CustomerDAL.update(customer.CustomerID, customer.CustomerName, customer.Contact, customer.Address, customer.Fax, customer.TaxNo, userId);
            }
            else
            {
                throw new Exception("Invalid Data!");
            }
        }

        public void delete(int customerId, int userId)
        {
            CustomerDAL.delete(customerId, userId);
        }

        private bool valid()
        {
            return !String.IsNullOrEmpty(customer.CustomerName);
        }

        
    }
}
