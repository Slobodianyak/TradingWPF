using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IItemDAL
    {
        ItemDTO GetItemById(int ItemID);
        List<ItemDTO> GetAllItems();
        ItemDTO UpdateItem(ItemDTO item);
        ItemDTO CreateItem(ItemDTO item);
        void DeleteItem(int ItemID);
        List<ItemDTO> GetAllItemsSorted(int n);

    }
}
