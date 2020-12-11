using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BL.Solid;

namespace BL_tests.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    class Customer_tests
    {
        [Test]
        public void AddOrderTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            var order = new OrderDTO
            {
                OrderManagerid = 2,
                Customerid = 2,
                Value = 0,
                Date = DateTime.Now,


            };



            var r = result.AddOrder(order);
            Assert.IsTrue(r.Order_id != 0, "returned ID should be more than zero");
        }


        [Test]
        public void GetCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            Assert.IsTrue(result.GetCustomer(2).Customer_id == 2, "Cannot find the customer");
        }


        [Test]
        public void UpdateCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            var customer = new CustomerDTO
            {
                Customer_id = 2,
                Customer_e_mail = "EmailTest",
                Customer_login = "LoginTest"

            };
            Assert.IsTrue(result.ChangeCustomer(customer).Customer_e_mail == "EmailTest", "Customer was not updated");


        }


        [Test]
        public void DeleteCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.RemoveCustomer(3);
            Assert.IsTrue(result.GetCustomer(3).Customer_id != 3, "Customer was not deleted");
        }


        [Test]
        public void LogTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.Log("Test2", "Test2");
            Assert.IsTrue(result.Log("Test2", "Test2") == true, "Customer was not logged");
        }

        [Test]
        public void AddCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);

            var customer = new CustomerDTO
            {
                Customer_id = 2,
                Customer_e_mail = "Test2",
                Customer_login = "Test2",
            };

            result.AddCustomer(customer);
            Assert.IsTrue(customer.Customer_id >= 0, "returned ID should be more than zero");

        }

        public void DeleteShipperTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.RemoveOrder_Manager(4);
            Assert.IsTrue(result.GetOrder_Manager(4).ShipperID != 4, "Shipper was not deleted");
        }

        [Test]
        public void GetItemTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.GetItem(1);
            Assert.IsTrue(result.GetItem(1).Item_id == 1, "Item was not found");
        }


        [Test]
        public void DeletePositionTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Order_ManagerDAL shipperDAL = new Order_ManagerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString); ;
            AddDAL addtoorderDAL = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.DeletePosition(1);
            Assert.IsTrue(result.SameOrderPositions(1).Count == 0, "Position was not deleted");
        }
    }
}
