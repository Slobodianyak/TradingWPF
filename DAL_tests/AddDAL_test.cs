using DAL.Concrete;
using DTO;
using Microsoft.IdentityModel.Protocols;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace DAL_tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class AddDAL_test
    {
        [Test]
        public void CreateAddToOrderTest()
        {
            AddDAL dal = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);

            var result = new AddDAL
            {
                Id_of_order = 5,
                Id_of_item = 1,
                Quantity = 28
            };

            result = dal.AddDAL(result);
            Assert.IsTrue(result.Id_of_order == 5 && result.Id_of_item == 1, "AddToOrder was not created");

        }


        [Test]
        public void GetAllFromSameOrderTest()
        {
            AddDAL dal = new AddDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            var result = dal.FromSameOrder(6);

            Assert.IsTrue(result.Count != 0, "no items shown"); ;

        }


    }
}
