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
    public class RoleService : BaseService<RoleModel>, IRoleService
    {
        public IRoleRepository roleRepository { get; set; }
        public List<MenuModel> GetRoleMenuList(int roleId)
        {
            return roleRepository.GetRoleMenuList(roleId);
        }

        public bool SaveMenuRoleAction(List<RoleMenuActionModel> roleMenuActions, int roleId)
        {
            return roleRepository.SaveMenuRoleAction(roleMenuActions,roleId);
        }
    }
}
