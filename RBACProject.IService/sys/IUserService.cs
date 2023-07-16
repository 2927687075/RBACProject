using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.IService;
using RBACProject.Model;

namespace RBACProject.IService
{
    public interface IUserService:IBaseService<UserModel>
    {
        List<UserModel> GetUserListPage(UserModel userModel, PageInfo pageInfo, ref int totalCount);

        bool DeleteUser(int id);
        List<RoleModel> GetUserRoleModels(int id);

    }
}
