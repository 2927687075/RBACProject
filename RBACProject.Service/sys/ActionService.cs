using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.Common;
using RBACProject.IService;
using RBACProject.Model;
using RBACProject.IRepository;

namespace RBACProject.Service
{
    public class ActionService : BaseService<ActionModel>, IActionService
    {
        public IActionRepository actionRepository { get; set; }

        public List<ActionModel> GetActionList(int menuId, List<int> roleIds, PositionEnum outOrIn)
        {



            return actionRepository.GetActionList(menuId,roleIds,outOrIn);
        }

        public List<ActionModel> GetActionListPage(ActionModel actionModel, PageInfo pageInfo, ref int totalCount)
        {
            return actionRepository.GetActionListPage(actionModel,pageInfo,ref totalCount);
        }
    }
}
