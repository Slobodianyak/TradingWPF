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
    public class ItemDAL_test
    {
        [Test]
        public void CreateItemTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            var result = dal.CreateItem(new ItemDTO
            {
                Name = "Test Item",
                Value = 157,
            });
            Assert.IsTrue(result.Item_id >= 0, "returned ID should be more than zero");

        }


        [Test]
        public void GetItemByIDTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            var result = dal.GetItemById(1);
            Assert.IsTrue(result.Item_id == 1, "returned ID does not match request");

        }

        [Test]
        public void DeleteItemTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            dal.DeleteItem(12);

            Assert.IsTrue(dal.GetItemById(12).Item_id != 12, "item still in db"); ;

        }


        [Test]
        public void GetAllItemsTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            var result = dal.GetAllItems();

            Assert.IsTrue(result.Count != 0, "no items shown"); ;

        }

        [Test]
        public void UpdateItem()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);

            ItemDTO upd = dal.UpdateItem(new ItemDTO
            {
                Item_id = 4,
                Value = 15,
            });



            Assert.IsTrue(upd.Value == 10, "Item was not updated");

        }


    }
}
