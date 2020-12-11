using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICustomer
    {
        CustomerDTO AddCustomer(CustomerDTO customer); 
        void RemoveCustomer(int CustomerID);
        CustomerDTO GetCustomer(int CustomerID);
        CustomerDTO GetCustomerByLogin(string CustomerLogin);
        bool Log(string Email, string Phone);


        AddDTO AddPosition(AddDTO Add);
        void DeletePosition(int OrderIDKEY);
        List<AddDTO> SameOrderPositions(int OrderIDKEY);

        List<ItemDTO> ShowItems();
        ItemDTO GetItem(int ItemID);

        OrderDTO AddOrder(OrderDTO order);
    }
}
