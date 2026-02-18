using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments6_3
{
    internal class CallQueue
    {
        LinkedList<Customer> customers = new LinkedList<Customer>();
        //mimic a queue using a linked list
        //enqueue
        public void Enqueue(Customer customer)
        {
            customers.AddLast(customer);
        }
        //dequeue
        public Customer Dequeue()
        {
            if (customers.Count == 0 || customers.First == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            Customer customer = customers.First!.Value;
            customers.RemoveFirst();
            return customer;
        }
        //iterating through the queue
        public void PrintQueue()
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Customer {customer.Name}, Phone number: {customer.PhoneNumber}");
            }
        }
    }
}
