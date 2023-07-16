using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IService;
using RBACProject.Model;
using RBACProject.Common;

namespace RBACProject.IService
{
    public interface IActionService:IBaseService<ActionModel>
    {
        List<ActionModel> GetActionList(int menuId, List<int> roleIds, PositionEnum outOrIn);

        List<ActionModel> GetActionListPage(ActionModel actionModel, PageInfo pageInfo, ref int totalCount);

    }
}
