using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrder_ManagerDAL
    {
        Order_ManagerDTO CreateOrder_Manager(Order_ManagerDTO Order_Manager);
        Order_ManagerDTO GetOrder_ManagerById(int Order_ManagerID);
        Order_ManagerDTO GetOrder_ManagerByLogin(string Order_ManagerLogin);
        Order_ManagerDTO UpdateOrder_Manager(Order_ManagerDTO Order_Manager);
        void DeleteOrder_Manager(int Order_ManagerID);
        bool Login(string password, string Login);
    }
}
