using RBACProject.Model;
using System.Collections.Generic;

namespace RBACProject.IRepository
{
    public interface IRoleRepository : IBaseRepository<RoleModel>
    {
        /// <summary>
        /// 获取菜单-操作列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<MenuModel> GetRoleMenuList(int roleId);
        bool SaveMenuRoleAction(List<RoleMenuActionModel> roleMenuActions, int roleId);
    }
}
