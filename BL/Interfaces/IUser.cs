using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUser
    {
        ItemDTO AddItem(ItemDTO item);
        ItemDTO ChangeItem(ItemDTO item);
        void ShowItemsSorted(int SortingParameter);
        List<ItemDTO> ShowItems();
        void RemoveItem(int ItemID);
        ItemDTO GetItem(int ItemID);


        bool Log(string login, string password);
        Order_ManagerDTO AddOrder_Manager(Order_ManagerDTO Order_Manager); 
        Order_ManagerDTO ChangeOrder_Manager(Order_ManagerDTO Order_Manager);
        void RemoveOrder_Manager(int O_M_id);
        Order_ManagerDTO GetOrder_Manager(int O_M_id);
        Order_ManagerDTO GetOrder_ManagerByLogin(string Order_ManagerLogin);


        OrderDTO GetOrder(int OrderID);
        OrderDTO CompleteOrder(int OrderID);
        void DeleteOrder(int OrderID);
        List<OrderDTO> ShowOrders(int O_M_id);

        void ShowCustomers();
    }
}
