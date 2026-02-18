using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments6_3
{
    public class Customer
    {
        private string _name;
        private string _phoneNumber;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        public Customer(string Name, string PhoneNumber)
        {
            _name = Name;
            _phoneNumber = PhoneNumber;
        }

    }
}
