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
    public class MenuService : BaseService<MenuModel>,IMenuService
    {
        public IMenuRepository menuRepository { get; set; }

        public bool DeleteMenu(int menuId)
        {
            return menuRepository.DeleteMenu(menuId);
        }

        public List<MenuModel> GetAllMenuListByRoleId(List<int> roleIds)
        {
            return menuRepository.GetAllMenuListByRoleId(roleIds);
        }

        public List<MenuTree> GetMenuList(List<int> roleIds, int parentId, bool isSelect)
        {
            return menuRepository.GetMenuList(roleIds,parentId,isSelect);
        }
    }
}
