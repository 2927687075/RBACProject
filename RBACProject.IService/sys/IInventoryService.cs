using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IService;
using RBACProject.Model;

namespace RBACProject.IService
{
    public interface IInventoryService:IBaseService<InventoryModel>
    {
        List<InventoryModel> GetInventoryListPage(InventoryModel inventoryModel, PageInfo pageInfo, ref int totalCount);

        bool WriteExcelDataToDataBase(string filePath, string createBy);

    }
}
