using RightControl.Common;
using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IActionRepository : IBaseRepository<ActionModel>
    {
        /// <summary>
        /// 根据roleId获取操作列表数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuId"></param>
        /// <param name="selectList"></param>
        /// <returns></returns>
        IEnumerable<ActionModel> GetActionListByRoleId(int roleId, int menuId, out IEnumerable<ActionModel> selectList);
        /// <summary>
        /// 根据menuId获取操作列表
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        IEnumerable<ActionModel> GetActionListByMenuId(int menuId);
        /// <summary>
        /// 根据menuId和roleId获取操作列表
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="roleId"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        IEnumerable<ActionModel> GetActionListByMenuIdRoleId(int menuId, int roleId, PositionEnum position);
        /// <summary>
        /// 删除按钮时,同时删除t_menu_action和t_menu_role_action记录
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        bool DeleteActionAllByActionId(int actionId);
    }
}
