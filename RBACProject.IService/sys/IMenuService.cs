using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IService;
using RBACProject.Model;

namespace RBACProject.IService
{
    public interface IMenuService:IBaseService<MenuModel>
    {
        List<MenuTree> GetMenuList(List<int> roleIds, int parentId, bool isSelect);
        bool DeleteMenu(int menuId);
        List<MenuModel> GetAllMenuListByRoleId(List<int> roleIds);


    }
}
