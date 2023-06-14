using RBACProject.Common;
using RBACProject.Model;
using System.Collections.Generic;

namespace RBACProject.IRepository
{
    public interface IActionRepository : IBaseRepository<ActionModel>
    {
        List<ActionModel> GetActionList(int menuId, int roleId, PositionEnum outOrIn);

        List<ActionModel> GetActionListPage(ActionModel actionModel, PageInfo pageInfo, ref int totalCount);

    }
}
