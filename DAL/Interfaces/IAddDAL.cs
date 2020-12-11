using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAddDAL
    {
        AddDTO Createadd(AddDTO add);
        void Deleteadd(int Id_of_order);
        List<AddDTO> FromSameOrder(int Order_id);
    }
}
