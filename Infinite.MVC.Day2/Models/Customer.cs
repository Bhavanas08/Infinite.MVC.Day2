using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinite.MVC.Day2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string MobileNo { get; set; }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer() {Id=1001,Name= "Bhavana",MobileNo="6302939043"},
                new Customer() {Id=1002,Name= "Anusha",MobileNo="7302939052"},
                new Customer() {Id=1003,Name= "Kondareddy",MobileNo="8302939043"},
                new Customer() {Id=1004,Name= "sharan",MobileNo="9302939043"}
            };
        }
    }
}