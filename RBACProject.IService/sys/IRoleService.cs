using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IService;
using RBACProject.Model;

namespace RBACProject.IService
{
    public interface IRoleService:IBaseService<RoleModel>
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
