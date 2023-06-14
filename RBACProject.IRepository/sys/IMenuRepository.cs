using RBACProject.Model;
using System.Collections.Generic;

namespace RBACProject.IRepository
{
    public interface IMenuRepository:IBaseRepository<MenuModel>
    {
        /// <summary>
        /// 获取菜单信息（根据角色）
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="parentId">父id</param>
        /// <returns></returns>
        List<MenuTree> GetMenuList(int roleId, int parentId,bool isSelect);
        bool DeleteMenu(int menuId);
        //bool UpdateMenu(MenuModel menuModel);

    }
}
