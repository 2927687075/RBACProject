using RightControl.Model;
using System.Collections.Generic;

namespace RightControl.IRepository
{
    public interface IRoleRepository : IBaseRepository<RoleModel>
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleModel> GetRoleList();
        /// <summary>
        /// 删除角色时,同时删除t_menu_role_action记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        bool DeleteRoleAllByRoleId(int roleId);
    }
}
