using RBACProject.Common;
using RBACProject.Model;
using System.Collections.Generic;

namespace RBACProject.IRepository
{
    public interface IInventoryRepository : IBaseRepository<InventoryModel>
    {
        //List<ActionModel> GetInventoryList(int menuId, List<int> roleIds, PositionEnum outOrIn);

        List<InventoryModel> GetInventoryListPage(InventoryModel inventoryModel, PageInfo pageInfo, ref int totalCount);


        bool WriteExcelDataToDataBase(string filePath,string createBy);

    }
}
