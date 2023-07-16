using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IService;
using RBACProject.Model;
using RBACProject.IRepository;

namespace RBACProject.Service
{
    public class InventoryService : BaseService<InventoryModel>, IInventoryService
    {
        public IInventoryRepository inventoryRepository { get; set; }

        public List<InventoryModel> GetInventoryListPage(InventoryModel inventoryModel, PageInfo pageInfo, ref int totalCount)
        {
            return inventoryRepository.GetInventoryListPage(inventoryModel,pageInfo,ref totalCount);
        }

        public bool WriteExcelDataToDataBase(string filePath, string createBy)
        {
            return inventoryRepository.WriteExcelDataToDataBase(filePath,createBy);
        }
    }
}
